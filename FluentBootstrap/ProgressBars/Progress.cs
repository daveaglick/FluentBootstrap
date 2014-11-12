using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ProgressBars
{
    public interface IProgressCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class ProgressWrapper<THelper> : TagWrapper<THelper>,
        IProgressBarCreator<THelper>
    {
    }

    internal interface IProgress : ITag
    {
    }

    public class Progress<THelper> : Tag<THelper, Progress<THelper>, ProgressWrapper<THelper>>, IProgress
    {
        internal Progress(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Progress)
        {
        }
    }
}
