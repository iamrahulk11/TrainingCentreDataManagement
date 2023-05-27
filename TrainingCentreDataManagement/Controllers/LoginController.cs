using Microsoft.AspNetCore.Mvc;

using TrainingCentreDataManagement.Models.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TrainingCentreDataManagement.Models;

namespace TrainingCentreDataManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin context;
        private object CliamTypes;

        public LoginController(ILogin context)
        {
            this.context = context;

        }
        public ActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            if (claimuser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Batch");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel user)
        {
            if (ModelState.IsValid == true)
            {
                
                if (context.credentialCheck(user) == false)
                {
                    //ViewBag.ErrorMessage = "Invalid Username and Password";
                    ViewData["ValidationMessage"] = "User Not Found";
                    return View();
                }
                else
                {
                    List<Claim> claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier,user.username),
                        new Claim("OtherProperties","Example Role")
                    };

                    ClaimsIdentity claimIdentify = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = user.KeepLoggedIn
                    };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimIdentify),properties);

                    HttpContext.Session.SetString("Username", user.username);
                    // TempData.Peek("mydata") = id;
                    return RedirectToAction("Index", "Batch");
                }
            }
            return View();
        }
    }
}
