using MvcCrudProje.Bussiness.Repository.GenericRepositoryManager;
using MvcCrudProje.Models.Entities;
using MvcCrudProje.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudProje.Controllers
{
    public class StudentController : Controller
    {
        GenericRepository<Student> db = new GenericRepository<Student>();
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> student = db.get();
            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Insert(Student student)
        {
            db.create(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                var model = db.Student.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("Update", model);
            }
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            db.update(student);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.delete(id);
            return RedirectToAction("Index");
        }
    }
}