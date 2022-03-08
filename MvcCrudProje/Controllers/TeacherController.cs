using MvcCrudProje.Bussiness.Repository.GenericRepositoryManager;
using MvcCrudProje.Models.Context;
using MvcCrudProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudProje.Controllers
{
    public class TeacherController : Controller
    {
        GenericRepository<Teacher> db = new GenericRepository<Teacher>();
        // GET: Teacher
        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teach = db.get();
            return View(teach);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Insert(Teacher teacher)
        {
            db.create(teacher);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                var model = db.Teacher.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("Update", model);
            }
        }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            db.update(teacher);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.delete(id);
            return RedirectToAction("Index");
        }
    }
}