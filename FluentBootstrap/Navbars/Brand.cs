using FluentBootstrap.Icons;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public class Brand : Tag, IHasIconExtensions, IHasLinkExtensions, IHasTextContent
    {
        internal Brand(BootstrapHelper helper)
            : base(helper, "a", Css.NavbarBrand)
        {
        }
        
        protected override void OnStart(System.IO.TextWriter writer)
        {
            // Make sure we're in a header, but only if we're also in a navbar
            if (GetComponent<Navbar>() != null && GetComponent<NavbarHeader>() == null)
            {
                GetHelper().NavbarHeader().Component.Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
