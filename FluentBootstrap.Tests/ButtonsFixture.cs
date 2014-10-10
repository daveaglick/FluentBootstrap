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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-group",
@"<div class=""btn-group"">
   <button class=""btn-default btn"" type=""button"">
    <span class=""glyphicon-music glyphicon""></span> A
   </button>
   <a class=""btn-default btn"" href=""#"" role=""button"">L</a>
   <button class=""btn-success btn"" type=""button"">B</button>
  </div>");
        }

        [Test]
        public void ButtonToolbarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-toolbar",
@"<div class=""btn-toolbar"" role=""toolbar"">
   <div class=""btn-group"">
    <button class=""btn-default btn"" type=""button"">A</button>
    <button class=""btn-danger btn"" type=""button"">B</button>
   </div>
   <div class=""btn-group"">
    <button class=""btn-default btn"" type=""button"">C</button>
    <a class=""btn-success btn"" href=""#"" role=""button"">L</a>
    <button class=""btn-default btn"" type=""button"">
     <span class=""glyphicon-share-alt glyphicon""></span> D
    </button>
   </div>
  </div>");
        }

        [Test]
        public void ButtonGroupSizingProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-group-sizing",
@"<div class=""btn-group-lg btn-group"">
   <a class=""btn-default btn"" href=""#"" role=""button"">L</a>
   <button class=""btn-default btn"" type=""button"">A</button>
   <button class=""btn-default btn"" type=""button"">
    <span class=""glyphicon-pencil glyphicon""></span> B
   </button>
  </div>
  <div class=""btn-group-sm btn-group"">
   <button class=""btn-default btn"" type=""button"">C</button>
   <a class=""btn-default btn"" href=""#"" role=""button"">
    <span class=""glyphicon-phone glyphicon""></span> L
   </a>
   <button class=""btn-default btn"" type=""button"">D</button>
  </div>
  <div class=""btn-group-xs btn-group"">
   <button class=""btn-default btn"" type=""button"">
    <span class=""glyphicon-tags glyphicon""></span> E
   </button>
   <button class=""btn-default btn"" type=""button"">F</button>
   <a class=""btn-default btn"" href=""#"" role=""button"">L</a>
  </div>");
        }

        [Test]
        public void NestedDropdownProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-nested-dropdown",
@"<div class=""btn-group"">
   <button class=""btn-default btn"" type=""button"">A</button>
   <a class=""btn-default btn"" href=""#"" role=""button"">L</a>
   <div class=""btn-group"">
    <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">Dropdown 
     <span class=""caret""></span>
    </button>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">B</a>
     </li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">C</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button class=""dropdown-toggle btn-danger btn"" data-toggle=""dropdown"" type=""button"">Styled 
     <span class=""caret""></span>
    </button>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">D</a>
     </li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">E</a>
     </li>
    </ul>
   </div>
  </div>");
        }

        [Test]
        public void VerticalButtonGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-vertical",
@"<div class=""btn-group-vertical"">
   <button class=""btn-default btn"" type=""button"">A</button>
   <a class=""btn-default btn"" href=""#"" role=""button"">L</a>
   <div class=""btn-group"">
    <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">Dropdown 
     <span class=""caret""></span>
    </button>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">B</a>
     </li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">C</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button class=""dropdown-toggle btn-danger btn"" data-toggle=""dropdown"" type=""button"">Styled 
     <span class=""caret""></span>
    </button>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">D</a>
     </li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">E</a>
     </li>
    </ul>
   </div>
   <button class=""btn-default btn"" type=""button"">F</button>
  </div>");
        }

        [Test]
        public void JustifiedLinksProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-justified-links",
@"<div class=""btn-group-justified btn-group"">
   <a class=""btn-default btn"" href=""#"" role=""button"">A</a>
   <a class=""btn-default btn"" href=""#"" role=""button"">B</a>
   <a class=""btn-default btn"" href=""#"" role=""button"">Long Link Text</a>
  </div>");
        }

        [Test]
        public void JustifiedButtonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-justified-buttons",
@"<div class=""btn-group-justified btn-group"">
   <div class=""btn-group"">
    <button class=""btn-default btn"" type=""button"">A</button>
   </div>
   <div class=""btn-group"">
    <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">B 
     <span class=""caret""></span>
    </button>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">C</a>
     </li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">D</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button class=""btn-default btn"" type=""button"">Long Button Text</button>
   </div>
  </div>");
        }

        [Test]
        public void JustifiedMixedProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Buttons>("test-justified-mixed",
@"<div class=""btn-group-justified btn-group"">
   <div class=""btn-group"">
    <button class=""btn-default btn"" type=""button"">A</button>
   </div>
   <a class=""btn-default btn"" href=""#"" role=""button"">Long Link Text</a>
   <div class=""btn-group"">
    <button class=""dropdown-toggle btn-default btn"" data-toggle=""dropdown"" type=""button"">C 
     <span class=""caret""></span>
    </button>
    <ul class=""dropdown-menu"" role=""menu"">
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">D</a>
     </li>
     <li role=""presentation"">
      <a href=""#"" role=""menuitem"">E</a>
     </li>
    </ul>
   </div>
   <div class=""btn-group"">
    <button class=""btn-default btn"" type=""button"">Long Button Text</button>
   </div>
   <a class=""btn-default btn"" href=""#"" role=""button"">F</a>
  </div>");
        }
    }
}
