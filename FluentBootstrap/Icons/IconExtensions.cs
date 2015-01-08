using FluentBootstrap.Html;
using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class IconExtensions
    {
        public static ComponentBuilder<IconSpan> Icon<TComponent>(this IComponentCreator<TComponent> creator, Icon icon)
            where TComponent : Component, ICanCreate<IconSpan>
        {
            return new ComponentBuilder<IconSpan>(creator.Helper, new IconSpan(creator, icon));
        }

        // IHasIconExtensions

        public static ComponentBuilder<TTag> SetIcon<TTag>(this ComponentBuilder<TTag> builder, Icon icon)
            where TTag : Tag, IHasIconExtensions
        {
            if (icon != FluentBootstrap.Icon.None)
            {
                builder.Component.AddChild(builder.Helper.Icon(icon));
                builder.Component.AddChild(builder.Helper.Content(" ")); // Add a space to give a little separation to the icon
            }
            return builder;
        }
    }
}
