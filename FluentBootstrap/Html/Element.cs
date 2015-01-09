using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    // Like Tag but implements IHasTextContent (we don't want all Tags to have text content)
    public class Element : Tag, IHasTextContent
    {
        internal Element(BootstrapHelper helper, string tagName)
            : base(helper, tagName)
        {
        }
    }
}
