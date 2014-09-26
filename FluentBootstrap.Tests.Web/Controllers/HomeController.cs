using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap.Tests.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}