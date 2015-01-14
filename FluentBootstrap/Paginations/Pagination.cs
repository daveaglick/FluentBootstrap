using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Paginations
{
    public interface IPaginationCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PaginationWrapper<TConfig> : TagWrapper<TConfig>,
        IPageNumCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPagination : ITag
    {
    }

    public class Pagination<TConfig> : Tag<TConfig, Pagination<TConfig>, PaginationWrapper<TConfig>>, IPagination
        where TConfig : BootstrapConfig
    {
        public int AutoPageNumber { get; set; }
        private Element<TConfig> _nav = null;

        internal Pagination(BootstrapHelper helper)
            : base(helper, "ul", Css.Pagination)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _nav = new Element<TConfig>(Helper, "nav");
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
