using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public abstract class ComponentCreator
    {
        internal abstract BootstrapHelper Helper { get; }
        internal abstract Component Parent { get; }
    }

    // The TComponent generic type allows the extension methods to constrain to creators for components that implement specific ICanCreate<>
    public abstract class ComponentCreator<THelper, TComponent> : ComponentCreator
        where TComponent : Component
    {
    }
}
