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
    public interface INavbarLinkCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarLinkWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface INavbarLink : ITag
    {
    }

    public class NavbarLink<TModel> : Tag<TModel, NavbarLink<TModel>, NavbarLinkWrapper<TModel>>, INavbarLink, IHasLinkExtensions, IHasTextContent
    {
        internal bool Active { private get; set; }
        internal bool Disabled { private get; set; }
        private Element<TModel> _listItem = null;

        internal NavbarLink(IComponentCreator<TModel> creator)
            : base(creator, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Check if we're in a navbar, and if so, make sure we're in a navbar nav
            if (GetComponent<INavbar>() != null && GetComponent<INavbarNav>() == null)
            {
                new NavbarNav<TModel>(Helper).Start(writer);
            }

            // Create the list item wrapper
            _listItem = new Element<TModel>(Helper, "li");
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
