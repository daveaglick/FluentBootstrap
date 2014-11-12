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
    public interface IThumbnailCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ThumbnailWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IThumbnail : ITag
    {
    }

    public class Thumbnail<THelper> : Tag<THelper, Thumbnail<THelper>, ThumbnailWrapper<THelper>>, IThumbnail, IHasLinkExtensions
        where THelper : BootstrapHelper<THelper>
    {
        internal string Src { get; set; }
        internal string Alt { get; set; }
        private Image<THelper> _image;
        private bool _suppressOuterTag;

        internal Thumbnail(IComponentCreator<THelper> creator)
            : base(creator, "a", Css.Thumbnail)
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
            string href;
            if(!TagBuilder.Attributes.TryGetValue("href", out href) || string.IsNullOrWhiteSpace(href))
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
