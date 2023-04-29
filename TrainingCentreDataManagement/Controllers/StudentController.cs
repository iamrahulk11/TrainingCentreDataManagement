using Microsoft.AspNetCore.Mvc;
using TrainingCentreDataManagement.Models;
using TrainingCentreDataManagement.Models.Repository;

namespace TrainingCentreDataManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly Istudent context;
       

        public StudentController(Istudent context)
        {
            this.context = context;
           
        }
        public IActionResult Index()
        {
            var data = HttpContext.Session.GetInt32("BatchId");

            return View(context.getdata(Convert.ToInt32(data)));
            
        }
        public IActionResult Create()
        {
            Student s = new Student();

            return View(s);
        }

        [HttpPost]
        public IActionResult Create(Student sViewModel)
        {
            try
            {
                var mybatchid = HttpContext.Session.GetInt32("BatchId");
                context.AddNewRecord(sViewModel, Convert.ToInt32(mybatchid));
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
        public IActionResult Edit(Student model)
        {

            context.EditARecord(model);
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {
            return View(context.search(id));
        }
        [HttpPost]
        public IActionResult Delete(Student model)
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
