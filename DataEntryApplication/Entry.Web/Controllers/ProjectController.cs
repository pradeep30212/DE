using Entry.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entry.Web.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            var model = new ProjectViewModel();
            return View(model.Get());
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var model = new ProjectViewModel();
            return View(model.GetSingle(id));
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View(new ProjectViewModel());
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, ProjectViewModel projectViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    projectViewModel.Save();
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new ProjectViewModel();

            return View(model.GetSingle(id));
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, ProjectViewModel projectViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    projectViewModel.Save();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new ProjectViewModel();
            var projectViewModel = model.GetSingle(id);

            return View(projectViewModel);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection, ProjectViewModel model)
        {
            try
            {
                model.DeleteProject(id);

                return RedirectToAction("Index");
            }
            catch
            {
                var projectViewModel = model.GetSingle(id);
                return View(projectViewModel);
            }
        }
    }
}
