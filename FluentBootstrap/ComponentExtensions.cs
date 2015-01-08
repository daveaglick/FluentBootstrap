using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ComponentExtensions
    {
        public static TComponent RenderIf<TComponent>(this TComponent component, bool condition)
            where TComponent : Component
        {
            component.Render = condition;
            return component;
        }
    }
}
