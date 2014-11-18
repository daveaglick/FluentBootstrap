using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public interface IThumbnailContainerCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ThumbnailContainerWrapper<THelper> : TagWrapper<THelper>,
        IThumbnailCreator<THelper>,
        ICaptionCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IThumbnailContainer : ITag
    {
    }

    public class ThumbnailContainer<THelper> : Tag<THelper, ThumbnailContainer<THelper>, ThumbnailContainerWrapper<THelper>>, IThumbnailContainer
        where THelper : BootstrapHelper<THelper>
    {
        internal ThumbnailContainer(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Thumbnail)
        {
        }
    }
}
