using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaListCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class MediaListWrapper<THelper> : TagWrapper<THelper>,
        IMediaCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IMediaList : ITag
    {
    }

    public class MediaList<THelper> : Tag<THelper, MediaList<THelper>, MediaListWrapper<THelper>>, IMediaList
        where THelper : BootstrapHelper<THelper>
    {
        internal MediaList(IComponentCreator<THelper> creator)
            : base(creator, "ul", Css.MediaList)
        {
        }
    }
}
