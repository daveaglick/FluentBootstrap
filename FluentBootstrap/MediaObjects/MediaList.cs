using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaListCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class MediaListWrapper<TConfig> : TagWrapper<TConfig>,
        IMediaCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IMediaList : ITag
    {
    }

    public class MediaList<TConfig> : Tag<TConfig, MediaList<TConfig>, MediaListWrapper<TConfig>>, IMediaList
        where TConfig : BootstrapConfig
    {
        internal MediaList(BootstrapHelper helper)
            : base(helper, "ul", Css.MediaList)
        {
        }
    }
}
