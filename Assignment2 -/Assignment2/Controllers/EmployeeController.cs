using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class EmployeeController : Controller
    {
        // Reference to the manager 
        private Manager m = new Manager();

        // GET: Employee
        public ActionResult Index()
        {
            var e = m.EmployeeGetAll();
            return View(e);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.EmployeeGetOne(id.GetValueOrDefault());
            if (obj == null)
            {
                return HttpNotFound();
            } else
            {
                return View(obj);
            }
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            //pass new object to view
            return View(new EmployeeBase());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeAdd newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.EmployeeAddNew(newItem);
            if(addedItem == null)
            {
                return View(newItem);
            } else
            {
                return RedirectToAction("details", new { id = addedItem.EmployeeId });
            }

        }

        /*
        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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

        */

    }
}
