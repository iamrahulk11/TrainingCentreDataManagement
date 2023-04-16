using Microsoft.AspNetCore.Mvc;

using TrainingCentreDataManagement.Models;
using TrainingCentreDataManagement.Models.Repository;

namespace TrainingCentreDataManagement.Controllers
{
    public class BatchController : Controller
    {
        public BatchRepository context;

        public BatchController(BatchRepository context)
        {
            this.context = context;
        }

        

        public ActionResult Index()
        {
           
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


    }
}
