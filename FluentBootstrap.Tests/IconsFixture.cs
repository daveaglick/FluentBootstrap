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
    public class IconsFixture
    {
        [Test]
        public void InlineIconProducesCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Icons>();
            Assert.AreEqual(@"This is an inline<span class=""glyphicon-arrow-up glyphicon""></span>icon.", doc.GetElementbyId("test-inline-icon").CollapsedInnerHtml());
        }

        [Test]
        public void ButtonIconProducesCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Icons>();
            Assert.AreEqual(@"<button class=""btn-default btn"" type=""button""><span class=""glyphicon-bell glyphicon""></span>Icon Button</button>", doc.GetElementbyId("test-button-icon").CollapsedInnerHtml());
        }

        [Test]
        public void FormFeedbackProducesCorrectHtml()
        {
            HtmlDocument doc = TestHelper.Render<FluentBootstrap.Tests.Web.Views.Tests.Icons>();
            Assert.AreEqual(@"<form action="""" method=""post"">"
                + @"<div class=""has-feedback form-group""><label class=""control-label"" for=""Normal"">Normal</label><input class=""form-control"" id=""Normal"" name=""Normal"" type=""text""><span class=""form-control-feedback glyphicon-ok-circle glyphicon""></span></div>"
                + @"<div class=""has-feedback has-error form-group""><label class=""control-label"" for=""Error"">Error</label><input class=""form-control"" id=""Error"" name=""Error"" type=""text""><span class=""form-control-feedback glyphicon-remove-circle glyphicon""></span></div>"
                + @"<div class=""has-feedback has-warning form-group""><label class=""sr-only control-label"" for=""SrOnly"">SrOnly Label</label><input class=""form-control"" id=""SrOnly"" name=""SrOnly"" type=""text""><span class=""form-control-feedback glyphicon-check glyphicon""></span></div>"
                + @"<div class=""form-group""><div class=""text-danger form-control-static""></div></div></form>", doc.GetElementbyId("test-form-feedback").CollapsedInnerHtml());
        }
    }
}
