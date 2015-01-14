using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Pagers
{
    public class Pager : Tag,
        ICanCreate<Page>
    {
        private Element _nav = null;

        internal Pager(BootstrapHelper helper)
            : base(helper, "ul", Css.Pager)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _nav = GetHelper().Element("nav").Component;
            _nav.Start(writer);

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            _nav.Finish(writer);
        }
    }
}
