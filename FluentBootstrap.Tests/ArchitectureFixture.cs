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
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""Foo"" class=""control-label"">Foo</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <label for=""Bar"" class=""control-label"">Bar</label>
    <div class=""form-control-static""><input id=""Bar"" name=""Bar"" type=""hidden"" value=""True""><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <label for=""Baz"" class=""control-label"">Baz</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void AlternateBeginSyntaxProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Architecture_cshtml>("test-alternate-begin",
@"<div class=""btn-group"">
   <button type=""button"" class=""btn btn-default"">
    <span class=""glyphicon glyphicon-music""></span> A
   </button>
   <button type=""button"" class=""btn btn-default"">B</button>
  </div>");
        }
    }
}
