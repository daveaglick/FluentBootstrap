using FluentBootstrap.Tests.Web.Models.MvcTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap.Tests.Web.Controllers
{
    public class MvcTestsController : Controller
    {
        public virtual ActionResult MvcTests(string view)
        {
            ViewModel model = new ViewModel
            {
                PropA = "A",
                PropB = 2,
                PropC = new Dictionary<int, string>()
                {
                    { 1, "One"},
                    { 2, "Two"},
                    { 3, "Three"}
                }
            };
            ModelState.AddModelError(string.Empty, "General error message.");
            ModelState.AddModelError("PropB", "Property B error message.");
            return View(view, model);
        }
    }
}