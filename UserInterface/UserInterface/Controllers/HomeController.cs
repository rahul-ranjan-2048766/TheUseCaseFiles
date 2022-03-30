using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseOfPaysTransactionEntities dbObj = new DatabaseOfPaysTransactionEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            var data = dbObj.TableBills.ToList();
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Developers()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchTransaction(decimal TheCreditCardNumber)
        {
            var text = TheCreditCardNumber.ToString().ToLower();
            var data = dbObj.TableBills.Where(x => x.CreditCardNumber.ToLower().Contains(text)).ToList();
            return View("Details", data);
        }
    }
}