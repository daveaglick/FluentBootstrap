using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaBodyCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class MediaBodyWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IMediaBody : ITag
    {
    }

    public class MediaBody<TConfig> : Tag<TConfig, MediaBody<TConfig>, MediaBodyWrapper<TConfig>>, IMediaBody, IHasTextContent
        where TConfig : BootstrapConfig
    {
        internal string Heading { get; set; }

        internal MediaBody(BootstrapHelper helper)
            : base(helper, "div", Css.MediaBody)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if(!string.IsNullOrWhiteSpace(Heading))
            {
                Helper.Heading4(Heading).StartAndFinish(writer);
            }
        }
    }
}
