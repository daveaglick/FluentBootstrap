using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
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

    public class Label<TModel> : Tag<TModel, Label<TModel>, LabelWrapper<TModel>>, ILabel, IHasGridColumnExtensions, IHasTextAttribute
    {
        internal Label(IComponentCreator<TModel> creator, string text)
            : base(creator, "label", Css.ControlLabel)
        {
            TextContent = text;
        }
    }
}
