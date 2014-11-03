using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Labels
{
    public interface ILabelCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class LabelWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface ILabel : ITag
    {
    }

    public class Label<TModel> : Tag<TModel, Label<TModel>, LabelWrapper<TModel>>, ILabel, IHasTextContent
    {
        internal Label(IComponentCreator<TModel> creator)
            : base(creator, "span", Css.Label, Css.LabelDefault)
        {
        }
    }
}
