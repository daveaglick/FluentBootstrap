using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class AlertsFixture
    {
        [Test]
        public void AlertStatesProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Alerts_cshtml>("test-states",
@"<div role=""alert"" class=""alert alert-success"">Success</div>
  <div role=""alert"" class=""alert alert-info"">Info</div>
  <div role=""alert"" class=""alert alert-warning"">Warning</div>
  <div role=""alert"" class=""alert alert-danger"">Danger</div>");
        }

        [Test]
        public void AlertHeadingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Alerts_cshtml>("test-heading",
@"<div role=""alert"" class=""alert alert-warning"">
   <strong>Warning </strong>Yikes, this is a warning.
  </div>");
        }

        [Test]
        public void DismissibleAlertProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Alerts_cshtml>("test-dismissible",
@"<div role=""alert"" class=""alert alert-warning alert-dismissible"">
   <button type=""button"" data-dismiss=""alert"" class=""close"">
    <span aria-hidden=""true"">&times;</span>
    <span class=""sr-only"">Close</span>
   </button>Yikes, this is a warning.
  </div>");
        }

        [Test]
        public void DismissibleAlertWithHeadingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Alerts_cshtml>("test-dismissible-with-heading",
@"<div role=""alert"" class=""alert alert-warning alert-dismissible"">
   <button type=""button"" data-dismiss=""alert"" class=""close"">
    <span aria-hidden=""true"">&times;</span>
    <span class=""sr-only"">Close</span>
   </button>
   <strong>Warning </strong>Yikes, this is a warning.
  </div>");
        }

        [Test]
        public void AlertLinksProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Alerts_cshtml>("test-links",
@"<div role=""alert"" class=""alert alert-warning"">
   <strong>Yikes! </strong>            This is 
   <a href=""#"" class=""alert-link"">link</a> inside the alert.

  </div>");
        }
    }
}
