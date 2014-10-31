using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Images
{
    public interface IImageCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ImageWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IImage : ITag
    {
    }

    public class Image<TModel> : Tag<TModel, Image<TModel>, ImageWrapper<TModel>>, IImage
    {
        internal Image(IComponentCreator<TModel> creator)
            : base(creator, "img")
        {
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
