using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace famiLYNX.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(LoginViewModel incoming)
        {
            incoming.UserName = incoming.UserName == null ? "" : incoming.UserName;
            incoming.Password = incoming.Password == null ? "" : incoming.Password;
            return View(incoming);
        }
       
    }
}