using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebPages;

namespace FluentBootstrap.WebPages
{
    public class WebPagesBootstrapHelper : BootstrapHelper<WebPagesBootstrapHelper>
    {
        internal WebPageBase WebPageBase { get; private set; }

        public WebPagesBootstrapHelper(WebPageBase webPageBase)
        {
            WebPageBase = webPageBase;
        }

        protected internal override TextWriter GetWriter()
        {
            return WebPageBase.Output;
        }

        protected internal override object GetItem(object key, object defaultValue)
        {
            if (WebPageBase.Context.Items.Contains(key))
            {
                return WebPageBase.Context.Items[key];
            }
            return defaultValue;
        }

        protected internal override void AddItem(object key, object value)
        {
            WebPageBase.Context.Items[key] = value;
        }
    }
}
