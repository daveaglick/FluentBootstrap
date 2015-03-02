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
@"<ul role=""tablist"" class=""nav nav-tabs"">
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
@"<ul class=""nav nav-pills"">
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
@"<ul class=""nav nav-pills nav-stacked"">
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
@"<ul role=""tablist"" class=""nav nav-tabs nav-justified"">
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
@"<ul class=""nav nav-pills nav-justified"">
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
@"<ul class=""nav nav-pills"">
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
@"<ul role=""tablist"" class=""nav nav-tabs"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li class=""disabled"">
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li class=""dropdown""><a href=""#"" data-toggle=""dropdown"" class=""dropdown-toggle"">Dropdown 
    <span class=""caret""></span></a>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">Item 1</a>
     </li>
     <li role=""presentation"" class=""divider""></li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">Item 2</a>
     </li>
    </ul>
   </li>
  </ul>");
        }

        [Test]
        public void PillsDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Navs_cshtml>("test-pills-dropdown",
@"<ul class=""nav nav-pills"">
   <li class=""active"">
    <a href=""#"">Home</a>
   </li>
   <li class=""disabled"">
    <a href=""http://www.google.com"">Profile</a>
   </li>
   <li class=""dropdown""><a href=""#"" data-toggle=""dropdown"" class=""dropdown-toggle"">Dropdown 
    <span class=""caret""></span></a>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">Item 1</a>
     </li>
     <li role=""presentation"" class=""divider""></li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">Item 2</a>
     </li>
    </ul>
   </li>
  </ul>");
        }
    }
}
