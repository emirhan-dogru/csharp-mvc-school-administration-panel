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
    public class WorkerController : Controller
    {
        GenericRepository<Worker> db = new GenericRepository<Worker>();
        // GET: Teacher
        [HttpGet]
        public ActionResult Index()
        {
            List<Worker> other = db.get();
            return View(other);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Insert(Worker worker)
        {
            db.create(worker);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                var model = db.Worker.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("Update", model);
            }
        }

        [HttpPost]
        public ActionResult Update(Worker worker)
        {
            db.update(worker);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.delete(id);
            return RedirectToAction("Index");
        }
    }
}