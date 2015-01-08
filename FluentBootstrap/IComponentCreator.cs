using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public interface IComponentCreator
    {
        BootstrapHelper Helper { get; }
        Component Parent { get; }
    }

    // The TComponent generic type allows the extension methods to constrain to creators for components that implement specific ICanCreate<>
    public interface IComponentCreator<TComponent> : IComponentCreator
        where TComponent : Component
    {
    }
}
