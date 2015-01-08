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
        public static ComponentBuilder<Element> Element<TComponent>(this IComponentCreator<TComponent> creator, string name)
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<Element>(creator.Helper, new Element(creator, name));
        }

        public static ComponentBuilder<Element> Div<TComponent>(this IComponentCreator<TComponent> creator, string text = null)
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<Element>(creator.Helper, new Element(creator, "div")).SetText(text);
        }

        public static ComponentBuilder<Element> Span<TComponent>(this IComponentCreator<TComponent> creator, string text = null)
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<Element>(creator.Helper, new Element(creator, "span")).SetText(text);
        }

        public static ComponentBuilder<Paragraph> Paragraph<TComponent>(this IComponentCreator<TComponent> creator, string text = null)
            where TComponent : Component, ICanCreate<Paragraph>
        {
            return new ComponentBuilder<Paragraph>(creator.Helper, new Paragraph(creator)).SetText(text);
        }

        public static ComponentBuilder<Element> Strong<TComponent>(this IComponentCreator<TComponent> creator, string text = null)
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<Element>(creator.Helper, new Element(creator, "strong")).SetText(text);
        }
    }
}
