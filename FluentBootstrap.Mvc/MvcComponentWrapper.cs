using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Mvc
{
    public class MvcComponentWrapper<TComponent, TModel> : ComponentWrapper<TComponent>, IMvcComponentCreator<TComponent, TModel>
        where TComponent : Component
    {
        protected internal MvcComponentWrapper(ComponentBuilder builder)
            : base(builder)
        {
        }
    }
}
