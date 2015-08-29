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


        public ActionResult Index(string userID, string famName) {
            FamilyViewModel vm = _repo.GetConversations(userID, famName);
            if (vm.ConversationList != null) {
                return View(vm);
            } else {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult IndexNewConversation(string userID, string famName) {
            return View();
        }

    }

}
