using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FluentBootstrap
{
    public abstract class ComponentBuilder
    {
        internal abstract Component GetComponent();
    }

    public class ComponentBuilder<THelper, TComponent> : ComponentBuilder, IHtmlString
        where THelper : BootstrapHelper<THelper>
        where TComponent : Component
    {
        private readonly THelper _helper;
        private readonly TComponent _component;

        internal ComponentBuilder(THelper helper, TComponent component)
        {
            _component = component;
            _helper = helper;
        }

        internal THelper Helper
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

        internal ComponentWrapper<THelper, TComponent> GetWrapper()
        {
            return new ComponentWrapper<THelper, TComponent>(this);
        }

        public ComponentWrapper<THelper, TComponent> Begin()
        {
            Component.Begin(Helper, null);
            return GetWrapper();
        }

        public void End()
        {
            Component.End(Helper, null);
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            return Component.ToString(Helper);
        }
    }
}
