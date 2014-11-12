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
    public interface IPageCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class PageWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IPage : ITag
    {
    }

    public class Page<THelper> : Tag<THelper, Page<THelper>, PageWrapper<THelper>>, IPage, IHasLinkExtensions, IHasTextContent
    {
        internal bool Disabled { get; set; }
        internal PageAlignment Alignment { get; set; }

        private Element<THelper> _listItem = null;

        internal Page(IComponentCreator<THelper> creator)
            : base(creator, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Create the list item wrapper
            _listItem = new Element<THelper>(Helper, "li");
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
