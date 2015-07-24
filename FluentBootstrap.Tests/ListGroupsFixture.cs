using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class ListGroupsFixture
    {
        [Test]
        public void BasicListGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-basic",
@"<div class=""list-group"">
   <div class=""list-group-item"">Item one</div>
   <div class=""list-group-item"">Item two</div>
   <div class=""list-group-item"">Item three</div>
  </div>");
        }

        [Test]
        public void ListGroupBadgesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-badges",
@"<div class=""list-group"">
   <div class=""list-group-item"">Item one
    <span class=""badge"">14</span>
   </div>
   <div class=""list-group-item"">Item two
    <span class=""badge"">Great!</span>
   </div>
  </div>");
        }

        [Test]
        public void ListGroupLinksProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-links",
@"<div class=""list-group"">
   <a href=""#"" class=""list-group-item"">Item one</a>
   <a href=""#"" class=""list-group-item"">Item two</a>
  </div>");
        }

        [Test]
        public void ListGroupButtonsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-buttons",
@"<div class=""list-group"">
   <button type=""button"" class=""list-group-item"">A</button>
   <button type=""button"" value=""foo"" class=""list-group-item"">B</button>
   <button type=""button"" class=""list-group-item"">
    <span class=""glyphicon glyphicon-check""></span> C
   </button>
   <div class=""list-group-item"">Normal item</div>
   <button type=""button"" disabled=""disabled"" class=""list-group-item"">D</button>
   <button type=""button"" class=""list-group-item"">E
    <span class=""badge"">Badge!</span>
   </button>
  </div>");
        }

        [Test]
        public void ActiveAndDisabledListGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-active-disabled",
@"<div class=""list-group"">
   <a href=""#"" class=""list-group-item active"">Item one</a>
   <a href=""#"" class=""list-group-item disabled"">Item two</a>
   <a href=""#"" class=""list-group-item"">Item three</a>
  </div>");
        }

        [Test]
        public void ListGroupStatesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-state",
@"<div class=""list-group"">
   <div class=""list-group-item list-group-item-success"">Success</div>
   <div class=""list-group-item list-group-item-info"">Info</div>
   <div class=""list-group-item list-group-item-warning"">Warning</div>
   <div class=""list-group-item list-group-item-danger"">Danger</div>
   <a href=""#"" class=""list-group-item list-group-item-success"">Success</a>
   <a href=""#"" class=""list-group-item list-group-item-info"">Info</a>
   <a href=""#"" class=""list-group-item list-group-item-warning"">Warning</a>
   <a href=""#"" class=""list-group-item list-group-item-danger"">Danger</a>
  </div>");
        }

        [Test]
        public void ImplicitCustomListGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-implicit-custom",
@"<div class=""list-group"">
   <a href=""#"" class=""list-group-item"">
    <h4 class=""list-group-item-heading"">Heading</h4>
    <p class=""list-group-item-text"">Some text.</p>
   </a>
   <div class=""list-group-item"">
    <h4 class=""list-group-item-heading"">Heading</h4>
    <p class=""list-group-item-text"">Some text.</p>
   </div>
  </div>");
        }

        [Test]
        public void ExplicitCustomListGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ListGroups_cshtml>("test-explicit-custom",
@"<div class=""list-group"">
   <div class=""list-group-item"">
    <h3 class=""list-group-item-heading"">Heading</h3>
    <p class=""list-group-item-text"">                    Some text.
</p>
   </div>
   <a href=""#"" class=""list-group-item"">
    <h5 class=""list-group-item-heading"">Heading</h5>
    <p class=""list-group-item-text"">                    Some text.
</p>
   </a>
  </div>");
        }
    }
}
