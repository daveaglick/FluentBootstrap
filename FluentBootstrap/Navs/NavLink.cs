using FluentBootstrap.Badges;
using FluentBootstrap.Html;
using FluentBootstrap.Links;
using FluentBootstrap.Navbars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public abstract class NavLink : Tag, IHasLinkExtensions, IHasTextContent,
        ICanCreate<Badge>
    {
        private Element _listItem = null;

        public bool Active { get; set; }
        public bool Disabled { get; set; }

        protected NavLink(BootstrapHelper helper)
            : base(helper, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Check if we're in a navbar, and if so, make sure we're in a navbar nav
            if (GetComponent<Navbar>() != null && GetComponent<NavbarNav>() == null)
            {
                GetHelper().NavbarNav().Component.Start(writer);
            }

            // Create the list item wrapper
            _listItem = GetHelper().Element("li").Component;
            if (Active)
            {
                _listItem.AddCss(Css.Active);
            }
            if (Disabled)
            {
                _listItem.AddCss(Css.Disabled);
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
