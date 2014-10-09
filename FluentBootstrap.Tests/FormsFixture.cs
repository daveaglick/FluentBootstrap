using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    // Note that HtmlAgilityPack strips the closing </input> tag off inputs, which is actually more valid HTML5
    // Whether FluentBootstrap should be outputting the closing </input> in the first place is a problem for another day
    [TestFixture]
    public class FormsFixture
    {
        [Test]
        public void ReadonlyProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Forms>("test-readonly",
@"<form action="""" method=""post"">
   <div class=""form-group"">
    <label class=""control-label"" for=""readonly"">Readonly Input</label>
    <input class=""form-control"" id=""readonly"" name=""readonly"" readonly="""" type=""text"" value=""Initial Value"">
   </div>
   <div class=""form-group"">
    <label class=""control-label"" for=""readonly2"">Normal Input</label>
    <input class=""form-control"" id=""readonly2"" name=""readonly2"" type=""text"" value=""Initial Value"">
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void ValidationClassesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Forms>("test-validation",
@"<form action="""" method=""post"">
   <div class=""has-error form-group"">
    <label class=""control-label"" for=""Error"">Error</label>
    <input class=""form-control"" id=""Error"" name=""Error"" type=""text"">
   </div>
   <div class=""has-warning form-group"">
    <label class=""control-label"" for=""Warning"">Warning</label>
    <div class=""checkbox"">
     <label class=""checkbox"">
      <input id=""Warning"" name=""Warning"" type=""checkbox"">
     </label>
    </div>
   </div>
   <div class=""has-success form-group"">
    <label class=""control-label"" for=""Success"">Success</label>
    <div class=""radio"">
     <label class=""radio"">
      <input id=""Success"" name=""Success"" type=""radio"">Description here
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }
    }
}
