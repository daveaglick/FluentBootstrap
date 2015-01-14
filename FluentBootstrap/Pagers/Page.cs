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
    public interface IPageCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PageWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPage : ITag
    {
    }

    public class Page<TConfig> : Tag<TConfig, Page<TConfig>, PageWrapper<TConfig>>, IPage, IHasLinkExtensions, IHasTextContent
        where TConfig : BootstrapConfig
    {
        internal bool Disabled { get; set; }
        internal PageAlignment Alignment { get; set; }

        private Element<TConfig> _listItem = null;

        internal Page(BootstrapHelper helper)
            : base(helper, "a")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Create the list item wrapper
            _listItem = new Element<TConfig>(Helper, "li");
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
