using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;

using TrainingCentreDataManagement.Models;
using TrainingCentreDataManagement.Models.Repository;

namespace TrainingCentreDataManagement.Controllers
{
    public class FacultyController : Controller
    {
        private readonly FacultyRepository context;

        public FacultyController(FacultyRepository context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult Index(int bName)
        {

           
            return View(context.getdata(bName));
        }
        public IActionResult Create()
        {
            Faculty s = new Faculty();
                      
            return View(s);
        }

        [HttpPost]
        public IActionResult Create(Faculty sViewModel, Batch model)
        {
            try
            {
                context.AddNewRecord(sViewModel,model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
