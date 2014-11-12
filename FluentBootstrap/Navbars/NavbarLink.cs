using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarLinkCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarLinkWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarLink : ITag
    {
    }

    public class NavbarLink<THelper> : Tag<THelper, NavbarLink<THelper>, NavbarLinkWrapper<THelper>>, INavbarLink, IHasLinkExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal bool Active { get; set; }
        internal bool Disabled { get; set; }
        private Element<THelper> _listItem = null;

        internal NavbarLink(IComponentCreator<THelper> creator)
            : base(creator, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Check if we're in a navbar, and if so, make sure we're in a navbar nav
            if (GetComponent<INavbar>() != null && GetComponent<INavbarNav>() == null)
            {
                new NavbarNav<THelper>(Helper).Start(writer);
            }

            // Create the list item wrapper
            _listItem = new Element<THelper>(Helper, "li");
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
