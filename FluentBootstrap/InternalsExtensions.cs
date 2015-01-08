using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap.Internals
{
    // This is a bit of a hack, but exposing internal members via extension methods in a separate namespace
    // was the only good way I could think of to allow extending libraries access without resorting to
    // InternalsVisibleTo and without also making those members visible to consuming applications
    public static class InternalsExtensions
    {
        public static TComponent GetComponent<TComponent>(this ComponentBuilder<TComponent> builder)   
            where TComponent : Component
        {
            return builder.Component;
        }

        public static BootstrapHelper GetHelper<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : Component
        {
            return builder.Helper;
        }

        public static ComponentWrapper<TComponent> GetWrapper<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : Component
        {
            return builder.GetWrapper();
        }
    }
}
