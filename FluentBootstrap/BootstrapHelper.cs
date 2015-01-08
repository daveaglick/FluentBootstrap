using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public abstract class BootstrapHelper : IComponentCreator
    {
        internal int GridColumns { get; set; }
        internal bool PrettyPrint { get; set; }
        internal int DefaultFormLabelWidth { get; set; }

        protected BootstrapHelper()
        {
            // TODO: Get these from .config file or from helper ctor
            GridColumns = 12;
            PrettyPrint = true;
            DefaultFormLabelWidth = 4;
        }

        protected internal virtual string FormatValue(object value, string format)
        {
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

        public BootstrapHelper GetHelper()
        {
            return this;
        }

        public Component GetParent()
        {
            return null;
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

    // Derive from this class
    public abstract class BootstrapHelper<THelper> : BootstrapHelper, IComponentCreator<THelper, CanCreate>
        where THelper : BootstrapHelper<THelper>
    {
        protected BootstrapHelper()
        {
            // Sanity check
            if (typeof(THelper) != this.GetType())
            {
                throw new Exception("Invalid THelper generic type parameter for " + this.GetType().Name + " (you should never see this).");
            }
        }

        THelper IComponentCreator<THelper, CanCreate>.Helper
        {
            get { return (THelper)this; }
        }
    }
}
