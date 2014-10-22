using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarToggleCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarToggleWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface INavbarToggle : ITag
    {
    }

    public class NavbarToggle<TModel> : Tag<TModel, NavbarToggle<TModel>, NavbarToggleWrapper<TModel>>, INavbarToggle
    {
        internal string DataTarget { private get; set; }
        internal bool Hamburger { private get; set; }

        internal NavbarToggle(IComponentCreator<TModel> creator)
            : base(creator, "button", Css.NavbarToggle, "collapsed")
        {
            Hamburger = true;
            this.MergeAttribute("type", "button");
            this.MergeAttribute("data-toggle", "collapse");
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Set the data-target
            if (string.IsNullOrWhiteSpace(DataTarget))
            {
                // Get the Navbar ID and use it to set the data-target
                string navbarId = string.Empty;
                INavbar navbar = GetComponent<INavbar>();
                if (navbar != null)
                {
                    navbarId = navbar.GetAttribute("id");
                }
                DataTarget = "#" + navbarId + "-collapse";
            }
            this.MergeAttribute("data-target", DataTarget);

            // Make sure we're in a header, but only if we're also in a navbar
            INavbarHeader header = GetComponent<INavbarHeader>();
            if (GetComponent<INavbar>() != null && header == null)
            {
                new NavbarHeader<TModel>(Helper).Start(writer);
            }
            else if(header != null)
            {
                header.HasToggle = true;
            }

            base.OnStart(writer);

            Helper.Span(Css.SrOnly).SetText("Toggle Navigation").StartAndFinish(writer);
            if (Hamburger)
            {
                Helper.Span(Css.IconBar).StartAndFinish(writer);
                Helper.Span(Css.IconBar).StartAndFinish(writer);
                Helper.Span(Css.IconBar).StartAndFinish(writer);
            }
        }
    }
}
