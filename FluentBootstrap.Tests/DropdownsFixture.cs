using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class DropdownsFixture
    {
        [Test]
        public void SimpleDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Dropdowns_cshtml>("test-simple",
@"<div class=""dropdown"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Dropdown 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void NoCaretDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Dropdowns_cshtml>("test-no-caret",
@"<div class=""dropdown"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">No Caret </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">A</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void ButtonStylesDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Dropdowns_cshtml>("test-button-styles",
@"<div class=""dropdown"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-warning btn-xs"">Button 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">A</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void RightMenuDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Dropdowns_cshtml>("test-right-menu",
@"<div class=""dropdown"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Right 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu dropdown-menu-right"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void DisabledDropdownLinkProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Dropdowns_cshtml>("test-disabled",
@"<div class=""dropdown"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Disabled 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">A</a>
    </li>
    <li role=""presentation"" class=""disabled"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void DropupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Dropdowns_cshtml>("test-dropup",
@"<div class=""dropdown dropup"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Dropup 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void ActiveDropdownLinkProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Dropdowns_cshtml>("test-active-link",
@"<div class=""dropdown"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Dropdown 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">A</a>
    </li>
    <li role=""presentation"" class=""active"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">C</a>
    </li>
   </ul>
  </div>");
        }
    }
}
