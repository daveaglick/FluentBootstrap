using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public interface ICaptionCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class CaptionWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ICaption : ITag
    {
    }

    public class Caption<TConfig> : Tag<TConfig, Caption<TConfig>, CaptionWrapper<TConfig>>, ICaption
        where TConfig : BootstrapConfig
    {
        internal Caption(BootstrapHelper helper)
            : base(helper, "div", Css.Caption)
        {
        }
    }
}
