using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class MediaObjectsFixture
    {
        [Test]
        public void DefaultMediaObjectsProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.MediaObjects>("test-default",
@"<div class=""media"">
   <a class=""media-left"" href=""#"">
    <img src=""http://placehold.it/64x64"">
   </a>
   <div class=""media-body"">
    <h4 class=""media-heading"">Media With Link</h4>                Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.

   </div>
  </div>
  <div class=""media"">
   <div class=""media-left"">
    <img src=""http://placehold.it/64x64"">
   </div>
   <div class=""media-body"">
    <h4 class=""media-heading"">Media Without Link</h4>Text content.
   </div>
  </div>");
        }

        [Test]
        public void RightMediaObjectProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.MediaObjects>("test-right",
@"<div class=""media"">
   <div class=""media-body"">
    <h4 class=""media-heading"">Media</h4>                Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.

   </div>
   <a class=""media-right"" href=""#"">
    <img src=""http://placehold.it/64x64"">
   </a>
  </div>");
        }

        [Test]
        public void ExplicitHeadingMediaObjectProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.MediaObjects>("test-explicit-heading",
@"<div class=""media"">
   <a class=""media-left"" href=""#"">
    <img src=""http://placehold.it/64x64"">
   </a>
   <div class=""media-body"">
    <h4 class=""media-heading"">Heading</h4>                Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.

   </div>
  </div>");
        }

        [Test]
        public void NestedMediaObjectsProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.MediaObjects>("test-nested",
@"<div class=""media"">
   <a class=""media-left"" href=""#"">
    <img src=""http://placehold.it/64x64"">
   </a>
   <div class=""media-body"">
    <h3 class=""media-heading"">Heading</h3>                Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.

    <div class=""media"">
     <a class=""media-left"" href=""#"">
      <img src=""http://placehold.it/64x64"">
     </a>
     <div class=""media-body"">
      <h4 class=""media-heading"">Heading</h4>                        Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.

     </div>
    </div>
   </div>
  </div>");
        }

        [Test]
        public void MediaObjectListProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.MediaObjects>("test-list",
@"<ul class=""media-list"">
   <li class=""media"">
    <a class=""media-left"" href=""#"">
     <img src=""http://placehold.it/64x64"">
    </a>
    <div class=""media-body"">
     <h4 class=""media-heading"">Heading</h4>Text content.
    </div>
   </li>
   <li class=""media"">
    <a class=""media-left"" href=""#"">
     <img src=""http://placehold.it/64x64"">
    </a>
    <div class=""media-body"">
     <h4 class=""media-heading"">Heading</h4>Text content.
     <div class=""media"">
      <a class=""media-left"" href=""#"">
       <img src=""http://placehold.it/64x64"">
      </a>
      <div class=""media-body"">
       <h4 class=""media-heading"">Nested Heading</h4>Text content.
      </div>
     </div>
    </div>
   </li>
  </ul>");
        }
    }
}
