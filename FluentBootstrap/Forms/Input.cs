using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public class Input : FormControl
    {
        public interface ICreate : ICreateComponent
        {
        }

        internal Input(BootstrapHelper helper, string type) : base(helper, "input", "form-control")
        {
            MergeAttribute("type", type);
        }
    }
}
