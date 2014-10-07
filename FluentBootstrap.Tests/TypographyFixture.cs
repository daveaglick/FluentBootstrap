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
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
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
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<h3>Heading 3<small>This is small</small></h3>", doc.GetElementbyId("test-small").CollapsedInnerHtml());
        }

        [Test]
        public void AlignmentProducesCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<p class=""text-left"">Left</p><p class=""text-right"">Right</p><p class=""text-center"">Center</p><p class=""text-justify"">Justify</p><p class=""text-nowrap"">No Wrap</p>", doc.GetElementbyId("test-alignment").CollapsedInnerHtml());
        }

        [Test]
        public void TransformationProducesCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<p class=""text-lowercase"">Lowercase</p><p class=""text-uppercase"">Uppercase</p><p class=""text-capitalize"">capitalized text</p>", doc.GetElementbyId("test-transformation").CollapsedInnerHtml());
        }

        [Test]
        public void MultipleTextClassesProduceCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<p class=""text-center text-uppercase"">Multiple</p>", doc.GetElementbyId("test-multiple-text-classes").CollapsedInnerHtml());
        }

        [Test]
        public void UnorderedListProduceCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<ul><li>One</li><li>Two</li></ul>", doc.GetElementbyId("test-unordered-list").CollapsedInnerHtml());
        }

        [Test]
        public void OrderedListProduceCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<ol><li>One</li><li>Two</li></ol>", doc.GetElementbyId("test-ordered-list").CollapsedInnerHtml());
        }

        [Test]
        public void UnstyledListProduceCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<ul class=""list-unstyled""><li>One</li><li>Two</li></ul>", doc.GetElementbyId("test-unstyled-list").CollapsedInnerHtml());
        }

        [Test]
        public void InlineListProduceCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Typography>();
            Assert.AreEqual(@"<ul class=""list-inline""><li>One</li><li>Two</li></ul>", doc.GetElementbyId("test-inline-list").CollapsedInnerHtml());
        }
    }
}
