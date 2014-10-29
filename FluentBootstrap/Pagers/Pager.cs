using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Pagers
{
    public interface IPagerCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PagerWrapper<TModel> : TagWrapper<TModel>,
        IPageCreator<TModel>
    {
    }

    internal interface IPager : ITag
    {
    }

    public class Pager<TModel> : Tag<TModel, Pager<TModel>, PagerWrapper<TModel>>, IPager
    {
        private Element<TModel> _nav = null;

        internal Pager(IComponentCreator<TModel> creator)
            : base(creator, "ul", Css.Pager)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _nav = new Element<TModel>(Helper, "nav");
            _nav.Start(writer);

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            _nav.Finish(writer);
        }
    }
}
