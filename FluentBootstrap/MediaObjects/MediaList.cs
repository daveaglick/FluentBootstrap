using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaListCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class MediaListWrapper<TModel> : TagWrapper<TModel>,
        IMediaCreator<TModel>
    {
    }

    internal interface IMediaList : ITag
    {
    }

    public class MediaList<TModel> : Tag<TModel, MediaList<TModel>, MediaListWrapper<TModel>>, IMediaList
    {
        internal MediaList(IComponentCreator<TModel> creator)
            : base(creator, "ul", Css.MediaList)
        {
        }
    }
}
