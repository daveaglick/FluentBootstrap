using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    internal abstract class ComponentOverride
    {
        internal Action<TextWriter> BaseStartAction { get; set; }
        internal Action<TextWriter> BaseFinishAction { get; set; }
        protected internal abstract void OnStart(TextWriter writer);
        protected internal abstract void OnFinish(TextWriter writer);
    }

    // Derive and register instances of this class to override the behavior for a given component
    // This allows you to override behavior for a component based on any level in the type hierarchy (I.e., override the behavior of the any component that implements the abstract Form component)
    // However, keep in mind that OnStart/OnFinish will still be called first before any actual control OnStart/OnFinish
    // If there are more than one override for a given component, the execution order is arbitrary
    internal abstract class ComponentOverride<THelper, TComponent> : ComponentOverride
        where THelper : BootstrapHelper<THelper>
        where TComponent : IComponent
    {
        protected internal THelper Helper { get; private set; }
        protected internal TComponent Component { get; private set; }

        protected ComponentOverride(THelper helper, TComponent component)
        {
            Helper = helper;
            Component = component;
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
