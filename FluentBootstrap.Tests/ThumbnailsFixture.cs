using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class ThumbnailsFixture
    {
        [Test]
        public void StandardThumbnailsProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Thumbnails_cshtml>("test-standard",
@"<div class=""row"">
   <div class=""col-md-4"">
    <a href=""#"" class=""thumbnail"">
     <img src=""http://placehold.it/400x400"">
    </a>
   </div>
   <div class=""col-md-4"">
    <a href=""#"" class=""thumbnail"">
     <img src=""http://placehold.it/400x400"">
    </a>
   </div>
   <div class=""col-md-4"">
    <div class=""thumbnail"">
     <img src=""http://placehold.it/400x400"">
    </div>
   </div>
  </div>");
        }

        [Test]
        public void ThumbnailContainersProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Thumbnails_cshtml>("test-container",
@"<div class=""row"">
   <div class=""col-md-3"">
    <div class=""thumbnail"">
     <a href=""#"">
      <img src=""http://placehold.it/400x400"">
     </a>
    </div>
   </div>
   <div class=""col-md-3"">
    <div class=""thumbnail"">
     <img src=""http://placehold.it/400x400"">
    </div>
   </div>
   <div class=""col-md-3"">
    <div class=""thumbnail"">
     <a href=""#"">
      <img src=""http://placehold.it/400x400"">
     </a>
     <div class=""caption"">
      <h3>Heading</h3>
      <p>Caption goes here.</p>
     </div>
    </div>
   </div>
   <div class=""col-md-3"">
    <div class=""thumbnail"">
     <img src=""http://placehold.it/400x400"">
     <div class=""caption"">
      <h3>Heading</h3>
      <p>Caption goes here.</p>
     </div>
    </div>
   </div>
  </div>");
        }
    }
}
