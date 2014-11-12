using FluentBootstrap.Html;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Breadcrumbs
{
    public interface ICrumbCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class CrumbWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ICrumb : ITag
    {
    }

    public class Crumb<THelper> : Tag<THelper, Crumb<THelper>, CrumbWrapper<THelper>>, ICrumb, IHasLinkExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal bool Active { get; set; }
        private Element<THelper> _listItem = null;

        internal Crumb(IComponentCreator<THelper> creator)
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
            _listItem.Start(writer);

            base.OnStart(Active ? new SuppressOutputWriter() : writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(Active ? new SuppressOutputWriter() : writer);

            _listItem.Finish(writer);
        }
    }
}
