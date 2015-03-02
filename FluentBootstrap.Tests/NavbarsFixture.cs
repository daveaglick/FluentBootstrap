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
            TestHelper.AssertHtml<ASP._Views_Tests_Navbars_cshtml>("test-standard-navbar",
@"<nav role=""navigation"" id=""navbar"" class=""navbar navbar-default"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a href=""/"" class=""navbar-brand"">MyApp</a>
     <button type=""button"" data-toggle=""collapse"" data-target=""#navbar-collapse"" class=""navbar-toggle collapsed"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div id=""navbar-collapse"" class=""navbar-collapse collapse"">
     <div class=""nav navbar-nav navbar-left"">
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
            TestHelper.AssertHtml<ASP._Views_Tests_Navbars_cshtml>("test-nonfluid-navbar",
@"<nav role=""navigation"" id=""nav2"" class=""navbar navbar-default"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a href=""/"" class=""navbar-brand"">MyApp</a>
     <button type=""button"" data-toggle=""collapse"" data-target=""#nav2-collapse"" class=""navbar-toggle collapsed"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div id=""nav2-collapse"" class=""navbar-collapse collapse"">
     <div class=""nav navbar-nav navbar-left"">
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
            TestHelper.AssertHtml<ASP._Views_Tests_Navbars_cshtml>("test-fixed-navbar",
@"<nav role=""navigation"" id=""nav3"" class=""navbar navbar-default navbar-fixed-bottom"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a href=""/"" class=""navbar-brand"">MyApp</a>
     <button type=""button"" data-toggle=""collapse"" data-target=""#nav3-collapse"" class=""navbar-toggle collapsed"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div id=""nav3-collapse"" class=""navbar-collapse collapse"">
     <div class=""nav navbar-nav navbar-left"">
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
            TestHelper.AssertHtml<ASP._Views_Tests_Navbars_cshtml>("test-static-navbar",
@"<nav role=""navigation"" id=""nav4"" class=""navbar navbar-default navbar-static-top"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a href=""/"" class=""navbar-brand"">MyApp</a>
     <button type=""button"" data-toggle=""collapse"" data-target=""#nav4-collapse"" class=""navbar-toggle collapsed"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div id=""nav4-collapse"" class=""navbar-collapse collapse"">
     <div class=""nav navbar-nav navbar-left"">
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
            TestHelper.AssertHtml<ASP._Views_Tests_Navbars_cshtml>("test-inverse-navbar",
@"<nav role=""navigation"" id=""nav5"" class=""navbar navbar-default navbar-inverse"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a href=""/"" class=""navbar-brand"">MyApp</a>
     <button type=""button"" data-toggle=""collapse"" data-target=""#nav5-collapse"" class=""navbar-toggle collapsed"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div id=""nav5-collapse"" class=""navbar-collapse collapse"">
     <div class=""nav navbar-nav navbar-left"">
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
            TestHelper.AssertHtml<ASP._Views_Tests_Navbars_cshtml>("test-manual-navbar",
@"<nav role=""navigation"" id=""nav6"" class=""navbar navbar-default"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a href=""#"" class=""navbar-brand"">MyApp</a>
     <button type=""button"" data-toggle=""collapse"" data-target=""#nav6-collapse"" class=""navbar-toggle collapsed"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div id=""nav6-collapse"" class=""navbar-collapse collapse"">
     <div class=""nav navbar-nav navbar-left"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li class=""dropdown""><a href=""#"" data-toggle=""dropdown"" class=""dropdown-toggle navbar-link"">B 
       <span class=""caret""></span></a>
       <ul role=""menu"" class=""dropdown-menu"">
        <li role=""presentation"">
         <a role=""menuitem"" href=""#"">C</a>
        </li>
        <li role=""presentation"">
         <a role=""menuitem"" href=""#"">D</a>
        </li>
       </ul>
      </li>
     </div>
     <form role=""form"" class=""navbar-form navbar-left"">
      <div class=""form-group"">
       <input type=""text"" name=""Search"" placeholder=""Search"" id=""Search"" class=""form-control"">
      </div>
      <div class=""form-group"">
       <button type=""submit"" class=""btn btn-primary"">Submit</button>
      </div>
      <div class=""form-group"">
       <div class=""form-control-static text-danger""></div>
      </div>
     </form>
     <div class=""nav navbar-nav navbar-left"">
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
     <button type=""button"" class=""btn btn-warning navbar-btn navbar-left"">Warn</button>
     <p class=""navbar-text navbar-right"">                    Logged in as <a href=""#"" class=""navbar-link"">Dave</a>
</p>
     <div class=""nav navbar-nav navbar-right"">
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
            TestHelper.AssertHtml<ASP._Views_Tests_Navbars_cshtml>("test-implicit-sections",
@"<nav role=""navigation"" id=""nav7"" class=""navbar navbar-default"">
   <div class=""container-fluid"">
    <div class=""navbar-header"">
     <a href=""#"" class=""navbar-brand"">MyApp</a>
     <button type=""button"" data-toggle=""collapse"" data-target=""#nav7-collapse"" class=""navbar-toggle collapsed"">
      <span class=""sr-only"">Toggle Navigation</span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
      <span class=""icon-bar""></span>
     </button>
    </div>
    <div id=""nav7-collapse"" class=""navbar-collapse collapse"">
     <div class=""nav navbar-nav navbar-left"">
      <li>
       <a href=""#"">A</a>
      </li>
      <li class=""dropdown""><a href=""#"" data-toggle=""dropdown"" class=""dropdown-toggle navbar-link"">B 
       <span class=""caret""></span></a>
       <ul role=""menu"" class=""dropdown-menu"">
        <li role=""presentation"">
         <a role=""menuitem"" href=""#"">C</a>
        </li>
        <li role=""presentation"">
         <a role=""menuitem"" href=""#"">D</a>
        </li>
       </ul>
      </li>
     </div>
     <form role=""form"" class=""navbar-form navbar-left"">
      <div class=""form-group"">
       <input type=""text"" name=""Search"" placeholder=""Search"" id=""Search"" class=""form-control"">
      </div>
      <div class=""form-group"">
       <button type=""submit"" class=""btn btn-primary"">Submit</button>
      </div>
      <div class=""form-group"">
       <div class=""form-control-static text-danger""></div>
      </div>
     </form>
     <div class=""nav navbar-nav navbar-left"">
      <li>
       <a href=""#"">B</a>
      </li>
     </div>
     <button type=""button"" class=""btn btn-warning navbar-btn navbar-left"">Warn</button>
     <p class=""navbar-text navbar-right"">                Logged in as <a href=""#"" class=""navbar-link"">Dave</a>
</p>
    </div>
   </div>
  </nav>");
        }
    }
}
