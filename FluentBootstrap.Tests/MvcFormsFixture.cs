using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    // Note that since RazorGenerator just generates "<partial></partial>" for partial views (including display and editor templates) these tests don't actually match the HTML
    [TestFixture]
    public class MvcFormsFixture
    {
        [Test]
        public void ValidationSummaryProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-validation-summary",
@"<form method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""control-label"" for=""PropA"">Property A</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void ExplicitValidationSummaryProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-explicit-validation-summary",
@"<form method=""post"" role=""form"">
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
   <div class=""form-group"">
    <label class=""control-label"" for=""PropA"">Property A</label>
    <div class=""form-control-static""><input id=""PropA"" name=""PropA"" type=""hidden"" value=""""><partial></partial>
</div>
   </div>
  </form>");
        }

        [Test]
        public void PropertyValidationProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-property-validation",
@"<form method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""control-label"" for=""PropB"">PropB</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void EditorOrDisplayForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-display-list-for",
@"<form method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""control-label"" for=""PropC_Values"">Values</label>
    <div class=""form-control-static""><input id=""PropC_Values"" name=""PropC.Values"" type=""hidden"" value=""""><partial></partial>
</div>
   </div>
  </form>");
        }

        [Test]
        public void DisplayListForForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-editor-list-for",
@"<form method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""control-label"" for=""PropC_Values"">Values</label>
    <div><partial></partial>
</div>
   </div>
  </form>");
        }
    }
}
