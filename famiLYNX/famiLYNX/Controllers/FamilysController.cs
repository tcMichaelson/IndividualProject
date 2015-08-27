using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace famiLYNX.Controllers
{
    public class FamilysController : Controller {
        // GET: Familys
        private Repository _repo = new Repository();

        public ActionResult Index() {
            return View(_repo.GetFamily());
        }

        public ActionResult MyFamily(string userID,string famName) {
            return View(_repo.GetFamily());
        }
    }

}
