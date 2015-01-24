using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class ButtonsFixture
    {
        [Test]
        public void ButtonGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-group",
@"<div class=""btn-group"">
   <button type=""button"" class=""btn btn-default"">
    <span class=""glyphicon glyphicon-music""></span> A
   </button>
   <a role=""button"" href=""#"" class=""btn btn-default"">L</a>
   <button type=""button"" class=""btn btn-success"">B</button>
  </div>");
        }

        [Test]
        public void ButtonToolbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-toolbar",
@"<div role=""toolbar"" class=""btn-toolbar"">
   <div class=""btn-group"">
    <button type=""button"" class=""btn btn-default"">A</button>
    <button type=""button"" class=""btn btn-danger"">B</button>
   </div>
   <div class=""btn-group"">
    <button type=""button"" class=""btn btn-default"">C</button>
    <a role=""button"" href=""#"" class=""btn btn-success"">L</a>
    <button type=""button"" class=""btn btn-default"">
     <span class=""glyphicon glyphicon-share-alt""></span> D
    </button>
   </div>
  </div>");
        }

        [Test]
        public void ButtonGroupSizingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-group-sizing",
@"<div class=""btn-group btn-group-lg"">
   <a role=""button"" href=""#"" class=""btn btn-default"">L</a>
   <button type=""button"" class=""btn btn-default"">A</button>
   <button type=""button"" class=""btn btn-default"">
    <span class=""glyphicon glyphicon-pencil""></span> B
   </button>
  </div>
  <div class=""btn-group btn-group-sm"">
   <button type=""button"" class=""btn btn-default"">C</button>
   <a role=""button"" href=""#"" class=""btn btn-default"">
    <span class=""glyphicon glyphicon-phone""></span> L
   </a>
   <button type=""button"" class=""btn btn-default"">D</button>
  </div>
  <div class=""btn-group btn-group-xs"">
   <button type=""button"" class=""btn btn-default"">
    <span class=""glyphicon glyphicon-tags""></span> E
   </button>
   <button type=""button"" class=""btn btn-default"">F</button>
   <a role=""button"" href=""#"" class=""btn btn-default"">L</a>
  </div>");
        }

        [Test]
        public void NestedDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-nested-dropdown",
@"<div class=""btn-group"">
   <button type=""button"" class=""btn btn-default"">A</button>
   <a role=""button"" href=""#"" class=""btn btn-default"">L</a>
   <div class=""btn-group"">
    <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Dropdown 
     <span class=""caret""></span>
    </button>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">B</a>
     </li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">C</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-danger"">Styled 
     <span class=""caret""></span>
    </button>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">D</a>
     </li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">E</a>
     </li>
    </ul>
   </div>
  </div>");
        }

        [Test]
        public void VerticalButtonGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-vertical",
@"<div class=""btn-group-vertical"">
   <button type=""button"" class=""btn btn-default"">A</button>
   <a role=""button"" href=""#"" class=""btn btn-default"">L</a>
   <div class=""btn-group"">
    <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">Dropdown 
     <span class=""caret""></span>
    </button>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">B</a>
     </li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">C</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-danger"">Styled 
     <span class=""caret""></span>
    </button>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">D</a>
     </li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">E</a>
     </li>
    </ul>
   </div>
   <button type=""button"" class=""btn btn-default"">F</button>
  </div>");
        }

        [Test]
        public void JustifiedLinksProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-justified-links",
@"<div class=""btn-group btn-group-justified"">
   <a role=""button"" href=""#"" class=""btn btn-default"">A</a>
   <a role=""button"" href=""#"" class=""btn btn-default"">B</a>
   <a role=""button"" href=""#"" class=""btn btn-default"">Long Link Text</a>
  </div>");
        }

        [Test]
        public void JustifiedButtonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-justified-buttons",
@"<div class=""btn-group btn-group-justified"">
   <div class=""btn-group"">
    <button type=""button"" class=""btn btn-default"">A</button>
   </div>
   <div class=""btn-group"">
    <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">B 
     <span class=""caret""></span>
    </button>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">C</a>
     </li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">D</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button type=""button"" class=""btn btn-default"">Long Button Text</button>
   </div>
  </div>");
        }

        [Test]
        public void JustifiedMixedProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-justified-mixed",
@"<div class=""btn-group btn-group-justified"">
   <div class=""btn-group"">
    <button type=""button"" class=""btn btn-default"">A</button>
   </div>
   <a role=""button"" href=""#"" class=""btn btn-default"">Long Link Text</a>
   <div class=""btn-group"">
    <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default"">C 
     <span class=""caret""></span>
    </button>
    <ul role=""menu"" class=""dropdown-menu"">
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">D</a>
     </li>
     <li role=""presentation"">
      <a role=""menuitem"" href=""#"">E</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button type=""button"" class=""btn btn-default"">Long Button Text</button>
   </div>
   <a role=""button"" href=""#"" class=""btn btn-default"">F</a>
  </div>");
        }

        [Test]
        public void SingleButtonDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-single-button-dropdown",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-success"">Dropdown 
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
  </div>");
        }

        [Test]
        public void SplitButtonDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-split-button-dropdown",
@"<div class=""btn-group"">
   <button type=""button"" class=""btn btn-success"">A</button>
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-success"">
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
  </div>");
        }

        [Test]
        public void ButtonDropdownSizesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-button-dropdown-sizes",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default btn-lg"">Large 
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
  </div>
  <div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-default btn-xs"">XSmall 
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
  </div>");
        }

        [Test]
        public void DropupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-dropup",
@"<div class=""btn-group dropup"">
   <button type=""button"" class=""btn btn-success"">A</button>
   <button type=""button"" data-toggle=""dropdown"" class=""btn dropdown-toggle btn-success"">
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
  </div>");
        }
    }
}
