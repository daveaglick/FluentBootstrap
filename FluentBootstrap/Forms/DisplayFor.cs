using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IDisplayFor : IFormControl
    {
    }

    public class DisplayFor<TModel> : FormControl<TModel, DisplayFor<TModel>>, IDisplayFor
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
