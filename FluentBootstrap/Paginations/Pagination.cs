using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Paginations
{
    public interface IPaginationCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PaginationWrapper<THelper> : TagWrapper<THelper>,
        IPageNumCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPagination : ITag
    {
    }

    public class Pagination<THelper> : Tag<THelper, Pagination<THelper>, PaginationWrapper<THelper>>, IPagination
        where THelper : BootstrapHelper<THelper>
    {
        public int AutoPageNumber { get; set; }
        private Element<THelper> _nav = null;

        internal Pagination(IComponentCreator<THelper> creator)
            : base(creator, "ul", Css.Pagination)
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
