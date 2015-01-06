using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class PagersFixture
    {
        [Test]
        public void ManualPagerProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Pagers_cshtml>("test-manual",
@"<nav>
   <ul class=""pager"">
    <li>
     <a href=""http://google.com"">Older</a>
    </li>
    <li class=""disabled"">
     <a href=""#"">Archive</a>
    </li>
    <li>
     <a href=""#"">Newer</a>
    </li>
   </ul>
  </nav>");
        }

        [Test]
        public void AutomaticPagerProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Pagers_cshtml>("test-automatic",
@"<nav>
   <ul class=""pager"">
    <li class=""previous"">
     <a href=""#"">Oldest</a>
    </li>
    <li class=""previous disabled"">
     <a href=""#"">Old</a>
    </li>
    <li>
     <a href=""#"">Archive</a>
    </li>
    <li class=""next"">
     <a href=""#"">Newer</a>
    </li>
   </ul>
  </nav>");
        }
    }
}
