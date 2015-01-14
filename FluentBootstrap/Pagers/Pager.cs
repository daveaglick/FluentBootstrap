using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Pagers
{
    public interface IPagerCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PagerWrapper<TConfig> : TagWrapper<TConfig>,
        IPageCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPager : ITag
    {
    }

    public class Pager<TConfig> : Tag<TConfig, Pager<TConfig>, PagerWrapper<TConfig>>, IPager
        where TConfig : BootstrapConfig
    {
        private Element<TConfig> _nav = null;

        internal Pager(BootstrapHelper helper)
            : base(helper, "ul", Css.Pager)
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
