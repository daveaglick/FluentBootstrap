using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Images
{
    public interface IImageCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ImageWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IImage : ITag
    {
    }

    public class Image<THelper> : Tag<THelper, Image<THelper>, ImageWrapper<THelper>>, IImage
        where THelper : BootstrapHelper<THelper>
    {
        internal Image(IComponentCreator<THelper> creator)
            : base(creator, "img")
        {
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
