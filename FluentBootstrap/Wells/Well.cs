using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Wells
{
    public interface IWellCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class WellWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IWell : ITag
    {
    }

    public class Well<TConfig> : Tag<TConfig, Well<TConfig>, WellWrapper<TConfig>>, IWell
        where TConfig : BootstrapConfig
    {
        internal Well(BootstrapHelper helper)
            : base(helper, "div", Css.Well)
        {
        }
    }
}
