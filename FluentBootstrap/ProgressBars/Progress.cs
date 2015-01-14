using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ProgressBars
{
    public interface IProgressCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class ProgressWrapper<TConfig> : TagWrapper<TConfig>,
        IProgressBarCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IProgress : ITag
    {
    }

    public class Progress<TConfig> : Tag<TConfig, Progress<TConfig>, ProgressWrapper<TConfig>>, IProgress
        where TConfig : BootstrapConfig
    {
        internal Progress(BootstrapHelper helper)
            : base(helper, "div", Css.Progress)
        {
        }
    }
}
