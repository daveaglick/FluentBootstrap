using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Pagers
{
    public interface IPageCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PageWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IPage : ITag
    {
    }

    public class Page<TModel> : Tag<TModel, Page<TModel>, PageWrapper<TModel>>, IPage, IHasLinkExtensions, IHasTextAttribute
    {
        internal bool Disabled { private get; set; }
        internal PageAlignment Alignment { private get; set; }

        private Element<TModel> _listItem = null;

        internal Page(IComponentCreator<TModel> creator)
            : base(creator, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Create the list item wrapper
            _listItem = new Element<TModel>(Helper, "li");
            if (Disabled)
            {
                _listItem.AddCss(Css.Disabled);
            }
            _listItem.ToggleCss(Alignment);
            _listItem.Start(writer);

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            _listItem.Finish(writer);
        }
    }
}
