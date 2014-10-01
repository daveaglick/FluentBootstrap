using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class GridsFixture
    {
        [Test]
        public void ContainerProducesCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Grids>();
            Assert.AreEqual(@"<div class=""container""> Container</div>", doc.GetElementbyId("test-container").CollapsedInnerHtml());
        }

        [Test]
        public void FluidContainerProducesCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Grids>();
            Assert.AreEqual(@"<div class=""container-fluid""> Fluid Container</div>", doc.GetElementbyId("test-fluid-container").CollapsedInnerHtml());
        }
    }
}
