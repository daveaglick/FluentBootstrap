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
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropA"" class=""control-label"">Property A</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void ExplicitValidationSummaryProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-explicit-validation-summary",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
   <div class=""form-group"">
    <label for=""PropA"" class=""control-label"">Property A</label>
    <div class=""form-control-static""><input id=""PropA"" name=""PropA"" type=""hidden"" value=""""><partial></partial>
</div>
   </div>
  </form>");
        }

        [Test]
        public void PropertyValidationProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-property-validation",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropB"" class=""control-label"">PropB</label>
    <div><partial></partial>
</div>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void EditorOrDisplayForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-display-list-for",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropC_Values"" class=""control-label"">Values</label>
    <div class=""form-control-static""><input id=""PropC_Values"" name=""PropC.Values"" type=""hidden"" value=""""><partial></partial>
</div>
   </div>
  </form>");
        }

        [Test]
        public void DisplayListForForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-editor-list-for",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropC_Values"" class=""control-label"">Values</label>
    <div><partial></partial>
</div>
   </div>
  </form>");
        }

        // For the tests below, the correct value is not output - I think because RazorGenerator doesn't support ModelMetadata
        // So that part of the HTML has been removed for now - these will have to be verified manually

        [Test]
        public void InputForForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-input-for",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropA"" class=""control-label"">Property A</label>
    <input type=""text"" name=""PropA"" id=""PropA"" class=""form-control"">
   </div>
  </form>");
        }

        [Test]
        public void CheckBoxForForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-checkbox-for",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropD"" class=""control-label"">PropD</label>
    <div class=""checkbox"">
     <label class=""checkbox"">
      <input type=""checkbox"" name=""PropD"" id=""PropD"">
     </label>
    </div>
   </div>
  </form>");
        }

        [Test]
        public void RadioForForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-radio-for",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropD"" class=""control-label"">PropD</label>
    <div class=""radio"">
     <label class=""radio"">
      <input type=""radio"" name=""PropD"" id=""PropD"">
     </label>
    </div>
   </div>
  </form>");
        }

        // HtmlAgilityPack strips the closing </option> tag - very annoying!!
        [Test]
        public void SelectForForProducesCorrectHtml()
        {
            TestHelper.AssertMvcHtml<ASP._Views_MvcTests_MvcForms_cshtml>("test-select-for",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""PropC"" class=""control-label"">PropC</label>
    <select name=""PropC"" id=""PropC"" class=""form-control"">
     <option value=""One"">1
     <option value=""Two"">2
     <option value=""Three"">3
    </select>
   </div>
  </form>");
        }
    }
}
