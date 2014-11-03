using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Paginations
{
    public interface IPageNumCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PageNumWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IPageNum : ITag
    {
    }

    public class PageNum<TModel> : Tag<TModel, PageNum<TModel>, PageNumWrapper<TModel>>, IPageNum, IHasLinkExtensions, IHasTextContent
    {
        internal bool Active { private get; set; }
        internal bool Disabled { private get; set; }

        private Element<TModel> _listItem = null;

        internal PageNum(IComponentCreator<TModel> creator)
            : base(creator, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Create the list item wrapper
            _listItem = new Element<TModel>(Helper, "li");
            if (Active)
            {
                _listItem.AddCss(Css.Active);
            }
            if (Disabled)
            {
                _listItem.AddCss(Css.Disabled);
            }
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
