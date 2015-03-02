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
            TestHelper.AssertHtml<ASP._Views_Tests_Badges_cshtml>("test-inline",
@"<p>Badge 
  <span class=""badge"">4</span></p>");
        }

        [Test]
        public void LinkBadgeProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Badges_cshtml>("test-link",
@"<p><a href=""#"">Link
  <span class=""badge"">789</span></a></p>");
        }

        [Test]
        public void ButtonBadgeProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Badges_cshtml>("test-button",
@"<button type=""button"" class=""btn btn-default"">Button
   <span class=""badge"">4</span>
  </button>
  <button type=""button"" class=""btn btn-primary"">Button
   <span class=""badge"">456</span>
  </button>");
        }

        [Test]
        public void PillsBadgeProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Badges_cshtml>("test-pills",
@"<ul class=""nav nav-pills"">
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
