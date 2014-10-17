using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ComponentExtensions
    {
        public static TThis RenderIf<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool condition)
            where TThis : Component<TModel, TThis, TWrapper>
            where TWrapper : ComponentWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.Render = condition;
            return tag;
        }
    }
}
