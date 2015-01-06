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
      <input id=""Success"" name=""Success"" type=""radio"">Description here
     </label>
    </div>
   </div>
   <div class=""form-group"">
    <div class=""text-danger form-control-static""></div>
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
