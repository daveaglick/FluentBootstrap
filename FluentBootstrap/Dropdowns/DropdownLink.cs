using System.IO;
using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public class DropdownLink : Tag, IHasLinkExtensions, IHasTextContent
    {
        private Element _listItem = null;

        public bool Disabled { get; set; }
        public bool Active { get; set; }
        
        internal DropdownLink(BootstrapHelper helper)
            : base(helper, "a")
        {
            MergeAttribute("role", "menuitem");
        }

        protected override void OnStart(TextWriter writer)
        {
            _listItem = GetHelper().Element("li").Component;
            _listItem.MergeAttribute("role", "presentation");
            if(Disabled)
            {
                _listItem.AddCss(Css.Disabled);
            }
            if (Active)
            {
                _listItem.AddCss(Css.Active);
            }
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
