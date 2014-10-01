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
    }
}
