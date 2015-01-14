using FluentBootstrap.Html;
using FluentBootstrap.Images;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public interface IThumbnailCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class ThumbnailWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IThumbnail : ITag
    {
    }

    public class Thumbnail<TConfig> : Tag<TConfig, Thumbnail<TConfig>, ThumbnailWrapper<TConfig>>, IThumbnail, IHasLinkExtensions
        where TConfig : BootstrapConfig
    {
        internal string Src { get; set; }
        internal string Alt { get; set; }
        private Image<TConfig> _image;
        private bool _suppressOuterTag;

        internal Thumbnail(BootstrapHelper helper)
            : base(helper, "a", Css.Thumbnail)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Remove the thumbnail class if in a ThumbnailContainer
            bool inContainer = false;
            if(GetComponent<IThumbnailContainer>(true) != null)
            {
                this.RemoveCss(Css.Thumbnail);
                inContainer = true;
            }

            // Change to a div if no link was provided (or don't output at all if in a container)
            string href = GetAttribute("href");
            if(string.IsNullOrWhiteSpace(href))
            {
                TagName = "div";
                if(inContainer)
                {
                    _suppressOuterTag = true;
                }
            }

            base.OnStart(_suppressOuterTag ? new SuppressOutputWriter() : writer);

            _image = Helper.Image(Src, Alt);
            _image.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _image.Finish(writer);

            base.OnFinish(_suppressOuterTag ? new SuppressOutputWriter() : writer);
        }
    }
}
