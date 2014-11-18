using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownLinkCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class DropdownLinkWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IDropdownLink : ITag
    {
    }

    public class DropdownLink<THelper> : Tag<THelper, DropdownLink<THelper>, DropdownLinkWrapper<THelper>>, IDropdownLink, IHasLinkExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal bool Disabled { get; set; }
        private Element<THelper> _listItem = null;
        
        internal DropdownLink(IComponentCreator<THelper> creator)
            : base(creator, "a")
        {
            MergeAttribute("role", "menuitem");
        }

        protected override void OnStart(System.IO.TextWriter writer)
        {
            _listItem = new Element<THelper>(Helper, "li");
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
