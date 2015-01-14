using FluentBootstrap.Images;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaObjectCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class MediaObjectWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IMediaObject : ITag
    {
    }

    public class MediaObject<TConfig> : Tag<TConfig, MediaObject<TConfig>, MediaObjectWrapper<TConfig>>, IMediaObject, IHasLinkExtensions
        where TConfig : BootstrapConfig
    {
        internal string Src { get; set; }
        internal string Alt { get; set; }
        private Image<TConfig> _image;

        internal MediaObject(BootstrapHelper helper)
            : base(helper, "a", Css.MediaLeft)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a div if no link was provided
            string href = GetAttribute("href");
            if (string.IsNullOrWhiteSpace(href))
            {
                TagName = "div";
            }

            base.OnStart(writer);

            _image = Helper.Image(Src, Alt);
            _image.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _image.Finish(writer);

            base.OnFinish(writer);
        }
    }
}
