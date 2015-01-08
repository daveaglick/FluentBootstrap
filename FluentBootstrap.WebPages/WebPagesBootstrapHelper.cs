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

        protected override TextWriter GetWriter()
        {
            return WebPageBase.Output;
        }

        protected override object GetItem(object key, object defaultValue)
        {
            if (WebPageBase.Context.Items.Contains(key))
            {
                return WebPageBase.Context.Items[key];
            }
            return defaultValue;
        }

        protected override void AddItem(object key, object value)
        {
            WebPageBase.Context.Items[key] = value;
        }
    }
}
