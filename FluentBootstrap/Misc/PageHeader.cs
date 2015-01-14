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
    public class PageHeader : Heading, IHasTextContent
    {
        private Element _wrapper;

        internal PageHeader(BootstrapHelper helper)
            : base(helper, "h1")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _wrapper = GetHelper().Element("div").AddCss(Css.PageHeader).Component;
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
