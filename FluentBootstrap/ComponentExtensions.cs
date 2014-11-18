using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ComponentExtensions
    {
        public static TThis RenderIf<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool condition)
            where THelper : BootstrapHelper<THelper>
            where TThis : Component<THelper, TThis, TWrapper>
            where TWrapper : ComponentWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            tag.Render = condition;
            return tag;
        }
    }
}
