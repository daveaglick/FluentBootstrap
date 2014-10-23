using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Breadcrumbs
{
    public interface IBreadcrumbCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class BreadcrumbWrapper<TModel> : TagWrapper<TModel>,
        ICrumbCreator<TModel>
    {
    }

    internal interface IBreadcrumb : ITag
    {
    }

    public class Breadcrumb<TModel> : Tag<TModel, Breadcrumb<TModel>, BreadcrumbWrapper<TModel>>, IBreadcrumb
    {
        internal Breadcrumb(IComponentCreator<TModel> creator)
            : base(creator, "ol", Css.Breadcrumb)
        {
        }
    }
}
