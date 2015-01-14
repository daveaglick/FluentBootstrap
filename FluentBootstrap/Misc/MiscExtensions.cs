using FluentBootstrap.Html;
using FluentBootstrap.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MiscExtensions
    {
        // Jumbotron

        public static Jumbotron<TConfig> Jumbotron<TConfig>(this IJumbotronCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Jumbotron<TConfig>(creator);
        }

        // PageHeader

        public static PageHeader<TConfig> PageHeader<TConfig>(this IPageHeaderCreator<TConfig> creator, string text = null)
            where TConfig : BootstrapConfig
        {
            return new PageHeader<TConfig>(creator).SetText(text);
        }

        // Elements

        public static Element<TConfig> Clearfix<TConfig>(this ITagCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Element<TConfig>(creator, "div").AddCss(Css.Clearfix);
        }

        public static Element<TConfig> CenterBlock<TConfig>(this ITagCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Element<TConfig>(creator, "div").AddCss(Css.CenterBlock);
        }

        public static Element<TConfig> PullLeft<TConfig>(this ITagCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Element<TConfig>(creator, "div").AddCss(Css.PullLeft);
        }

        public static Element<TConfig> PullRight<TConfig>(this ITagCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Element<TConfig>(creator, "div").AddCss(Css.PullRight);
        }

        public static Element<TConfig> Caret<TConfig>(this ITagCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Element<TConfig>(creator, "span").AddCss(Css.Caret);
        }

        public static Element<TConfig> Close<TConfig>(this ITagCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Element<TConfig>(creator, "button").AddCss(Css.Close)
                .AddAttribute("type", "button")
                .AddContent("<span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span>");
        }
    }
}
