using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Static : FormControl
    {
        internal Static(IComponentCreator creator)
            : base(creator, "p", Css.FormControlStatic)
        {
        }
    }
}
