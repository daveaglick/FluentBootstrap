using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    // TODO: Can this be made internal?
    public interface IComponentCreator
    {
        BootstrapHelper GetHelper();
        Component GetParent();
    }

    public interface IComponentCreator<THelper, TComponent> : IComponentCreator
        where THelper : BootstrapHelper<THelper>
        where TComponent : Component
    {
        THelper Helper { get; }
    }
}
