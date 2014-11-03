using FluentBootstrap.Html;
using FluentBootstrap.Labels;
using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Misc
{
    public interface IPageHeaderCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PageHeaderWrapper<TModel> : HeadingWrapper<TModel>
    {
    }

    internal interface IPageHeader : IHeading
    {
    }

    public class PageHeader<TModel> : Heading<TModel, PageHeader<TModel>, PageHeaderWrapper<TModel>>, IPageHeader, IHasTextContent
    {
        private Element<TModel> _wrapper;

        internal PageHeader(IComponentCreator<TModel> creator)
            : base(creator, "h1")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _wrapper = new Element<TModel>(Helper, "div", Css.PageHeader);
            _wrapper.Start(writer);
            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);
            _wrapper.Finish(writer);
        }
    }
}
