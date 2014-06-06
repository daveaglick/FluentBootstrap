using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public class BootstrapHelper
    {
        internal HtmlHelper HtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        internal void Write(object content)
        {
            if (content == null) return;
            HtmlHelper.ViewContext.Writer.Write(
                Convert.ToString(content, CultureInfo.InvariantCulture));
        }

        // The following code handles the stack of Bootstrap objects stored in the ViewContext

        private readonly static object _bootstrapStackKey = new object();

        internal void PushComponent(Component component)
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            if (stack == null)
            {
                stack = new Stack<Component>();
                items[_bootstrapStackKey] = stack;
            }
            stack.Push(component);
        }

        internal Component PeekComponent()
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            return stack == null ? null : stack.Peek();
        }

        internal TComponent PeekComponent<TComponent>()
            where TComponent : Component
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            return stack == null ? null : stack.Peek() as TComponent;
        }

        internal TComponent GetComponent<TComponent>()
            where TComponent : Component
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            return stack == null ? null : stack.OfType<TComponent>().FirstOrDefault();         
        }

        internal void PopComponent(Component component)
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            if (stack == null || stack.Count == 0)
                throw new InvalidOperationException("Could not get Bootstrap component stack while removing a component (you should never see this).");
            Component pop = stack.Pop();
            if (component != pop)
                throw new InvalidOperationException("Attempted to remove a Bootstrap component from the stack that wasn't at the top, the nesting order may be incorrect.");
        }
    }

    public class BootstrapHelper<TModel> : BootstrapHelper
    {
        internal HtmlHelper<TModel> StrongHtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            StrongHtmlHelper = htmlHelper;
        }
    }
}
