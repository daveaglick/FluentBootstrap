using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Paginations
{
    public interface IPaginationCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PaginationWrapper<TModel> : TagWrapper<TModel>,
        IPageNumCreator<TModel>
    {
    }

    internal interface IPagination : ITag
    {
    }

    public class Pagination<TModel> : Tag<TModel, Pagination<TModel>, PaginationWrapper<TModel>>, IPagination
    {
        internal int AutoPageNumber { get; set; }
        private Element<TModel> _nav = null;

        internal Pagination(IComponentCreator<TModel> creator)
            : base(creator, "ul", Css.Pagination)
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
