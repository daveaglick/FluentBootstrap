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
        private readonly static object _componentStackKey = new object();
        private readonly static object _outputStackKey = new object();

        private readonly HtmlHelper _htmlHelper;

        public MvcOutputContext(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public TextWriter GetWriter()
        {
            return _htmlHelper.ViewContext.Writer;
        }

        public Stack<IComponent> GetComponentStack()
        {
            return GetStack(_componentStackKey);
        }

        public Stack<IComponent> GetOutputStack()
        {
            return GetStack(_outputStackKey);
        }

        private Stack<IComponent> GetStack(object key)
        {
            IDictionary items = _htmlHelper.ViewContext.HttpContext.Items;
            Stack<IComponent> stack = items[key] as Stack<IComponent>;
            if (stack == null)
            {
                stack = new Stack<IComponent>();
                items[key] = stack;
            }
            return stack;
        }
    }
}
