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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Architecture>("test-alternate-model",
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
    }
}
