using FluentBootstrap.Forms;
using FluentBootstrap.Mvc.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Mvc
{
    public class MvcBootstrapHelper<TModel> : BootstrapHelper<MvcBootstrapConfig<TModel>, CanCreate>
    {
        public MvcBootstrapHelper(HtmlHelper<TModel> htmlHelper)
            : base(new MvcBootstrapConfig<TModel>(htmlHelper))
        {
        }
    }
}
