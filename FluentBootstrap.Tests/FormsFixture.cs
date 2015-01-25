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
    public class FormsFixture
    {
        [Test]
        public void ReadonlyProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-readonly",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <label for=""readonly"" class=""control-label"">Readonly Input</label>
    <input type=""text"" name=""readonly"" value=""Initial Value"" readonly="""" id=""readonly"" class=""form-control"">
   </div>
   <div class=""form-group"">
    <label for=""readonly2"" class=""control-label"">Normal Input</label>
    <input type=""text"" name=""readonly2"" value=""Initial Value"" id=""readonly2"" class=""form-control"">
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void ValidationClassesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-validation",
@"<form role=""form"" method=""post"">
   <div class=""form-group has-error"">
    <label for=""Error"" class=""control-label"">Error</label>
    <input type=""text"" name=""Error"" id=""Error"" class=""form-control"">
   </div>
   <div class=""form-group has-warning"">
    <label for=""Warning"" class=""control-label"">Warning</label>
    <div class=""checkbox"">
     <label class=""checkbox"">
      <input type=""checkbox"" name=""Warning"" id=""Warning"">
     </label>
    </div>
   </div>
   <div class=""form-group has-success"">
    <label for=""Success"" class=""control-label"">Success</label>
    <div class=""radio"">
     <label class=""radio"">
      <input type=""radio"" name=""Success"" id=""Success""> Description here
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void InlineFormProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-inline",
@"<form role=""form"" method=""post"" class=""form-inline"">
   <div class=""form-group"">
    <label for=""input"" class=""control-label"">Input</label>
    <input type=""text"" name=""input"" id=""input"" class=""form-control"">
   </div>
   <div class=""form-group"">
    <label for=""b"" class=""control-label"">B</label>
    <input type=""text"" name=""b"" id=""b"" class=""form-control"">
   </div>
   <div class=""form-group"">
    <label for=""Check"" class=""control-label"">Check It</label>
    <div class=""checkbox"">
     <label class=""checkbox"">
      <input type=""checkbox"" name=""Check"" id=""Check""> Some text...
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void HorizontalFormProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-horizontal",
@"<form role=""form"" method=""post"" class=""form-horizontal"">
   <div class=""form-group"">
    <label for=""horizontal"" class=""control-label col-md-6"">Horizontal</label>
    <div class=""col-md-6"">
     <input type=""text"" name=""horizontal"" id=""horizontal"" class=""form-control"">
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-12"">
     <label for=""not-horizontal"" class=""control-label"">Not Horizontal</label>
     <input type=""text"" name=""not-horizontal"" id=""not-horizontal"" class=""form-control"">
    </div>
   </div>
   <div class=""form-group"">
    <label class=""control-label col-md-3"">Explicit Widths</label>
    <div class=""col-md-9"">
     <input type=""text"" name=""explicit-widths"" id=""explicit-widths"" class=""form-control"">
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-6 col-md-offset-6"">
     <div class=""col-md-9"">
      <input type=""text"" name=""no-label"" id=""no-label"" class=""form-control"">
     </div>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-8 col-md-offset-2"">
     <label for=""group-md"" class=""control-label"">Group Md</label>
     <input type=""text"" name=""group-md"" id=""group-md"" class=""form-control"">
    </div>
   </div>
   <div class=""form-group"">
    <label for=""Check"" class=""control-label col-md-6"">Check It</label>
    <div class=""col-md-6"">
     <div class=""checkbox"" style=""padding-top: 0;"">
      <label class=""checkbox"">
       <input type=""checkbox"" name=""Check"" id=""Check""> Some text...
      </label>
     </div>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-6 col-md-offset-6"">
     <div class=""form-control-static text-danger""></div>
    </div>
   </div>
  </form>");
        }

        [Test]
        public void HorizontalInlineCheckedControlsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-horizontal-inline-checked",
@"<form role=""form"" method=""post"" class=""form-horizontal"">
   <div class=""form-group"">
    <div class=""col-md-8 col-md-offset-4"">
     <label for=""a"" class=""control-label"">A</label>
     <label class=""checkbox-inline"" style=""padding-top: 0;"">
      <input type=""checkbox"" name=""a"" id=""a""> Option A
     </label>
     <label class=""checkbox-inline"" style=""padding-top: 0;"">
      <input type=""checkbox"" name=""b"" id=""b""> Option B
     </label>
     <label for=""c"" class=""control-label"">C</label>
     <label class=""checkbox-inline"" style=""padding-top: 0;"">
      <input type=""checkbox"" name=""c"" id=""c"">&nbsp;
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-8 col-md-offset-4"">
     <div class=""form-control-static text-danger""></div>
    </div>
   </div>
  </form>");
        }

        [Test]
        public void ButtonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-buttons",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <input type=""button"" value=""Input"" class=""btn btn-default"">
   </div>
   <div class=""form-group"">
    <input type=""submit"" value=""Input Submit"" class=""btn btn-default"">
   </div>
   <div class=""form-group"">
    <button type=""button"" class=""btn btn-default"">Button</button>
   </div>
   <div class=""form-group"">
    <button type=""submit"" class=""btn btn-default"">Button Submit</button>
   </div>
   <div class=""form-group"">
    <button type=""submit"" class=""btn btn-primary"">Submit</button>
   </div>
   <div class=""form-group"">
    <button type=""reset"" class=""btn btn-default"">Reset</button>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void FormGroupsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-form-groups",
@"<form role=""form"" method=""post"">
   <div class=""form-group"">
    <input type=""text"" name=""With Form Group"" id=""With_Form_Group"" class=""form-control"">
   </div>
   <input type=""text"" name=""Without Form Group"" id=""Without_Form_Group"" class=""form-control"">
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>
  <input type=""text"" name=""Outside Form"" id=""Outside_Form"" class=""form-control"">");
        }

        [Test]
        public void BasicInputGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-basic-input-group",
@"<form role=""form"" method=""post"">
   <div class=""input-group"">
    <span class=""input-group-addon"">@</span>
    <input type=""text"" placeholder=""Username"" class=""form-control"">
   </div>
   <div class=""input-group"">
    <input type=""text"" class=""form-control"">
    <span class=""input-group-addon"">.00</span>
   </div>
   <div class=""input-group"">
    <span class=""input-group-addon"">$</span>
    <input type=""text"" class=""form-control"">
    <span class=""input-group-addon"">.00</span>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupSizingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-sizing",
@"<form role=""form"" method=""post"">
   <div class=""input-group input-group-lg"">
    <span class=""input-group-addon"">@</span>
    <input type=""text"" placeholder=""Username"" class=""form-control"">
   </div>
   <div class=""input-group input-group-sm"">
    <span class=""input-group-addon"">@</span>
    <input type=""text"" placeholder=""Username"" class=""form-control"">
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupCheckedProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-checked",
@"<form role=""form"" method=""post"">
   <div class=""input-group"">
    <span class=""input-group-addon"">
     <input type=""checkbox"">
    </span>
    <input type=""text"" class=""form-control"">
   </div>
   <div class=""input-group"">
    <span class=""input-group-addon"">
     <input type=""radio"">
    </span>
    <input type=""text"" class=""form-control"">
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupButtonAddonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-button-addons",
@"<form role=""form"" method=""post"">
   <div class=""input-group"">
    <span class=""input-group-btn"">
     <button type=""button"" class=""btn btn-default"">Go!</button>
    </span>
    <input type=""text"" class=""form-control"">
   </div>
   <div class=""input-group"">
    <input type=""text"" class=""form-control"">
    <span class=""input-group-btn"">
     <button type=""button"" class=""btn btn-warning"">Go!</button>
    </span>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupButtonDropdownsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-button-dropdowns",
@"<form role=""form"" method=""post"">
   <div class=""input-group"">
    <span class=""input-group-btn"">
     <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Dropdown 
      <span class=""caret""></span>
     </button>
     <ul role=""menu"" class=""dropdown-menu"">
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">A</a>
      </li>
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">B</a>
      </li>
     </ul>
    </span>
    <input type=""text"" class=""form-control"">
   </div>
   <div class=""input-group"">
    <input type=""text"" class=""form-control"">
    <span class=""input-group-btn"">
     <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Dropdown 
      <span class=""caret""></span>
     </button>
     <ul role=""menu"" class=""dropdown-menu"">
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">A</a>
      </li>
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">B</a>
      </li>
     </ul>
    </span>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupSegmentedButtonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-segmented-buttons",
@"<form role=""form"" method=""post"">
   <div class=""input-group"">
    <span class=""input-group-btn"">
     <button type=""button"" class=""btn btn-default"">Action</button>
     <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">
      <span class=""sr-only"">Toggle Dropdown</span>
      <span class=""caret""></span>
     </button>
     <ul role=""menu"" class=""dropdown-menu"">
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">A</a>
      </li>
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">B</a>
      </li>
     </ul>
    </span>
    <input type=""text"" class=""form-control"">
   </div>
   <div class=""input-group"">
    <input type=""text"" class=""form-control"">
    <span class=""input-group-btn"">
     <button type=""button"" class=""btn btn-default"">Action</button>
     <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">
      <span class=""sr-only"">Toggle Dropdown</span>
      <span class=""caret""></span>
     </button>
     <ul role=""menu"" class=""dropdown-menu"">
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">A</a>
      </li>
      <li role=""presentation"">
       <a role=""menuitem"" href=""#"">B</a>
      </li>
     </ul>
    </span>
   </div>
   <div class=""form-group"">
    <div class=""form-control-static text-danger""></div>
   </div>
  </form>");
        }
    }
}
