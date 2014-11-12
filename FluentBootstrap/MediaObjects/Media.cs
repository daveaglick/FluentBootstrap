using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class MediaWrapper<THelper> : TagWrapper<THelper>,
        IMediaObjectCreator<THelper>,
        IMediaBodyCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IMedia : ITag
    {
    }

    public class Media<THelper> : Tag<THelper, Media<THelper>, MediaWrapper<THelper>>, IMedia
        where THelper : BootstrapHelper<THelper>
    {
        internal Media(IComponentCreator<THelper> creator)
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
