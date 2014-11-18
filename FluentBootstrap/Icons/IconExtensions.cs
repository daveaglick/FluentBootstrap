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
        public static IconSpan<THelper> Icon<THelper>(this ITagCreator<THelper> creator, Icon icon)
            where THelper : BootstrapHelper<THelper>
        {
            return new IconSpan<THelper>(creator, icon);
        }

        // IHasIconExtensions

        public static TThis SetIcon<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, Icon icon)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasIconExtensions
            where TWrapper : TagWrapper<THelper>, new()
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
