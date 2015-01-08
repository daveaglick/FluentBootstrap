using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Mvc
{
    public class MvcComponentBuilder<TComponent, TModel> : ComponentBuilder<MvcComponentWrapper<TComponent, TModel>, TComponent>
        where TComponent : Component
    {
        public MvcComponentBuilder(BootstrapHelper helper, TComponent component) : base(helper, component)
        {
        }

        protected override MvcComponentWrapper<TComponent, TModel> GetWrapper()
        {
            return new MvcComponentWrapper<TComponent, TModel>(this);
        }
    }
}
