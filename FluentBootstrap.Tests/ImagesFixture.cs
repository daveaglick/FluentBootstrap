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
    public class ImagesFixture
    {
        [Test]
        public void ImagesProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Images_cshtml>("test-images",
@"<img src=""http://placehold.it/64x64"">
  <img alt=""With Alt"" src=""http://placehold.it/64x64"">");
        }

        [Test]
        public void ImageLinksProduceCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Images_cshtml>("test-image-links",
@"<a href=""http://www.google.com""><img alt=""Alt"" src=""http://placehold.it/64x64""></a>");
        }

        [Test]
        public void PlaceholderProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_Images_cshtml>("test-placeholder",
@"<a href=""http://www.google.com""><img src=""http://placehold.it/200x40/800000/CC0000&amp;text=Placeholder!"" alt=""This is my placeholder""></a>");
        }
    }
}
