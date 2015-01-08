using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class HelpBlock : Tag, IHasTextContent
    {
        public HelpBlock(IComponentCreator creator)
            : base(creator, "div", Css.HelpBlock)
        {
        }
    }
}
