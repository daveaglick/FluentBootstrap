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
    public interface IMediaObjectCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class MediaObjectWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IMediaObject : ITag
    {
    }

    public class MediaObject<TModel> : Tag<TModel, MediaObject<TModel>, MediaObjectWrapper<TModel>>, IMediaObject, IHasLinkExtensions
    {
        internal string Src { get; set; }
        internal string Alt { get; set; }
        private Image<TModel> _image;

        internal MediaObject(IComponentCreator<TModel> creator)
            : base(creator, "a", Css.PullLeft)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a div if no link was provided
            string href;
            if (!TagBuilder.Attributes.TryGetValue("href", out href) || string.IsNullOrWhiteSpace(href))
            {
                TagName = "div";
            }

            base.OnStart(writer);

            _image = Helper.Image(Src, Alt).AddCss(Css.MediaObject);
            _image.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _image.Finish(writer);

            base.OnFinish(writer);
        }
    }
}
