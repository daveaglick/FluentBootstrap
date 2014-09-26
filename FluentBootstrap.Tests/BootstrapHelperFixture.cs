using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorGenerator.Testing;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class BootstrapHelperFixture
    {
        [Test]
        public void TestView()
        {
            var view = new FluentBootstrap.Tests.Web.Views.Tests.Foo.Bar();
            HtmlDocument doc = view.RenderAsHtml(); 
            HtmlNode node = doc.DocumentNode.Element("p");
            Assert.AreEqual("Bar", node.InnerHtml.Trim());
        }
    }
}
