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
    public interface IPageHeaderCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PageHeaderWrapper<TConfig> : HeadingWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPageHeader : IHeading
    {
    }

    public class PageHeader<TConfig> : Heading<TConfig, PageHeader<TConfig>, PageHeaderWrapper<TConfig>>, IPageHeader, IHasTextContent
        where TConfig : BootstrapConfig
    {
        private Element<TConfig> _wrapper;

        internal PageHeader(BootstrapHelper helper)
            : base(helper, "h1")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _wrapper = new Element<TConfig>(Helper, "div").AddCss(Css.PageHeader);
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
