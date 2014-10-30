using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class BadgesFixture
    {
        [Test]
        public void InlineBadgeProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Badges>("test-inline",
@"<p>Badge 
  <span class=""badge"">4</span></p>");
        }

        [Test]
        public void LinkBadgeProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Badges>("test-link",
@"<p>
  <a href=""#"">Link
   <span class=""badge"">789</span>
  </a></p>");
        }

        [Test]
        public void ButtonBadgeProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Badges>("test-button",
@"<button class=""btn-default btn"" type=""button"">Button
   <span class=""badge"">4</span>
  </button>
  <button class=""btn-primary btn"" type=""button"">Button
   <span class=""badge"">456</span>
  </button>");
        }

        [Test]
        public void PillsBadgeProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Badges>("test-pills",
@"<ul class=""nav-pills nav"">
   <li>
    <a href=""#"">A
     <span class=""badge"">3</span>
    </a>
   </li>
   <li class=""active"">
    <a href=""#"">B
     <span class=""badge"">5</span>
    </a>
   </li>
  </ul>");
        }
    }
}
