using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;

using TrainingCentreDataManagement.Models;
using TrainingCentreDataManagement.Models.Repository;

namespace TrainingCentreDataManagement.Controllers
{
    public class FacultyController : Controller
    {
       
        private readonly IFaculty context;
       // private readonly BatchRepository batchRepository;


        public FacultyController(IFaculty context)//,,BatchRepository batchRepository this can be possible
        {
            this.context = context;
           // this.batchRepository = batchRepository; 
        }

        
        [HttpGet]
        public IActionResult Index()
        {
           
            var data = HttpContext.Session.GetInt32("BatchId");
            
            return View(context.getdata(Convert.ToInt32(data)));
        }
        public IActionResult Create()
        {
            Faculty s = new Faculty();
             
            return View(s);
        }

        [HttpPost]
        public IActionResult Create(Faculty sViewModel)
        {
            try
            {
                var mybatchid = HttpContext.Session.GetInt32("BatchId");
                context.AddNewRecord(sViewModel,Convert.ToInt32(mybatchid));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            return View(context.search(id));
        }
        [HttpPost]
        public IActionResult Edit(Faculty model)
        {

            context.EditARecord(model);
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {
            return View(context.search(id));
        }
        [HttpPost]
        public IActionResult Delete(Faculty model)
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

        public IActionResult Details(int id)
        {
            var data = context.search(id);
            return View(data);
        }

    }
}
