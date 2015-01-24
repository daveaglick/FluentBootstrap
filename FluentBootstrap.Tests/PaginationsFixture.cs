using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class PaginationsFixture
    {
        [Test]
        public void ManualPaginationProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Paginations_cshtml>("test-manual",
@"<nav>
   <ul class=""pagination"">
    <li>
     <a href=""http://google.com"">1</a>
    </li>
    <li class=""active"">
     <a href=""#"">2</a>
    </li>
    <li class=""disabled"">
     <a href=""#"">3</a>
    </li>
    <li>
     <a href=""#"">4</a>
    </li>
   </ul>
  </nav>");
        }

        [Test]
        public void AutomaticPaginationProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Paginations_cshtml>("test-automatic",
@"<nav>
   <ul class=""pagination"">
    <li>
     <a href=""#"">&laquo;</a>
    </li>
    <li>
     <a href=""http://google.com"">1</a>
    </li>
    <li class=""active"">
     <a href=""#"">2</a>
    </li>
    <li class=""disabled"">
     <a href=""#"">3</a>
    </li>
    <li>
     <a href=""#"">4</a>
    </li>
    <li>
     <a href=""#"">&raquo;</a>
    </li>
   </ul>
  </nav>");
        }

        [Test]
        public void PaginationSizesProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Paginations_cshtml>("test-sizes",
@"<nav>
   <ul class=""pagination pagination-lg"">
    <li>
     <a href=""#"">&laquo;</a>
    </li>
    <li>
     <a href=""http://google.com"">1</a>
    </li>
    <li class=""active"">
     <a href=""#"">2</a>
    </li>
    <li class=""disabled"">
     <a href=""#"">3</a>
    </li>
    <li>
     <a href=""#"">4</a>
    </li>
    <li>
     <a href=""#"">&raquo;</a>
    </li>
   </ul>
  </nav>
  <nav>
   <ul class=""pagination pagination-sm"">
    <li>
     <a href=""#"">&laquo;</a>
    </li>
    <li>
     <a href=""http://google.com"">1</a>
    </li>
    <li class=""active"">
     <a href=""#"">2</a>
    </li>
    <li class=""disabled"">
     <a href=""#"">3</a>
    </li>
    <li>
     <a href=""#"">4</a>
    </li>
    <li>
     <a href=""#"">&raquo;</a>
    </li>
   </ul>
  </nav>");
        }
    }
}
