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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-tabs",
@"<div class=""nav-tabs nav"" role=""tablist"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </div>");
        }

        [Test]
        public void PillsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-pills",
@"<div class=""nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </div>");
        }

        [Test]
        public void StackedPillsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-stacked-pills",
@"<div class=""nav-stacked nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </div>");
        }

        [Test]
        public void JustifiedTabsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-justified-tabs",
@"<div class=""nav-justified nav-tabs nav"" role=""tablist"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </div>");
        }

        [Test]
        public void JustifiedPillsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-justified-pills",
@"<div class=""nav-justified nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li>
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </div>");
        }

        [Test]
        public void DisabledPillProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-disabled-pill",
@"<div class=""nav-pills nav"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li class=""disabled"">
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li>
    <a href=""#"">Messages</a>
   </li>
  </div>");
        }

        [Test]
        public void TabsDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-tabs-dropdown",
@"<div class=""nav-tabs nav"" role=""tablist"">
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
  </div>");
        }

        [Test]
        public void PillsDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Navs>("test-pills-dropdown",
@"<div class=""nav-pills nav"">
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
  </div>");
        }
    }
}
