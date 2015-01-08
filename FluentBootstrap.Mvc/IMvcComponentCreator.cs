using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Mvc
{
    public interface IMvcComponentCreator<TComponent, TModel> : IComponentCreator<TComponent>
        where TComponent : Component
    {
    }
}
