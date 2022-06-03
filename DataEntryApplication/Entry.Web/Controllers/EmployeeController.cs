using Entry.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entry.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var model = new EmployeeViewModel();
            return View(model.Get());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var model = new EmployeeViewModel();
            return View(model.GetSingle(id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View(new EmployeeViewModel()) ;
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, EmployeeViewModel employeeViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    employeeViewModel.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new EmployeeViewModel();
           
            return View(model.GetSingle(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeViewModel.Save();
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new EmployeeViewModel();
            var employeeViewModel = model.GetSingle(id);

            return View(employeeViewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection, EmployeeViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model.DeleteEmployee(id);

                return RedirectToAction("Index");
            }
            catch
            {
                var employeeViewModel = model.GetSingle(id);
                return View(employeeViewModel);
            }
        }
    }
}
