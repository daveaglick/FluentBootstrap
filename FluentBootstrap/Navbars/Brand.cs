using FluentBootstrap.Icons;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface IBrandCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class BrandWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IBrand : ITag
    {
    }

    public class Brand<TModel> : Tag<TModel, Brand<TModel>, BrandWrapper<TModel>>, IBrand, IHasIconExtensions, IHasLinkExtensions, IHasTextAttribute
    {
        internal Brand(IComponentCreator<TModel> creator)
            : base(creator, "a", Css.NavbarBrand)
        {
        }
        
        protected override void OnStart(System.IO.TextWriter writer)
        {
            // Make sure we're in a header, but only if we're also in a navbar
            if (GetComponent<INavbar>() != null && GetComponent<INavbarHeader>() == null)
            {
                new NavbarHeader<TModel>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
