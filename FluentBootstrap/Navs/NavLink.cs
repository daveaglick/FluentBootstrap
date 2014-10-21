using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface INavLinkCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavLinkWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface INavLink : ITag
    {
    }

    public class NavLink<TModel> : Tag<TModel, NavLink<TModel>, NavLinkWrapper<TModel>>, INavLink, IHasLinkExtensions, IHasTextAttribute
    {
        internal bool Active { private get; set; }
        internal bool Disabled { private get; set; }
        private Element<TModel> _listItem = null;

        internal NavLink(IComponentCreator<TModel> creator)
            : base(creator, "a")
        {
        }

        protected override void PreStart(System.IO.TextWriter writer)
        {
            base.PreStart(writer);

            _listItem = new Element<TModel>(Helper, "li");
            if(Active)
            {
                _listItem.AddCss(Css.Active);
            }
            if (Disabled)
            {
                _listItem.AddCss(Css.Disabled);
            }
            _listItem.Start(writer, true);
        }

        protected override void OnFinish(System.IO.TextWriter writer)
        {
            base.OnFinish(writer);

            _listItem.Finish(writer);
        }
    }
}
