using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public abstract class BootstrapConfig
    {
        internal int GridColumns { get; set; }
        internal bool PrettyPrint { get; set; }
        internal int DefaultFormLabelWidth { get; set; }

        private readonly Dictionary<Type, Func<BootstrapConfig, Component, ComponentOverride>> _componentOverrides
            = new Dictionary<Type,Func<BootstrapConfig,Component,ComponentOverride>>();
        private readonly bool _registeringComponentOverrides;

        // Only allow access through the instance to make sure the dictionary has been initialized
        internal Dictionary<Type, Func<BootstrapConfig, Component, ComponentOverride>> ComponentOverrides
        {
            get { return _componentOverrides; }
        }

        protected BootstrapConfig()
        {
            // TODO: Get these from .config file or from helper ctor
            GridColumns = 12;
            PrettyPrint = true;
            DefaultFormLabelWidth = 4;

            _registeringComponentOverrides = true;
            RegisterComponentOverrides();
            _registeringComponentOverrides = false;
        }

        protected internal string FormatValue(object value, string format)
        {
            // From ViewDataDictionary.FormatValueInternal(), which is called from HtmlHelper.FormatValue()
            // Reproduced here to remove dependency on ASP.NET MVC 4
            if (value == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(format))
            {
                return Convert.ToString(value, CultureInfo.CurrentCulture);
            }
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            object[] objArray = new object[] { value };
            return string.Format(currentCulture, format, objArray);
        }

        protected internal virtual string GetFullHtmlFieldName(string name)
        {
            return name;
        }

        // Derived helpers should override this method to register component overrides
        protected virtual void RegisterComponentOverrides()
        {
        }

        protected void RegisterComponentOverride<TComponent, TOverride>()
            where TComponent : Component
            where TOverride : ComponentOverride<TComponent>, new()
        {
            if (!_registeringComponentOverrides)
            {
                throw new InvalidOperationException("You can only register component overrides from within the RegisterComponentOverrides method.");
            }
            ComponentOverrides[typeof(TComponent)] = (config, component) =>
            {
                TOverride componentOverride = new TOverride();
                componentOverride.Config = config;
                componentOverride.Component = (TComponent)component;
                return componentOverride;
            };
        }

        // Returns the current TextWriter for output
        protected internal abstract TextWriter GetWriter();

        // Gets an item from a persistent cache for the entire page/view
        // Should return null if the key doesn't exist
        protected internal abstract object GetItem(object key, object defaultValue);

        // Adds an item to a persistent cache for the entire page/view
        // Should overwrite the previous value if the key already exists
        protected internal abstract void AddItem(object key, object value);
    }
}
