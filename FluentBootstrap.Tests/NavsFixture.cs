using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class NavsFixture
    {
        [Test]
        public void TabsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-tabs",
@"<ul class=""nav-tabs nav"" role=""tablist"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </ul>");
        }

        [Test]
        public void PillsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-pills",
@"<ul class=""nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </ul>");
        }

        [Test]
        public void StackedPillsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-stacked-pills",
@"<ul class=""nav-stacked nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </ul>");
        }

        [Test]
        public void JustifiedTabsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-justified-tabs",
@"<ul class=""nav-justified nav-tabs nav"" role=""tablist"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </ul>");
        }

        [Test]
        public void JustifiedPillsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-justified-pills",
@"<ul class=""nav-justified nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </ul>");
        }

        [Test]
        public void DisabledPillProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-disabled-pill",
@"<ul class=""nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li class=""disabled"">
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </ul>");
        }

        [Test]
        public void TabsDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-tabs-dropdown",
@"<ul class=""nav-tabs nav"" role=""tablist"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li class=""disabled"">
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li class=""dropdown"">
    <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"">Dropdown 
     <span class=""caret""></span>
    </a>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">Item 1</a>
     </li>
     <li class=""divider"" role=""presentation""></li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">Item 2</a>
     </li>
    </ul>
   </li>
  </ul>");
        }

        [Test]
        public void PillsDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-pills-dropdown",
@"<ul class=""nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li class=""disabled"">
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li class=""dropdown"">
    <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"">Dropdown 
     <span class=""caret""></span>
    </a>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">Item 1</a>
     </li>
     <li class=""divider"" role=""presentation""></li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">Item 2</a>
     </li>
    </ul>
   </li>
  </ul>");
        }
    }
}
