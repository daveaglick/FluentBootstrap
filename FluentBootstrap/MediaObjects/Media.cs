using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class MediaWrapper<TConfig> : TagWrapper<TConfig>,
        IMediaObjectCreator<TConfig>,
        IMediaBodyCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IMedia : ITag
    {
    }

    public class Media<TConfig> : Tag<TConfig, Media<TConfig>, MediaWrapper<TConfig>>, IMedia
        where TConfig : BootstrapConfig
    {
        internal Media(BootstrapHelper helper)
            : base(helper, "div", Css.Media)
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
