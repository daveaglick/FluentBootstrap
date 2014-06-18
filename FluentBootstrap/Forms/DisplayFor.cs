using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class DisplayFor<TModel> : FormControl<TModel>
    {
        internal DisplayFor(BootstrapHelper<TModel> helper)
            : base(helper, null)
        {
        }

        protected override void OnStart(System.IO.TextWriter writer)
        {
            base.OnStart(writer);
        }

        protected override void OnFinish(System.IO.TextWriter writer)
        {
            base.OnFinish(writer);
        }
    }
}
