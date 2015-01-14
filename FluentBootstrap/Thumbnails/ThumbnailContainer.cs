using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public interface IThumbnailContainerCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class ThumbnailContainerWrapper<TConfig> : TagWrapper<TConfig>,
        IThumbnailCreator<TConfig>,
        ICaptionCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IThumbnailContainer : ITag
    {
    }

    public class ThumbnailContainer<TConfig> : Tag<TConfig, ThumbnailContainer<TConfig>, ThumbnailContainerWrapper<TConfig>>, IThumbnailContainer
        where TConfig : BootstrapConfig
    {
        internal ThumbnailContainer(BootstrapHelper helper)
            : base(helper, "div", Css.Thumbnail)
        {
        }
    }
}
