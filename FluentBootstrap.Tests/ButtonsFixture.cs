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
        public void ButtonDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-button-dropdown",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" id=""dd1"" class=""btn btn-default dropdown-toggle"">Dropdown 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void ButtonDropdownNoTextProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-button-dropdown-no-text",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle"">
    <span class=""sr-only"">Toggle Dropdown</span>
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void ButtonDropdownWithStateProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-button-dropdown-with-state",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle btn-danger"">Dropdown 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void ButtonDropdownWithIconProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-button-dropdown-with-icon",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle"">
    <span class=""glyphicon glyphicon-alert""></span> Dropdown 
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void SplitButtonDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-split-button-dropdown",
@"<div class=""btn-group"">
   <button type=""button"" id=""dd2"" class=""btn btn-default"">Dropdown</button>
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle"">
    <span class=""sr-only"">Toggle Dropdown</span>
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void SplitButtonDropdownNoTextProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-split-button-dropdown-no-text",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle"">
    <span class=""sr-only"">Toggle Dropdown</span>
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void SplitButtonDropdownWithStateProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-split-button-dropdown-with-state",
@"<div class=""btn-group"">
   <button type=""button"" class=""btn btn-default btn-danger"">Dropdown</button>
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle btn-danger"">
    <span class=""sr-only"">Toggle Dropdown</span>
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void SplitButtonDropdownWithIconProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-split-button-dropdown-with-icon",
@"<div class=""btn-group"">
   <button type=""button"" class=""btn btn-default"">
    <span class=""glyphicon glyphicon-alert""></span> Dropdown
   </button>
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle"">
    <span class=""sr-only"">Toggle Dropdown</span>
    <span class=""caret""></span>
   </button>
   <ul role=""menu"" class=""dropdown-menu"">
    <li role=""presentation"" class=""dropdown-header"">Header</li>
    <li role=""presentation"" class=""divider""></li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""#"">A</a>
    </li>
    <li role=""presentation"">
     <a role=""menuitem"" href=""http://www.google.com"">B</a>
    </li>
   </ul>
  </div>");
        }

        [Test]
        public void ButtonDropdownSizesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-button-dropdown-sizes",
@"<div class=""btn-group"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle btn-lg"">Lg 
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
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle btn-xs"">XSmall 
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
        public void SplitButtonDropdownSizesProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-split-button-dropdown-sizes",
@"<div class=""btn-group"">
   <button type=""button"" class=""btn btn-default btn-lg"">Lg</button>
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle btn-lg"">
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
  </div>
  <div class=""btn-group"">
   <button type=""button"" class=""btn btn-default btn-xs"">XSmall</button>
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle btn-xs"">
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
        public void DropupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Buttons_cshtml>("test-dropup",
@"<div class=""btn-group dropup"">
   <button type=""button"" data-toggle=""dropdown"" class=""btn btn-default dropdown-toggle"">A 
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
