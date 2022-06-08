using Entry.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entry.Web.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            var model = new DepartmentViewModel();
            return View(model.Get());
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var model = new DepartmentViewModel();
            return View(model.GetSingle(id));
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View(new DepartmentViewModel());
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection ,DepartmentViewModel departmentViewModel)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    departmentViewModel.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new DepartmentViewModel();
            return View(model.GetSingle(id));
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection , DepartmentViewModel departmentViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    departmentViewModel.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new DepartmentViewModel();
            var departmentViewModel = model.GetSingle(id);
            return View(departmentViewModel);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection, DepartmentViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model.DeleteDepartment(id);

                return RedirectToAction("Index");
            }
            catch
            {
                var departmentViewModel = model.GetSingle(id);
                return View(departmentViewModel);
            }
        }
    }
}
