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

        public static ComponentBuilder<TConfig, Jumbotron> Jumbotron<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Jumbotron>
        {
            return new ComponentBuilder<TConfig, Jumbotron>(helper.Config, new Jumbotron(helper));
        }

        // PageHeader

        public static ComponentBuilder<TConfig, PageHeader> PageHeader<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<PageHeader>
        {
            return new ComponentBuilder<TConfig, PageHeader>(helper.Config, new PageHeader(helper))
                .SetText(text);
        }

        // Elements

        public static ComponentBuilder<TConfig, Element> Clearfix<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "div"))
                .AddCss(Css.Clearfix);
        }

        public static ComponentBuilder<TConfig, Element> CenterBlock<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "div"))
                .AddCss(Css.CenterBlock);
        }

        public static ComponentBuilder<TConfig, Element> PullLeft<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "div"))
                .AddCss(Css.PullLeft);
        }

        public static ComponentBuilder<TConfig, Element> PullRight<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "div"))
                .AddCss(Css.PullRight);
        }

        public static ComponentBuilder<TConfig, Element> Caret<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "span"))
                .AddCss(Css.Caret);
        }

        public static ComponentBuilder<TConfig, Element> Close<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "button"))
                .AddCss(Css.Close)
                .AddAttribute("type", "button")
                .AddContent("<span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span>");
        }
    }
}
