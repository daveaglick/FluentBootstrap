using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class BreadcrumbsFixture
    {
        [Test]
        public void BreadcrumbProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Breadcrumbs>("test-breadcrumb",
@"<ol class=""breadcrumb"">
   <li>
    <a href=""#"">First</a>
   </li>
   <li>
    <a href=""#"">Second</a>
   </li>
   <li class=""active"">Third</li>
  </ol>");
        }
    }
}
