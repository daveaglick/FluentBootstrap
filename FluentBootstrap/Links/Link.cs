using FluentBootstrap.Alerts;
using FluentBootstrap.Badges;
using FluentBootstrap.Forms;
using FluentBootstrap.Icons;
using FluentBootstrap.Navbars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Links
{
    public interface ILinkCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class LinkWrapper<THelper> : TagWrapper<THelper>,
        IBadgeCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ILink : ITag
    {
    }

    public class Link<THelper> : Tag<THelper, Link<THelper>, LinkWrapper<THelper>>, ILink, IHasIconExtensions, IHasLinkExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal Link(IComponentCreator<THelper> creator)
            : base(creator, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Adjust the link style if we're in a navbar
            if(GetComponent<INavbar>() != null)
            {
                CssClasses.Add(Css.NavbarLink);
            }

            // Adjust the link style if we're in an alert
            if(GetComponent<IAlert>() != null)
            {
                CssClasses.Add(Css.AlertLink);
            }

            base.OnStart(writer);
        }
    }
}
