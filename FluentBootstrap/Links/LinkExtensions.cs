using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Links;
using System.Web.Mvc;
using System.Web.Routing;

namespace FluentBootstrap
{
    public static class LinkExtensions
    {
        // Link

        public static Link<THelper> Link<THelper>(this ILinkCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new Link<THelper>(creator).SetHref(href).SetText(text);
        }

        // IHasLinkExtensions

        public static TThis SetHref<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string href)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            if (string.IsNullOrWhiteSpace(href))
            {
                return component.GetThis();
            }
            return component.GetThis().MergeAttribute("href", href);
        }
    }
}
