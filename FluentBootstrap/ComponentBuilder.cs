using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FluentBootstrap
{
    public abstract class ComponentBuilder
    {
        internal abstract BootstrapHelper Helper { get; }
        internal abstract Component GetComponent();
        public abstract void End();
    }

    // This base class allows extension libraries to override the builder/wrapper classes (for example, to pass around a model)
    public abstract class ComponentBuilder<TWrapper, TComponent> : ComponentBuilder, IHtmlString
        where TWrapper : ComponentWrapper<TComponent>
        where TComponent : Component
    {
        private readonly BootstrapHelper _helper;
        private readonly TComponent _component;

        public ComponentBuilder(BootstrapHelper helper, TComponent component)
        {
            _component = component;
            _helper = helper;
        }

        internal override BootstrapHelper Helper
        {
            get { return this._helper; }
        }

        internal TComponent Component
        {
            get { return this._component; }
        }

        internal override Component GetComponent()
        {
            return Component;
        }

        public TWrapper Begin()
        {
            Component.Begin(null);
            return GetWrapper();
        }

        public override void End()
        {
            Component.End(null);
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            return Component.ToString();
        }

        protected internal abstract TWrapper GetWrapper();
    }

    public class ComponentBuilder<TComponent> : ComponentBuilder<ComponentWrapper<TComponent>, TComponent>
        where TComponent : Component
    {
        public ComponentBuilder(BootstrapHelper helper, TComponent component)
            : base(helper, component)
        {
        }

        protected internal override ComponentWrapper<TComponent> GetWrapper()
        {
            return new ComponentWrapper<TComponent>(this);
        }
    }
}
