using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class TextArea : FormControl
    {
        internal TextArea(BootstrapHelper helper)
            : base(helper, "textarea", "form-control")
        {
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
