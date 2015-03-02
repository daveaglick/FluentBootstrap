using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentBootstrap.Links;

namespace FluentBootstrap.Images
{
    public class Placeholder : ImageBase
    {
        public int Width { get; set; }
        public int? Height { get; set; }
        public string Text { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public string Format { get; set; }

        internal Placeholder(BootstrapHelper helper, int width, int? height = null) 
            : base(helper)
        {
            OutputEndTag = false;
            Width = width;
            Height = height;
        }

        protected override void OnStart(TextWriter writer)
        {
            // Build the src
            StringBuilder src = new StringBuilder("http://placehold.it/" + Width.ToString());
            if (Height != null)
            {
                src.Append("x" + Height.ToString());
            }
            if (!string.IsNullOrWhiteSpace(BackgroundColor))
            {
                src.Append("/" + BackgroundColor.Replace("#", ""));
                if(!string.IsNullOrWhiteSpace(TextColor))
                {
                    src.Append("/" + TextColor.Replace("#", ""));
                }
            } 
            else if(!string.IsNullOrWhiteSpace(TextColor))
            {
                throw new InvalidOperationException("BackgroundColor must be specified if TextColor is specified.");
            }
            if(!string.IsNullOrWhiteSpace(Format))
            {
                src.Append("." + Format);
            }
            if(!string.IsNullOrWhiteSpace(Text))
            {
                src.Append("&text=" + Text.Replace(' ', '+'));
            }
            MergeAttribute("src", src.ToString());

            base.OnStart(writer);
        }
    }
}
