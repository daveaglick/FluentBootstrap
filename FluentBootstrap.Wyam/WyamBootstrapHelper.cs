using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wyam.Razor;

namespace FluentBootstrap.Wyam
{
    public class WyamBootstrapHelper : BootstrapHelper<WyamBootstrapConfig, CanCreate>
    {
        public WyamBootstrapHelper(HtmlHelper htmlHelper)
            : base(new WyamBootstrapConfig(htmlHelper))
        {
        }
    }
}
