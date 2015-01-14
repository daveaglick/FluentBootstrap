using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Breadcrumbs
{
    public class Crumb : Tag, IHasLinkExtensions, IHasTextContent
    {
        private Element _listItem = null;

        public bool Active { get; set; }

        internal Crumb(BootstrapHelper helper)
            : base(helper, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Create the list item wrapper
            _listItem = this.GetHelper().Element("li").Component;
            if (Active)
            {
                _listItem.AddCss(Css.Active);
            }
            _listItem.Start(writer);

            base.OnStart(Active ? new SuppressOutputWriter() : writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(Active ? new SuppressOutputWriter() : writer);

            _listItem.Finish(writer);
        }
    }
}
