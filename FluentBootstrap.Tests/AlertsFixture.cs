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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Alerts>("test-states",
@"<div class=""alert-success alert"" role=""alert"">Success</div>
  <div class=""alert-info alert"" role=""alert"">Info</div>
  <div class=""alert-warning alert"" role=""alert"">Warning</div>
  <div class=""alert-danger alert"" role=""alert"">Danger</div>");
        }

        [Test]
        public void AlertHeadingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Alerts>("test-heading",
@"<div class=""alert-warning alert"" role=""alert"">
   <strong>Warning </strong>Yikes, this is a warning.
  </div>");
        }

        [Test]
        public void DismissibleAlertProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Alerts>("test-dismissible",
@"<div class=""alert-dismissible alert-warning alert"" role=""alert"">
   <button class=""close"" data-dismiss=""alert"" type=""button"">
    <span aria-hidden=""true"">&times;</span>
    <span class=""sr-only"">Close</span>
   </button>Yikes, this is a warning.
  </div>");
        }

        [Test]
        public void DismissibleAlertWithHeadingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Alerts>("test-dismissible-with-heading",
@"<div class=""alert-dismissible alert-warning alert"" role=""alert"">
   <button class=""close"" data-dismiss=""alert"" type=""button"">
    <span aria-hidden=""true"">&times;</span>
    <span class=""sr-only"">Close</span>
   </button>
   <strong>Warning </strong>Yikes, this is a warning.
  </div>");
        }

        [Test]
        public void AlertLinksProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Alerts>("test-links",
@"<div class=""alert-warning alert"" role=""alert"">
   <strong>Yikes! </strong>            This is 
   <a class=""alert-link"" href=""#"">link</a> inside the alert.

  </div>");
        }
    }
}
