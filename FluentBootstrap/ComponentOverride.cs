using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public abstract class ComponentOverride
    {
        internal abstract Type GetComponentType();
        internal abstract void SetComponent(Component component);
        internal Action<TextWriter> BaseStartAction { get; set; }
        internal Action<TextWriter> BaseFinishAction { get; set; }
        protected internal abstract void OnStart(TextWriter writer);
        protected internal abstract void OnFinish(TextWriter writer);
    }

    // Derive and register instances of this class to override the behavior for a given component
    // This allows you to override behavior for a component based on any level in the type hierarchy (I.e., override the behavior of the any component that implements the abstract Form component)
    // However, keep in mind that OnStart/OnFinish will still be called first at the most-derived level
    // If there are more than one override for a given component type hierarchy, they will all be executed most-derived first (calling base.OnStart/base.OnFinish will go to next base override, etc.)
    public abstract class ComponentOverride<TComponent, THelper> : ComponentOverride
        where TComponent : Component<THelper>
        where THelper : BootstrapHelper<THelper>

    {
        // These are all set by Component after instantiation
        protected internal TComponent Component { get; set; }

        internal override sealed Type GetComponentType()
        {
            return typeof(TComponent).GetGenericTypeDefinition();
        }

        internal override sealed void SetComponent(Component component)
        {
            Component = (TComponent)component;
        }

        // This must be called from overloads
        // To suppress output, pass in SuppressOutputWriter
        protected internal override void OnStart(TextWriter writer)
        {
            BaseStartAction(writer);
        }

        // This must be called from overloads
        // To suppress output, pass in SuppressOutputWriter
        protected internal override void OnFinish(TextWriter writer)
        {
            BaseFinishAction(writer);
        }
    }
}
