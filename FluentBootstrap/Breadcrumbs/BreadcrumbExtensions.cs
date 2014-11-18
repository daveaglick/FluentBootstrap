using FluentBootstrap.Breadcrumbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class BreadcrumbExtensions
    {
        public static Breadcrumb<THelper> Breadcrumb<THelper>(this IBreadcrumbCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Breadcrumb<THelper>(creator);
        }

        public static Crumb<THelper> Crumb<THelper>(this ICrumbCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new Crumb<THelper>(creator).SetHref(href).SetText(text);
        }

        public static Crumb<THelper> SetActive<THelper>(this Crumb<THelper> crumb, bool active = true)
            where THelper : BootstrapHelper<THelper>
        {
            crumb.Active = active;
            return crumb;
        }
    }
}
