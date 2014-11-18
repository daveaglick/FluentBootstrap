using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class NavbarsFixture
    {
        [Test]
        public void StandardNavbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navbars>("test-standard-navbar",
@"<nav class=""navbar-default navbar"" id=""navbar"" role=""navigation"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a class=""navbar-brand"" href=""#"">MyApp</a>
     <button class=""collapsed navbar-toggle"" data-target=""#navbar-collapse"" data-toggle=""collapse"" type=""button"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div class=""collapse navbar-collapse"" id=""navbar-collapse"">
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
    </div>
   </div>
  </nav>");
        }

        [Test]
        public void NonFluidNavbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navbars>("test-nonfluid-navbar",
@"<nav class=""navbar-default navbar"" id=""nav2"" role=""navigation"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a class=""navbar-brand"" href=""#"">MyApp</a>
     <button class=""collapsed navbar-toggle"" data-target=""#nav2-collapse"" data-toggle=""collapse"" type=""button"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div class=""collapse navbar-collapse"" id=""nav2-collapse"">
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
    </div>
   </div>
  </nav>");
        }

        [Test]
        public void FixedNavbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navbars>("test-fixed-navbar",
@"<nav class=""navbar-fixed-bottom navbar-default navbar"" id=""nav3"" role=""navigation"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a class=""navbar-brand"" href=""#"">MyApp</a>
     <button class=""collapsed navbar-toggle"" data-target=""#nav3-collapse"" data-toggle=""collapse"" type=""button"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div class=""collapse navbar-collapse"" id=""nav3-collapse"">
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
    </div>
   </div>
  </nav>");
        }

        [Test]
        public void StaticNavbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navbars>("test-static-navbar",
@"<nav class=""navbar-static-top navbar-default navbar"" id=""nav4"" role=""navigation"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a class=""navbar-brand"" href=""#"">MyApp</a>
     <button class=""collapsed navbar-toggle"" data-target=""#nav4-collapse"" data-toggle=""collapse"" type=""button"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div class=""collapse navbar-collapse"" id=""nav4-collapse"">
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
    </div>
   </div>
  </nav>");
        }

        [Test]
        public void InverseNavbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navbars>("test-inverse-navbar",
@"<nav class=""navbar-inverse navbar-default navbar"" id=""nav5"" role=""navigation"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a class=""navbar-brand"" href=""#"">MyApp</a>
     <button class=""collapsed navbar-toggle"" data-target=""#nav5-collapse"" data-toggle=""collapse"" type=""button"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div class=""collapse navbar-collapse"" id=""nav5-collapse"">
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
    </div>
   </div>
  </nav>");
        }

        [Test]
        public void ManualNavbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navbars>("test-manual-navbar",
@"<nav class=""navbar-default navbar"" id=""nav6"" role=""navigation"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a class=""navbar-brand"" href=""#"">MyApp</a>
     <button class=""collapsed navbar-toggle"" data-target=""#nav6-collapse"" data-toggle=""collapse"" type=""button"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div class=""collapse navbar-collapse"" id=""nav6-collapse"">
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li class=""dropdown"">
       <a class=""navbar-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"">B 
        <span class=""caret""></span>
       </a>
       <ul class=""dropdown-menu"" role=""menu"">
        <li role=""presentation"">
         <a href=""#"" role=""menuitem"">C</a>
        </li>
        <li role=""presentation"">
         <a href=""#"" role=""menuitem"">D</a>
        </li>
       </ul>
      </li>
     </div>
     <form class=""navbar-left navbar-form"" role=""form"">
      <div class=""form-group"">
       <input class=""form-control"" id=""Search"" placeholder=""Search"" name=""Search"" type=""text"">
      </div>
      <div class=""form-group"">
       <button class=""btn-primary btn"" type=""submit"">Submit</button>
      </div>
      <div class=""form-group"">
       <div class=""text-danger form-control-static""></div>
      </div>
     </form>
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
     <button class=""navbar-left navbar-btn btn-warning btn"" type=""button"">Warn</button>
     <p class=""navbar-right navbar-text"">                    Logged in as 
      <a class=""navbar-link"" href=""#"">Dave</a>

     </p>
     <div class=""navbar-right navbar-nav nav"">
      <li>
       <a href=""#"">R</a>
      </li>
     </div>
    </div>
   </div>
  </nav>");
        }

        [Test]
        public void ImplicitSectionsProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navbars>("test-implicit-sections",
@"<nav class=""navbar-default navbar"" id=""nav7"" role=""navigation"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a class=""navbar-brand"" href=""#"">MyApp</a>
     <button class=""collapsed navbar-toggle"" data-target=""#nav7-collapse"" data-toggle=""collapse"" type=""button"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div class=""collapse navbar-collapse"" id=""nav7-collapse"">
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li class=""dropdown"">
       <a class=""navbar-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"">B 
        <span class=""caret""></span>
       </a>
       <ul class=""dropdown-menu"" role=""menu"">
        <li role=""presentation"">
         <a href=""#"" role=""menuitem"">C</a>
        </li>
        <li role=""presentation"">
         <a href=""#"" role=""menuitem"">D</a>
        </li>
       </ul>
      </li>
     </div>
     <form class=""navbar-left navbar-form"" role=""form"">
      <div class=""form-group"">
       <input class=""form-control"" id=""Search"" placeholder=""Search"" name=""Search"" type=""text"">
      </div>
      <div class=""form-group"">
       <button class=""btn-primary btn"" type=""submit"">Submit</button>
      </div>
      <div class=""form-group"">
       <div class=""text-danger form-control-static""></div>
      </div>
     </form>
     <div class=""navbar-left navbar-nav nav"">
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
     <button class=""navbar-left navbar-btn btn-warning btn"" type=""button"">Warn</button>
     <p class=""navbar-right navbar-text"">                Logged in as 
      <a class=""navbar-link"" href=""#"">Dave</a>

     </p>
    </div>
   </div>
  </nav>");
        }
    }
}
