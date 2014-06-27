using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public interface IComponents : IComponent
    {

    }

    // This just acts as a wrapper around other components
    public class Components<TModel> : Component<TModel, Components<TModel>>, IComponents
    {
        public Components(BootstrapHelper<TModel> helper)
            : base(helper)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Do nothing
        }
    }
}
