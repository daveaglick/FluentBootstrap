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

    public class ComponentBuilder<TComponent> : ComponentBuilder, IHtmlString
        where TComponent : Component
    {
        private readonly BootstrapHelper _helper;
        private readonly TComponent _component;

        internal ComponentBuilder(BootstrapHelper helper, TComponent component)
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

        internal ComponentWrapper<TComponent> GetWrapper()
        {
            return new ComponentWrapper<TComponent>(this);
        }

        public ComponentWrapper<TComponent> Begin()
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
    }
}
