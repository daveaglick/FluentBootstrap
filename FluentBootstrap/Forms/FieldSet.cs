using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FieldSet : Tag, IHasDisabledAttribute,
        ICanCreate<FormGroup>,
        ICanCreate<ControlLabel>,
        ICanCreate<FormControl>,
        ICanCreate<HelpBlock>
    {
        internal FieldSet(BootstrapHelper helper)
            : base(helper, "fieldset")
        {
        }
    }
}
