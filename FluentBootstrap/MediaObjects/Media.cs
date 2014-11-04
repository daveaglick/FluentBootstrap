using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class MediaWrapper<TModel> : TagWrapper<TModel>,
        IMediaObjectCreator<TModel>,
        IMediaBodyCreator<TModel>
    {
    }

    internal interface IMedia : ITag
    {
    }

    public class Media<TModel> : Tag<TModel, Media<TModel>, MediaWrapper<TModel>>, IMedia
    {
        internal Media(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Media)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a list item if inside a MediaList
            if(GetComponent<IMediaList>(true) != null)
            {
                TagName = "li";
            }

            base.OnStart(writer);
        }
    }
}
