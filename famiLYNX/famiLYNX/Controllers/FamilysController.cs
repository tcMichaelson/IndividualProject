using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace famiLYNX.Controllers
{
    public class FamilysController : Controller
    {
        // GET: Familys
        public ActionResult Index()
        {
            return View();
        }

        // GET: Familys/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Familys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Familys/Create
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

        // GET: Familys/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Familys/Edit/5
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

        // GET: Familys/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Familys/Delete/5
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
