using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class LabelsFixture
    {
        [Test]
        public void ManualPagerProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Labels_cshtml>("test-inline",
@"<p>This is a 
  <span class=""label-default label"">inline</span> label.</p>");
        }

        [Test]
        public void AutomaticPagerProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Labels_cshtml>("test-headers",
@"<h1>A label in a 
   <span class=""label-default label"">heading</span>
  </h1>
  <h3>            Another heading with a 
   <span class=""label-danger label"">label</span>

  </h3>");
        }
    }
}
