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
            return new IconSpan<TModel>(creator, icon);
        }

        // IHasIconExtensions

        public static TThis SetIcon<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, Icon icon)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasIconExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            if (icon != FluentBootstrap.Icon.None)
            {
                tag.AddChild(component.Helper.Icon(icon));
                tag.AddContent(" ");    // Add a space to give a little separation to the icon
            }
            return tag;
        }
    }
}
