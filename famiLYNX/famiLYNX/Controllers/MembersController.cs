using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace famiLYNX.Controllers
{
    public class MembersController : Controller
    {
        Repository _repo = new Repository();

        // GET: Members
        public ActionResult MyProfile(string userID)
        {
            //var myView = _repo.GetMember(userID);

            return View();
        }
    }
}
