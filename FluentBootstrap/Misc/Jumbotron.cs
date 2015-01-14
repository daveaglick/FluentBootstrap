using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Misc
{
    public interface IJumbotronCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class JumbotronWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IJumbotron : ITag
    {
    }

    public class Jumbotron<TConfig> : Tag<TConfig, Jumbotron<TConfig>, JumbotronWrapper<TConfig>>, IJumbotron
        where TConfig : BootstrapConfig
    {
        internal Jumbotron(BootstrapHelper helper)
            : base(helper, "div", Css.Jumbotron)
        {
        }
    }
}
