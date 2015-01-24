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
            TestHelper.AssertHtml<ASP._Views_Tests_Icons_cshtml>("test-inline-icon",
@"This is an inline 
  <span class=""glyphicon glyphicon-arrow-up""></span> icon.");
        }

        [Test]
        public void ButtonIconProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Icons_cshtml>("test-button-icon",
@"<button type=""button"" class=""btn btn-default"">
   <span class=""glyphicon glyphicon-bell""></span> Icon Button
  </button>");
        }

        [Test]
        public void LinkButtonIconProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Icons_cshtml>("test-link-button-icon",
@"<a role=""button"" href=""#"" class=""btn btn-default"">
   <span class=""glyphicon glyphicon-picture""></span> Link Button
  </a>");
        }

        [Test]
        public void LinkIconProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Icons_cshtml>("test-link-icon",
@"<a href=""#"">
   <span class=""glyphicon glyphicon-road""></span> Link
  </a>");
        }

        [Test]
        public void FormFeedbackProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Icons_cshtml>("test-form-feedback",
@"<form role=""form"" method=""post"">
   <div class=""form-group has-feedback"">
    <label for=""Normal"" class=""control-label"">Normal</label>
    <input type=""text"" name=""Normal"" id=""Normal"" class=""form-control"">
     <span class=""glyphicon glyphicon-ok-circle form-control-feedback""></span>
    
   </div>
   <div class=""form-group has-error has-feedback"">
    <label for=""Error"" class=""control-label"">Error</label>
    <input type=""text"" name=""Error"" id=""Error"" class=""form-control"">
     <span class=""glyphicon glyphicon-remove-circle form-control-feedback""></span>
    
   </div>
   <div class=""form-group has-warning has-feedback"">
    <label for=""SrOnly"" class=""control-label sr-only"">SrOnly Label</label>
    <input type=""text"" name=""SrOnly"" id=""SrOnly"" class=""form-control"">
     <span class=""glyphicon glyphicon-check form-control-feedback""></span>
    
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }
    }
}
