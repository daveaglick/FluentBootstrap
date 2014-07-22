using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class HtmlExtensions
    {
        public static Element<TModel> Element<TModel>(this ITagCreator<TModel> creator, string name, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), name, cssClasses);
        }

        public static Element<TModel> Div<TModel>(this ITagCreator<TModel> creator, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "div", cssClasses);
        }

        public static Element<TModel> Span<TModel>(this ITagCreator<TModel> creator, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "span", cssClasses);
        }

        public static Element<TModel> Paragraph<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "p", cssClasses).Text(text);
        }
    }
}
