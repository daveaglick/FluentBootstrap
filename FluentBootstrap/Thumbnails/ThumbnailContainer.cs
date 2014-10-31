using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public interface IThumbnailContainerCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ThumbnailContainerWrapper<TModel> : TagWrapper<TModel>,
        IThumbnailCreator<TModel>,
        ICaptionCreator<TModel>
    {
    }

    internal interface IThumbnailContainer : ITag
    {
    }

    public class ThumbnailContainer<TModel> : Tag<TModel, ThumbnailContainer<TModel>, ThumbnailContainerWrapper<TModel>>, IThumbnailContainer
    {
        internal ThumbnailContainer(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Thumbnail)
        {
        }
    }
}
