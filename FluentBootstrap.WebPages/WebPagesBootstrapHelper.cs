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
    public class WebPagesBootstrapHelper : BootstrapHelper<WebPagesBootstrapConfig, CanCreate>
    {
        public WebPagesBootstrapHelper(WebPageBase webPageBase)
            : base(new WebPagesBootstrapConfig(webPageBase))
        {
        }
    }
}
