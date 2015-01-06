using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap.Tests.Web.Controllers
{
    public class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}