using CodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class StudentController : Controller
    {
        public readonly StudentinfoDbContext context;
        public StudentController (StudentinfoDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var students = context.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(student);
        }

        public IActionResult Details(int? id)
        {
            if(id != null)
            {
                var student = context.Students.FirstOrDefault(i => i.ID == id);
                if(student != null)
                {
                    return View(student);
                }
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                var student = context.Students.FirstOrDefault(i => i.ID == id);
                if (student != null) 
                {
                    return View(student);
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            if(student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var student = context.Students.FirstOrDefault(i => i.ID == id);
                if (student != null)
                {
                    return View(student);
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (student != null)
            {
                context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
    }
}
