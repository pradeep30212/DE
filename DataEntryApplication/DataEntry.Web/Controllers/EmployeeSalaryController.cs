using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataEntry.Web.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        // GET: EmployeeSalary
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeeSalary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeSalary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeSalary/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeSalary/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeSalary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeSalary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeSalary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
