using FluentBootstrap.Icons;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface IBrandCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class BrandWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IBrand : ITag
    {
    }

    public class Brand<THelper> : Tag<THelper, Brand<THelper>, BrandWrapper<THelper>>, IBrand, IHasIconExtensions, IHasLinkExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal Brand(IComponentCreator<THelper> creator)
            : base(creator, "a", Css.NavbarBrand)
        {
        }
        
        protected override void OnStart(System.IO.TextWriter writer)
        {
            // Make sure we're in a header, but only if we're also in a navbar
            if (GetComponent<INavbar>() != null && GetComponent<INavbarHeader>() == null)
            {
                new NavbarHeader<THelper>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
