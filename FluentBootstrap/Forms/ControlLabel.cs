using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IControlLabelCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ControlLabelWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IControlLabel : ITag
    {
    }

    public class ControlLabel<THelper> : Tag<THelper, ControlLabel<THelper>, ControlLabelWrapper<THelper>>, IControlLabel, IHasGridColumnExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal ControlLabel(IComponentCreator<THelper> creator, string text)
            : base(creator, "label", Css.ControlLabel)
        {
            TextContent = text;
        }
    }
}
