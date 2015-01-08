using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class ControlLabel : Tag, IHasGridColumnExtensions, IHasTextContent
    {
        public ControlLabel(IComponentCreator creator, string text)
            : base(creator, "label", Css.ControlLabel)
        {
            TextContent = text;
        }
    }
}
