using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Pagers
{
    public interface IPagerCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class PagerWrapper<THelper> : TagWrapper<THelper>,
        IPageCreator<THelper>
    {
    }

    internal interface IPager : ITag
    {
    }

    public class Pager<THelper> : Tag<THelper, Pager<THelper>, PagerWrapper<THelper>>, IPager
    {
        private Element<THelper> _nav = null;

        internal Pager(IComponentCreator<THelper> creator)
            : base(creator, "ul", Css.Pager)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _nav = new Element<THelper>(Helper, "nav");
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
