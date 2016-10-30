using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3NETMiniProjet1.Models;

namespace _3NETMiniProjet1.Controllers
{
    public class HomeController : Controller
    {
        private EventManagerEntities siteDB = new EventManagerEntities();

        public string Index()
        {
            return "Hello from Home";
        }

    }
}
