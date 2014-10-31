using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IControlLabelCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ControlLabelWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IControlLabel : ITag
    {
    }

    public class ControlLabel<TModel> : Tag<TModel, ControlLabel<TModel>, ControlLabelWrapper<TModel>>, IControlLabel, IHasGridColumnExtensions, IHasTextAttribute
    {
        internal ControlLabel(IComponentCreator<TModel> creator, string text)
            : base(creator, "label", Css.ControlLabel)
        {
            TextContent = text;
        }
    }
}
