using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ComponentExtensions
    {
        public static TThis RenderIf<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, bool condition)
            where TThis : Component<TModel, TThis, TParent>
            where TParent : ComponentParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.Render = condition;
            return tag;
        }
    }
}
