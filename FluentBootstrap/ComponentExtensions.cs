using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ComponentExtensions
    {
        public static ComponentWrapper<TComponent> Begin<TComponent>(this TComponent component)
            where TComponent : Component
        {
            component.Start(component.ViewContext.Writer, false);
            return new ComponentWrapper<TComponent>(component);
        }
    }
}
