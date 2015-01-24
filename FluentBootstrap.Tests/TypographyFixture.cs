using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class TypographyFixture
    {

        [Test]
        public void HeadingsProduceCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<ASP._Views_Tests_Typography_cshtml>();
            Assert.AreEqual(@"<h1>Heading 1</h1>", doc.GetElementbyId("test-heading-levels").ChildNodes["h1"].CollapsedOuterHtml());
            Assert.AreEqual(@"<h2>Heading 2</h2>", doc.GetElementbyId("test-heading-levels").ChildNodes["h2"].CollapsedOuterHtml());
            Assert.AreEqual(@"<h3>Heading 3</h3>", doc.GetElementbyId("test-heading-levels").ChildNodes["h3"].CollapsedOuterHtml());
            Assert.AreEqual(@"<h4>Heading 4</h4>", doc.GetElementbyId("test-heading-levels").ChildNodes["h4"].CollapsedOuterHtml());
            Assert.AreEqual(@"<h5>Heading 5</h5>", doc.GetElementbyId("test-heading-levels").ChildNodes["h5"].CollapsedOuterHtml());
            Assert.AreEqual(@"<h6>Heading 6</h6>", doc.GetElementbyId("test-heading-levels").ChildNodes["h6"].CollapsedOuterHtml());
        }

        [Test]
        public void SmallProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-small",
@"<h3>Heading 3
   <small>This is small</small>
  </h3>");
        }

        [Test]
        public void SmallChildProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-small-child",
@"<h3>Heading 3
   <small>This is also small</small>
  </h3>");
        }

        [Test]
        public void AlignmentProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-alignment",
@"<p class=""text-left"">Left</p>
  <p class=""text-right"">            Right
</p>
  <p class=""text-center"">Center</p>
  <p class=""text-justify"">Justify</p>
  <p class=""text-nowrap"">No Wrap</p>");
        }

        [Test]
        public void TransformationProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-transformation",
@"<p class=""text-lowercase"">Lowercase</p>
  <p class=""text-uppercase"">Uppercase</p>
  <p class=""text-capitalize"">capitalized text</p>");
        }

        [Test]
        public void MultipleTextClassesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-multiple-text-classes",
@"<p class=""text-uppercase text-center"">Multiple</p>");
        }

        [Test]
        public void UnorderedListProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-unordered-list",
@"<ul>
   <li>One</li>
   <li>Two</li>
  </ul>");
        }

        [Test]
        public void OrderedListProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-ordered-list",
@"<ol>
   <li>One</li>
   <li>Two</li>
  </ol>");
        }

        [Test]
        public void UnstyledListProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-unstyled-list",
@"<ul class=""list-unstyled"">
   <li>One</li>
   <li>Two</li>
  </ul>");
        }

        [Test]
        public void InlineListProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-inline-list",
@"<ul class=""list-inline"">
   <li>One</li>
   <li>Two</li>
  </ul>");
        }

        [Test]
        public void DescriptionListProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-description-list",
@"<dl>
   <dt>Term</dt>
   <dd>Desc</dd>
   <dt>One</dt>
   <dd>Two</dd>
  </dl>");
        }

        [Test]
        public void HorizontalDescriptionListProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Typography_cshtml>("test-horizontal-description-list",
@"<dl class=""dl-horizontal"">
   <dt>Term</dt>
   <dd>Desc</dd>
   <dt>One</dt>
   <dd>Two</dd>
  </dl>");
        }
    }
}
