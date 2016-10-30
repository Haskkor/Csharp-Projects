using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestASPMVC.Models;

namespace TestASPMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private TestContext db = new TestContext();

        public ActionResult Index()
        {
            //ViewBag.Message = "Mfjdfnksjbf";
            //db.Products.Add(new Product {Name = "asdf"});
            //db.SaveChanges();
            return View();
        }

    }
}
