using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class TagsFixture
    {
        [Test]
        public void WithChildProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Tags_cshtml>("test-with-child",
@"<div class=""row"">
   <div class=""col-md-12"">With Child</div>
  </div>");
        }

        [Test]
        public void WithChildDisposableProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Tags_cshtml>("test-with-child-disposable",
@"<div class=""row"">
   <div class=""col-md-12"">            With Child Disposable
</div>
  </div>");
        }

        [Test]
        public void WithChildNestedProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Tags_cshtml>("test-with-child-nested",
@"<div class=""container"">
   <div class=""row"">
    <div class=""col-md-8"">                A
</div>
    <div class=""col-md-4"">B</div>
   </div>
  </div>");
        }

        [Test]
        public void AddChildProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Tags_cshtml>("test-add-child",
@"<div class=""row"">
   <div class=""col-md-6"">A</div>
   <div class=""col-md-6"">B
    <div class=""container""></div>
   </div>
  </div>");
        }

        [Test]
        public void AddContentWithComponentProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Tags_cshtml>("test-addcontent-adds-component",
@"<div>
  <span>span-component</span></div>");
        }
    }
}
