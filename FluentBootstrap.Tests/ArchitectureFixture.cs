using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class ArchitectureFixture
    {
        // Note that the editor/display templates can't be tested properly here because RazorGenerator doesn't support partials
        [Test]
        public void AlternateModelProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Architecture_cshtml>("test-alternate-model",
@"<form method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""control-label"" for=""Foo"">Foo</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <label class=""control-label"" for=""Bar"">Bar</label>
    <div class=""form-control-static""><input id=""Bar"" name=""Bar"" type=""hidden"" value=""True""><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <label class=""control-label"" for=""Baz"">Baz</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void AlternateBeginSyntaxProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Architecture_cshtml>("test-alternate-begin",
@"<div class=""btn-group"">
   <button class=""btn-default btn"" type=""button"">
    <span class=""glyphicon-music glyphicon""></span> A
   </button>
   <button class=""btn-default btn"" type=""button"">B</button>
  </div>");
        }
    }
}
