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
    public class MediaObject : Tag, IHasLinkExtensions
    {
        private Image _image;

        public string Src { get; set; }
        public string Alt { get; set; }

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

            _image = GetHelper().Image(Src, Alt).Component;
            _image.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _image.Finish(writer);

            base.OnFinish(writer);
        }
    }
}
