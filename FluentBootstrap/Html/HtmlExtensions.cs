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
        public static Element<TModel> Element<TModel>(this ITagCreator<TModel> creator, string name)
        {
            return new Element<TModel>(creator, name);
        }

        public static Element<TModel> Div<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "div");
        }

        public static Element<TModel> Span<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "span");
        }

        public static Element<TModel> Paragraph<TModel>(this ITagCreator<TModel> creator, string text = null)
        {
            return new Element<TModel>(creator, "p").SetText(text);
        }
    }
}
