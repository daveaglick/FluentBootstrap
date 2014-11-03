using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ProgressBars
{
    public interface IProgressCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ProgressWrapper<TModel> : TagWrapper<TModel>,
        IProgressBarCreator<TModel>
    {
    }

    internal interface IProgress : ITag
    {
    }

    public class Progress<TModel> : Tag<TModel, Progress<TModel>, ProgressWrapper<TModel>>, IProgress
    {
        internal Progress(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Progress)
        {
        }
    }
}
