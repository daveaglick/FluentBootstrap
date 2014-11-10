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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ListGroups>("test-basic",
@"<div class=""list-group"">
   <div class=""list-group-item"">Item one</div>
   <div class=""list-group-item"">Item two</div>
   <div class=""list-group-item"">Item three</div>
  </div>");
        }

        [Test]
        public void ListGroupBadgesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ListGroups>("test-badges",
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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ListGroups>("test-links",
@"<div class=""list-group"">
   <a class=""list-group-item"" href=""#"">Item one</a>
   <a class=""list-group-item"" href=""#"">Item two</a>
  </div>");
        }

        [Test]
        public void ActiveAndDisabledListGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ListGroups>("test-active-disabled",
@"<div class=""list-group"">
   <a class=""active list-group-item"" href=""#"">Item one</a>
   <a class=""disabled list-group-item"" href=""#"">Item two</a>
   <a class=""list-group-item"" href=""#"">Item three</a>
  </div>");
        }

        [Test]
        public void ListGroupStatesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ListGroups>("test-state",
@"<div class=""list-group"">
   <div class=""list-group-item-success list-group-item"">Success</div>
   <div class=""list-group-item-info list-group-item"">Info</div>
   <div class=""list-group-item-warning list-group-item"">Warning</div>
   <div class=""list-group-item-danger list-group-item"">Danger</div>
   <a class=""list-group-item-success list-group-item"" href=""#"">Success</a>
   <a class=""list-group-item-info list-group-item"" href=""#"">Info</a>
   <a class=""list-group-item-warning list-group-item"" href=""#"">Warning</a>
   <a class=""list-group-item-danger list-group-item"" href=""#"">Danger</a>
  </div>");
        }

        [Test]
        public void ImplicitCustomListGroupProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ListGroups>("test-implicit-custom",
@"<div class=""list-group"">
   <a class=""list-group-item"" href=""#"">
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
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ListGroups>("test-explicit-custom",
@"<div class=""list-group"">
   <div class=""list-group-item"">
    <h3 class=""list-group-item-heading"">Heading</h3>
    <p class=""list-group-item-text"">                    Some text.
</p>
   </div>
   <a class=""list-group-item"" href=""#"">
    <h5 class=""list-group-item-heading"">Heading</h5>
    <p class=""list-group-item-text"">                    Some text.
</p>
   </a>
  </div>");
        }
    }
}
