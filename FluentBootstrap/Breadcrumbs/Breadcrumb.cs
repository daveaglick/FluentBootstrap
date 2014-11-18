using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Breadcrumbs
{
    public interface IBreadcrumbCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class BreadcrumbWrapper<THelper> : TagWrapper<THelper>,
        ICrumbCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IBreadcrumb : ITag
    {
    }

    public class Breadcrumb<THelper> : Tag<THelper, Breadcrumb<THelper>, BreadcrumbWrapper<THelper>>, IBreadcrumb
        where THelper : BootstrapHelper<THelper>
    {
        internal Breadcrumb(IComponentCreator<THelper> creator)
            : base(creator, "ol", Css.Breadcrumb)
        {
        }
    }
}
