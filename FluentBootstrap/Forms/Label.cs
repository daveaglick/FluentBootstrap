using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface ILabel : ITag
    {
    }

    public interface ILabelCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Label<TModel> : Tag<TModel, Label<TModel>>, ILabel, FluentBootstrap.Grids.IHasGridColumnExtensions, IHasTextAttribute
    {
        internal Label(BootstrapHelper<TModel> helper, string text)
            : base(helper, "label", "control-label")
        {
            TextContent = text;
        }
    }
}
