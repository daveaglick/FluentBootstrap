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
            TestHelper.AssertHtml<ASP._Views_Tests_Breadcrumbs_cshtml>("test-breadcrumb",
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
