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
    public interface ILinkCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class LinkWrapper<TModel> : TagWrapper<TModel>,
        IBadgeCreator<TModel>
    {
    }

    internal interface ILink : ITag
    {
    }

    public class Link<TModel> : Tag<TModel, Link<TModel>, LinkWrapper<TModel>>, ILink, IHasIconExtensions, IHasLinkExtensions, IHasTextAttribute
    {
        internal Link(IComponentCreator<TModel> creator)
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

            base.OnStart(writer);
        }
    }
}
