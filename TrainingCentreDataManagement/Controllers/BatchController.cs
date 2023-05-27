using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrainingCentreDataManagement.Models;
using TrainingCentreDataManagement.Models.Repository;

namespace TrainingCentreDataManagement.Controllers
{
    [Authorize]
    public class BatchController : Controller
    {
        private IBatch context;

        public BatchController(IBatch context)
        {
            this.context = context;
        }


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
        public ActionResult Index()
        {
            /*if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "Login");
            }*/
            return View(context.getdata());

        }
        public IActionResult Create()
        {
            Batch s = new Batch();
            return View(s);
        }

        [HttpPost]
        public IActionResult Create(int id,Batch sViewModel)
        {
            try
            {
                context.AddNewRecord(sViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(context.search(id));
        }
        [HttpPost]
        public IActionResult Edit(int id,Batch model)
        {

            context.EditARecord(id,model);
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {
            return View(context.search(id));
        }
        [HttpPost]
        public IActionResult Delete(Batch model)
        {
            try
            {
                context.DeleteRecord(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
     public IActionResult Faculty(int id)
        {
            
            HttpContext.Session.SetInt32("BatchId", id);
            //var ses = HttpContext.Session.GetInt32("BatchId");
           // TempData.Peek("mydata") = id;
            return RedirectToAction("Index","Faculty");
        }
        public IActionResult Student(int id)
        {

            HttpContext.Session.SetInt32("BatchId", id);
            // TempData.Peek("mydata") = id;
            return RedirectToAction("Index", "Student");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
