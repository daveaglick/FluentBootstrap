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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Dropdowns>("test-simple", 
@"<div class=""dropdown"">
   <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">Dropdown 
    <span class=""caret""></span>
   </button>
   <ul class=""dropdown-menu"" role=""menu"">
    <li class=""dropdown-header"" role=""presentation"">Header</li>
    <li class=""divider"" role=""presentation""></li>
    <li role=""presentation"">
     <a href=""#"" role=""menuitem"">A</a>
    </li>
    <li role=""presentation"">
     <a href=""http://www.google.com"" role=""menuitem"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void NoCaretDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Dropdowns>("test-no-caret",
@"<div class=""dropdown"">
   <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">No Caret </button>
   <ul class=""dropdown-menu"" role=""menu"">
    <li role=""presentation"">
     <a href=""http://www.google.com"" role=""menuitem"">A</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void ButtonStylesDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Dropdowns>("test-button-styles",
@"<div class=""dropdown"">
   <button class=""btn-xs dropdown-toggle btn-warning btn"" data-toggle=""dropdown"" type=""button"">Button 
    <span class=""caret""></span>
   </button>
   <ul class=""dropdown-menu"" role=""menu"">
    <li role=""presentation"">
     <a href=""http://www.google.com"" role=""menuitem"">A</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void RightMenuDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Dropdowns>("test-right-menu",
@"<div class=""dropdown"">
   <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">Right 
    <span class=""caret""></span>
   </button>
   <ul class=""dropdown-menu-right dropdown-menu"" role=""menu"">
    <li class=""dropdown-header"" role=""presentation"">Header</li>
    <li class=""divider"" role=""presentation""></li>
    <li role=""presentation"">
     <a href=""#"" role=""menuitem"">A</a>
    </li>
    <li role=""presentation"">
     <a href=""http://www.google.com"" role=""menuitem"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void DisabledDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Dropdowns>("test-disabled",
@"<div class=""dropdown"">
   <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">Disabled 
    <span class=""caret""></span>
   </button>
   <ul class=""dropdown-menu"" role=""menu"">
    <li role=""presentation"">
     <a href=""http://www.google.com"" role=""menuitem"">A</a>
    </li>
    <li class=""disabled"" role=""presentation"">
     <a href=""http://www.google.com"" role=""menuitem"">B</a>
    </li>
   </ul>
  </div>");
        }
    }
}
