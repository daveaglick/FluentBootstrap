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
        public static IconSpan<TModel> Icon<TModel>(this ITagCreator<TModel> creator, Icon icon)
        {
            return new IconSpan<TModel>(creator.GetHelper(), icon);
        }

        // IHasIcon

        public static TThis Icon<TModel, TThis>(this Component<TModel, TThis> component, Icon icon)
            where TThis : Tag<TModel, TThis>, IHasIcon
        {
            TThis tag = component.GetThis();
            if (icon != FluentBootstrap.Icon.None)
            {
                tag.AddChild(component.GetHelper().Icon(icon));
                tag.AddContent(" ");    // Add a space to give a little separation to the icon
            }
            return tag;
        }
    }
}
