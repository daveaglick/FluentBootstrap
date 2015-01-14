using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Paginations
{
    public class Pagination : Tag,
        ICanCreate<PageNum>
    {
        private Element _nav = null;

        public int AutoPageNumber { get; set; }

        internal Pagination(BootstrapHelper helper)
            : base(helper, "ul", Css.Pagination)
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
