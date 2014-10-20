using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownLinkCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class DropdownLinkWrapper<TModel> : TagWrapper<TModel>
    {
    }
    internal interface IDropdownLink : ITag
    {
    }

    public class DropdownLink<TModel> : Tag<TModel, DropdownLink<TModel>, DropdownLinkWrapper<TModel>>, IDropdownLink, IHasLinkExtensions, IHasTextAttribute
    {
        private bool _disabled;
        private Element<TModel> _listItem = null;

        internal bool Disabled
        {
            set { _disabled = value; }
        }

        internal DropdownLink(IComponentCreator<TModel> creator)
            : base(creator, "a")
        {
            MergeAttribute("role", "menuitem");
        }

        protected override void PreStart(System.IO.TextWriter writer)
        {
            base.PreStart(writer);

            _listItem = new Element<TModel>(Helper, "li");
            _listItem.MergeAttribute("role", "presentation");
            if(_disabled)
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
