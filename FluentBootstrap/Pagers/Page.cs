using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Pagers
{
    public class Page : Tag, IHasLinkExtensions, IHasTextContent
    {
        private Element _listItem = null;

        public bool Disabled { get; set; }
        public PageAlignment Alignment { get; set; }

        internal Page(BootstrapHelper helper)
            : base(helper, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Create the list item wrapper
            _listItem = GetHelper().Element("li").Component;
            if (Disabled)
            {
                _listItem.AddCss(Css.Disabled);
            }
            _listItem.ToggleCss(Alignment);
            _listItem.Start(writer);

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            _listItem.Finish(writer);
        }
    }
}
