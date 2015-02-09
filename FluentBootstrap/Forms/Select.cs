using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Select : FormControl, IHasNameAttribute,
        ICanCreate<SelectOption>
    {
        public bool Multiple { get; set; }

        internal Select(BootstrapHelper helper)
            : base(helper, "select", Css.FormControl)
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            if(Multiple)
            {
                MergeAttribute("multiple", "multiple");
            }

            base.OnStart(writer);
        }
    }
}
