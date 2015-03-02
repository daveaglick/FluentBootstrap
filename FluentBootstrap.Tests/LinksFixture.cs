using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class LinksFixture
    {
        // Note that the editor/display templates can't be tested properly here because RazorGenerator doesn't support partials
        [Test]
        public void AlternateModelProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Links_cshtml>("test-no-pretty-printing",
@"<a href=""#"">Link 1</a>|<a href=""#"">Link 2</a>");
        }
    }
}
