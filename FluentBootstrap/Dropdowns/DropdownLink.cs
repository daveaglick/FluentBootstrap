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

    public class DropdownLink<TModel> : Tag<TModel, DropdownLink<TModel>, DropdownLinkWrapper<TModel>>, IDropdownLink, IHasLinkExtensions, IHasTextContent
    {
        internal bool Disabled { get; set; }
        private Element<TModel> _listItem = null;
        
        internal DropdownLink(IComponentCreator<TModel> creator)
            : base(creator, "a")
        {
            MergeAttribute("role", "menuitem");
        }

        protected override void OnStart(System.IO.TextWriter writer)
        {
            _listItem = new Element<TModel>(Helper, "li");
            _listItem.MergeAttribute("role", "presentation");
            if(Disabled)
            {
                _listItem.AddCss(Css.Disabled);
            }
            _listItem.Start(writer);

            base.OnStart(writer);
        }

        protected override void OnFinish(System.IO.TextWriter writer)
        {
            base.OnFinish(writer);

            _listItem.Finish(writer);
        }
    }
}
