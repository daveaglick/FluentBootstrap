using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Mvc
{
    public class MvcOutputContext : IOutputContext
    {
        private readonly HtmlHelper _htmlHelper;

        public MvcOutputContext(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public TextWriter GetWriter()
        {
            return _htmlHelper.ViewContext.Writer;
        }

        public object GetItem(object key)
        {
            return _htmlHelper.ViewContext.HttpContext.Items[key];
        }

        public void AddItem(object key, object value)
        {
            _htmlHelper.ViewContext.HttpContext.Items[key] = value;
        }
    }
}
