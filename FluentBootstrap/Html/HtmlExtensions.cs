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
        public static ComponentBuilder<THelper, Element> Element<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, string name)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<THelper, Element>(creator.Helper, new Element(creator, name));
        }

        public static ComponentBuilder<THelper, Element> Div<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<THelper, Element>(creator.Helper, new Element(creator, "div")).SetText(text);
        }

        public static ComponentBuilder<THelper, Element> Span<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<THelper, Element>(creator.Helper, new Element(creator, "span")).SetText(text);
        }

        public static ComponentBuilder<THelper, Paragraph> Paragraph<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Paragraph>
        {
            return new ComponentBuilder<THelper, Paragraph>(creator.Helper, new Paragraph(creator)).SetText(text);
        }

        public static ComponentBuilder<THelper, Element> Strong<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<THelper, Element>(creator.Helper, new Element(creator, "strong")).SetText(text);
        }
    }
}
