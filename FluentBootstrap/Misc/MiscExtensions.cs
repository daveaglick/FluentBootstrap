using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MiscExtensions
    {
        public static Element<TModel> Clearfix<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "div", Css.Clearfix);
        }

        public static Element<TModel> CenterBlock<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "div", Css.CenterBlock);
        }

        public static Element<TModel> PullLeft<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "div", Css.PullLeft);
        }

        public static Element<TModel> PullRight<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "div", Css.PullRight);
        }

        public static Element<TModel> Caret<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "span", Css.Caret);
        }

        public static Element<TModel> Close<TModel>(this ITagCreator<TModel> creator)
        {
            return new Element<TModel>(creator, "button", Css.Close)
                .AddAttribute("type", "button")
                .AddContent("<span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span>");
        }
    }
}
