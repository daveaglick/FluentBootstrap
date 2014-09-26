using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap.Tests.Web.Controllers
{
    public class TestsController : Controller
    {
        [Route("Tests/{*view}")]
        public virtual ActionResult Tests(string view)
        {
            return View(view);
        }
    }
}