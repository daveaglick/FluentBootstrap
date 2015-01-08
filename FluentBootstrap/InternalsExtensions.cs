using System;
using System.Collections.Generic;
using System.IO;
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

        public static Component GetComponent(this ComponentBuilder builder)
        {
            return builder.GetComponent();
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

        public static void Start(this Component component, TextWriter writer)
        {
            component.Start(writer);
        }

        public static void Finish(this Component component, TextWriter writer)
        {
            component.Start(writer);
        }

        public static void StartAndFinish(this Component component, TextWriter writer)
        {
            component.StartAndFinish(writer);
        }
    }
}
