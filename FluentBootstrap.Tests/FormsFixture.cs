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
@"<form method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""control-label"" for=""readonly"">Readonly Input</label>
    <input class=""form-control"" id=""readonly"" readonly="""" value=""Initial Value"" name=""readonly"" type=""text"">
   </div>
   <div class=""form-group"">
    <label class=""control-label"" for=""readonly2"">Normal Input</label>
    <input class=""form-control"" id=""readonly2"" value=""Initial Value"" name=""readonly2"" type=""text"">
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void ValidationClassesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-validation",
@"<form method=""post"" role=""form"">
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
      <input id=""Success"" name=""Success"" type=""radio""> Description here
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void InlineFormProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-inline",
@"<form class=""form-inline"" method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""control-label"" for=""input"">Input</label>
    <input class=""form-control"" id=""input"" name=""input"" type=""text"">
   </div>
   <div class=""form-group"">
    <label class=""control-label"" for=""b"">B</label>
    <input class=""form-control"" id=""b"" name=""b"" type=""text"">
   </div>
   <div class=""form-group"">
    <label class=""control-label"" for=""Check"">Check It</label>
    <div class=""checkbox"">
     <label class=""checkbox"">
      <input id=""Check"" name=""Check"" type=""checkbox""> Some text...
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void HorizontalFormProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-horizontal",
@"<form class=""form-horizontal"" method=""post"" role=""form"">
   <div class=""form-group"">
    <label class=""col-md-6 control-label"" for=""horizontal"">Horizontal</label>
    <div class=""col-md-6"">
     <input class=""form-control"" id=""horizontal"" name=""horizontal"" type=""text"">
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-12"">
     <label class=""control-label"" for=""not-horizontal"">Not Horizontal</label>
     <input class=""form-control"" id=""not-horizontal"" name=""not-horizontal"" type=""text"">
    </div>
   </div>
   <div class=""form-group"">
    <label class=""col-md-3 control-label"">Explicit Widths</label>
    <div class=""col-md-9"">
     <input class=""form-control"" id=""explicit-widths"" name=""explicit-widths"" type=""text"">
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-offset-6 col-md-6"">
     <div class=""col-md-9"">
      <input class=""form-control"" id=""no-label"" name=""no-label"" type=""text"">
     </div>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-offset-2 col-md-8"">
     <label class=""control-label"" for=""group-md"">Group Md</label>
     <input class=""form-control"" id=""group-md"" name=""group-md"" type=""text"">
    </div>
   </div>
   <div class=""form-group"">
    <label class=""col-md-6 control-label"" for=""Check"">Check It</label>
    <div class=""col-md-6"">
     <div style=""padding-top: 0;"" class=""checkbox"">
      <label class=""checkbox"">
       <input id=""Check"" name=""Check"" type=""checkbox""> Some text...
      </label>
     </div>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-offset-6 col-md-6"">
     <div class=""text-danger form-control-static""></div>
    </div>
   </div>
  </form>");
        }

        [Test]
        public void HorizontalInlineCheckedControlsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-horizontal-inline-checked",
@"<form class=""form-horizontal"" method=""post"" role=""form"">
   <div class=""form-group"">
    <div class=""col-md-offset-4 col-md-8"">
     <label class=""control-label"" for=""a"">A</label>
     <label style=""padding-top: 0;"" class=""checkbox-inline"">
      <input id=""a"" name=""a"" type=""checkbox""> Option A
     </label>
     <label style=""padding-top: 0;"" class=""checkbox-inline"">
      <input id=""b"" name=""b"" type=""checkbox""> Option B
     </label>
     <label class=""control-label"" for=""c"">C</label>
     <label style=""padding-top: 0;"" class=""checkbox-inline"">
      <input id=""c"" name=""c"" type=""checkbox"">&nbsp;
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""col-md-offset-4 col-md-8"">
     <div class=""text-danger form-control-static""></div>
    </div>
   </div>
  </form>");
        }

        [Test]
        public void BasicInputGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-basic-input-group",
@"<form method=""post"" role=""form"">
   <div class=""input-group"">
    <span class=""input-group-addon"">@</span>
    <input class=""form-control"" placeholder=""Username"" type=""text"">
   </div>
   <div class=""input-group"">
    <input class=""form-control"" type=""text"">
    <span class=""input-group-addon"">.00</span>
   </div>
   <div class=""input-group"">
    <span class=""input-group-addon"">$</span>
    <input class=""form-control"" type=""text"">
    <span class=""input-group-addon"">.00</span>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupSizingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-sizing",
@"<form method=""post"" role=""form"">
   <div class=""input-group-lg input-group"">
    <span class=""input-group-addon"">@</span>
    <input class=""form-control"" placeholder=""Username"" type=""text"">
   </div>
   <div class=""input-group-sm input-group"">
    <span class=""input-group-addon"">@</span>
    <input class=""form-control"" placeholder=""Username"" type=""text"">
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupCheckedProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-checked",
@"<form method=""post"" role=""form"">
   <div class=""input-group"">
    <span class=""input-group-addon"">
     <input type=""checkbox"">
    </span>
    <input class=""form-control"" type=""text"">
   </div>
   <div class=""input-group"">
    <span class=""input-group-addon"">
     <input type=""radio"">
    </span>
    <input class=""form-control"" type=""text"">
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupButtonAddonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-button-addons",
@"<form method=""post"" role=""form"">
   <div class=""input-group"">
    <span class=""input-group-btn"">
     <button class=""btn-default btn"" type=""button"">Go!</button>
    </span>
    <input class=""form-control"" type=""text"">
   </div>
   <div class=""input-group"">
    <input class=""form-control"" type=""text"">
    <span class=""input-group-btn"">
     <button class=""btn-warning btn"" type=""button"">Go!</button>
    </span>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupButtonDropdownsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-button-dropdowns",
@"<form method=""post"" role=""form"">
   <div class=""input-group"">
    <span class=""input-group-btn"">
     <button class=""btn-default dropdown-toggle btn"" data-toggle=""dropdown"" type=""button"">Dropdown 
      <span class=""caret""></span>
     </button>
     <ul class=""dropdown-menu"" role=""menu"">
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">A</a>
      </li>
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">B</a>
      </li>
     </ul>
    </span>
    <input class=""form-control"" type=""text"">
   </div>
   <div class=""input-group"">
    <input class=""form-control"" type=""text"">
    <span class=""input-group-btn"">
     <button class=""btn-default dropdown-toggle btn"" data-toggle=""dropdown"" type=""button"">Dropdown 
      <span class=""caret""></span>
     </button>
     <ul class=""dropdown-menu"" role=""menu"">
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">A</a>
      </li>
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">B</a>
      </li>
     </ul>
    </span>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }

        [Test]
        public void InputGroupSegmentedButtonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Forms_cshtml>("test-input-group-segmented-buttons",
@"<form method=""post"" role=""form"">
   <div class=""input-group"">
    <span class=""input-group-btn"">
     <button class=""btn-default btn"" type=""button"">Action</button>
     <button class=""btn-default dropdown-toggle btn"" data-toggle=""dropdown"" type=""button"">
      <span class=""sr-only"">Toggle Dropdown</span>
      <span class=""caret""></span>
     </button>
     <ul class=""dropdown-menu"" role=""menu"">
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">A</a>
      </li>
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">B</a>
      </li>
     </ul>
    </span>
    <input class=""form-control"" type=""text"">
   </div>
   <div class=""input-group"">
    <input class=""form-control"" type=""text"">
    <span class=""input-group-btn"">
     <button class=""btn-default btn"" type=""button"">Action</button>
     <button class=""btn-default dropdown-toggle btn"" data-toggle=""dropdown"" type=""button"">
      <span class=""sr-only"">Toggle Dropdown</span>
      <span class=""caret""></span>
     </button>
     <ul class=""dropdown-menu"" role=""menu"">
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">A</a>
      </li>
      <li role=""presentation"">
       <a href=""#"" role=""menuitem"">B</a>
      </li>
     </ul>
    </span>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
   </div>
  </form>");
        }
    }
}
