using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    // Extensions for very general HTML elements
    public static class HtmlExtensions
    {
        public static Element<THelper> Element<THelper>(this ITagCreator<THelper> creator, string name)
            where THelper : BootstrapHelper<THelper>
        {
            return new Element<THelper>(creator, name);
        }

        public static Element<THelper> Div<THelper>(this ITagCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Element<THelper>(creator, "div");
        }

        public static Element<THelper> Span<THelper>(this ITagCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Element<THelper>(creator, "span");
        }

        public static Paragraph<THelper> Paragraph<THelper>(this IParagraphCreator<THelper> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new Paragraph<THelper>(creator).SetText(text);
        }
    }
}
