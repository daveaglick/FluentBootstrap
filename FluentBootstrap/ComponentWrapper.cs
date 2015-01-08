using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public class ComponentWrapper<THelper, TComponent> : IDisposable,
            IComponentCreator<THelper, TComponent>
        where THelper : BootstrapHelper<THelper>
        where TComponent : Component
    {
        private readonly ComponentBuilder<THelper, TComponent> _builder;

        internal ComponentWrapper(ComponentBuilder<THelper, TComponent> builder)
        {
            _builder = builder;
        }

        internal bool WithChild { get; set; }


        public void Dispose()
        {
            End();
        }

        public void End()
        {
            _builder.End();
        }

        BootstrapHelper IComponentCreator.GetHelper()
        {
            return _builder.Helper;
        }

        Component IComponentCreator.GetParent()
        {
            return WithChild ? _builder.Component : null;
        }

        THelper IComponentCreator<THelper, TComponent>.Helper
        {
            get { return _builder.Helper; }
        }
    }
}
