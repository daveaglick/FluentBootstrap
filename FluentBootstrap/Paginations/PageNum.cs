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
    public interface IPageNumCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PageNumWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPageNum : ITag
    {
    }

    public class PageNum<THelper> : Tag<THelper, PageNum<THelper>, PageNumWrapper<THelper>>, IPageNum, IHasLinkExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal bool Active { get; set; }
        internal bool Disabled { get; set; }

        private Element<THelper> _listItem = null;

        internal PageNum(IComponentCreator<THelper> creator)
            : base(creator, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Create the list item wrapper
            _listItem = new Element<THelper>(Helper, "li");
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
