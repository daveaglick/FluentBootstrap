using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wyam.Modules.Razor;

namespace FluentBootstrap.Wyam
{
    public class WyamBootstrapConfig : BootstrapConfig
    {
        internal HtmlHelper HtmlHelper { get; private set; }
        
        public WyamBootstrapConfig(HtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        protected override TextWriter GetWriter()
        {
            return HtmlHelper.ViewContext.Writer;
        }

        protected override object GetItem(object key, object defaultValue)
        {
            object value;
            return GetDictionary().TryGetValue(key, out value) ? value : defaultValue;
        }

        protected override void AddItem(object key, object value)
        {
            GetDictionary()[key] = value;
        }

        private IDictionary<object, object> GetDictionary()
        {
            object dictionaryObject;
            IDictionary<object, object> dictionary;
            if (HtmlHelper.ViewContext.ViewData.TryGetValue("FluentBootstrapDictionary", out dictionaryObject))
            {
                dictionary = dictionaryObject as IDictionary<object, object>;
                if (dictionary != null)
                {
                    return dictionary;
                }
            }
            dictionary = new Dictionary<object, object>();
            HtmlHelper.ViewContext.ViewData["FluentBootstrapDictionary"] = dictionary;
            return dictionary;
        }
    }
}
