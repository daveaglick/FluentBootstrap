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
        public static ComponentBuilder<TConfig, Element> Element<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, name));
        }

        public static ComponentBuilder<TConfig, Element> Div<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "div")).SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Span<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "span")).SetText(text);
        }

        public static ComponentBuilder<TConfig, Paragraph> Paragraph<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Paragraph>
        {
            return new ComponentBuilder<TConfig, Paragraph>(helper.Config, new Paragraph(helper)).SetText(text);
        }
    }
}
