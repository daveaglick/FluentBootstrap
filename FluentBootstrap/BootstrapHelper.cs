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

        internal void PushComponent(BootstrapComponent component)
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<BootstrapComponent> stack = items[_bootstrapStackKey] as Stack<BootstrapComponent>;
            if (stack == null)
            {
                stack = new Stack<BootstrapComponent>();
                items[_bootstrapStackKey] = stack;
            }
            stack.Push(component);
        }

        internal BootstrapComponent PeekComponent()
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<BootstrapComponent> stack = items[_bootstrapStackKey] as Stack<BootstrapComponent>;
            return stack == null ? null : stack.Peek();
        }

        internal TComponent PeekComponent<TComponent>()
            where TComponent : BootstrapComponent
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<BootstrapComponent> stack = items[_bootstrapStackKey] as Stack<BootstrapComponent>;
            return stack == null ? null : stack.Peek() as TComponent;
        }

        internal TComponent GetComponent<TComponent>()
            where TComponent : BootstrapComponent
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<BootstrapComponent> stack = items[_bootstrapStackKey] as Stack<BootstrapComponent>;
            return stack == null ? null : stack.OfType<TComponent>().FirstOrDefault();         
        }

        internal void PopComponent(BootstrapComponent component)
        {
            IDictionary items = HtmlHelper.ViewContext.HttpContext.Items;
            Stack<BootstrapComponent> stack = items[_bootstrapStackKey] as Stack<BootstrapComponent>;
            if (stack == null || stack.Count == 0)
                throw new InvalidOperationException("Could not get Bootstrap component stack while removing a component (you should never see this).");
            BootstrapComponent pop = stack.Pop();
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
