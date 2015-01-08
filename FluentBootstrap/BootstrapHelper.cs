using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public abstract class BootstrapHelper : IComponentCreator<CanCreate>
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

        public BootstrapHelper Helper
        {
            get { return this; }
        }

        public Component Parent
        {
            get { return null; }
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
