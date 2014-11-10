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
    public interface ICrumbCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class CrumbWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface ICrumb : ITag
    {
    }

    public class Crumb<TModel> : Tag<TModel, Crumb<TModel>, CrumbWrapper<TModel>>, ICrumb, IHasLinkExtensions, IHasTextContent
    {
        internal bool Active { get; set; }
        private Element<TModel> _listItem = null;

        internal Crumb(IComponentCreator<TModel> creator)
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
