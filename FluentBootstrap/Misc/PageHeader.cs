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
    public interface IPageHeaderCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PageHeaderWrapper<THelper> : HeadingWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPageHeader : IHeading
    {
    }

    public class PageHeader<THelper> : Heading<THelper, PageHeader<THelper>, PageHeaderWrapper<THelper>>, IPageHeader, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        private Element<THelper> _wrapper;

        internal PageHeader(IComponentCreator<THelper> creator)
            : base(creator, "h1")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _wrapper = new Element<THelper>(Helper, "div").AddCss(Css.PageHeader);
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
