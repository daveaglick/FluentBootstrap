using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;

namespace FluentBootstrap
{
    // This delays writing the component until something else atempts to write
    // At which point it swaps the actual writer back in and writes the pending component
    // It is primarily used to get around the fluent finishing problem
    internal class PendingComponents : TextWriter
    {
        private readonly static object _bootstrapPendingListKey = new object();
        private readonly HtmlHelper _htmlHelper;
        private readonly TextWriter _viewContextTextWriter;

        public static void Add(HtmlHelper htmlHelper, IComponent component)
        {
            // Permanently replace the TextWriter at the top of the stack if it's not already been replaced
            PendingComponents pending = htmlHelper.ViewContext.Writer as PendingComponents;
            if (pending == null)
            {
                // A pending writer was not found on the stack, so replace it
                // In order to intercept HTML literal content from Razor, the OutputStack has to be manually handled
                // See http://stackoverflow.com/questions/17557732/textwriter-references-not-behaving-as-expected                
                TextWriter pop = GetOutputStack(htmlHelper).Pop();
                if (pop != htmlHelper.ViewContext.Writer)
                {
                    throw new InvalidOperationException("The top of the OutputStack does not equal the ViewContext.Writer (you should never see this).");
                }
                pending = new PendingComponents(htmlHelper);
                GetOutputStack(htmlHelper).Push(pending);
                htmlHelper.ViewContext.Writer = pending;
            }

            // Add this component and it's original TextWriter to the list
            GetList(htmlHelper).Add(new Tuple<IComponent,TextWriter>(component, pending._viewContextTextWriter));
        }

        public static void Remove(HtmlHelper htmlHelper, IComponent component)
        {
            if (component == null)
            {
                return;
            }
            List<Tuple<IComponent, TextWriter>> list = GetList(htmlHelper);
            list.RemoveAll(x => x.Item1 == component);
        }

        private PendingComponents(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            _viewContextTextWriter = htmlHelper.ViewContext.Writer;
        }

        public static void Start(HtmlHelper htmlHelper)
        {
            List<Tuple<IComponent, TextWriter>> list = GetList(htmlHelper);
            if (list.Count > 0)
            {
                // If there are pending components, then there should be a pending writer somewhere in the output stack (probably at the top)
                PendingComponents pending = GetOutputStack(htmlHelper).OfType<PendingComponents>().FirstOrDefault();
                if (pending == null)
                {
                    throw new InvalidOperationException("Could not find a PendingComponentTextWriter when there are pending components (you should never see this).");
                }
                pending.Start();
            }
        }

        private void Start()
        {
            List<Tuple<IComponent, TextWriter>> list = GetList(_htmlHelper);
            while (list.Count > 0)
            {
                // Start() will remove the component
                list[0].Item1.Start(list[0].Item2, false);
            }
        }

        // Need to track the current TextWriter along with the component in case another one gets added to the OutputStack
        private static List<Tuple<IComponent, TextWriter>> GetList(HtmlHelper htmlHelper)
        {
            IDictionary items = htmlHelper.ViewContext.HttpContext.Items;
            List<Tuple<IComponent, TextWriter>> list = items[_bootstrapPendingListKey] as List<Tuple<IComponent, TextWriter>>;
            if (list == null)
            {
                list = new List<Tuple<IComponent, TextWriter>>();
                items[_bootstrapPendingListKey] = list;
            }
            return list;
        }

        private static Stack<TextWriter> GetOutputStack(HtmlHelper htmlHelper)
        {
            HtmlHelperExtensions.ProxyViewDataContainer proxyViewDataContainer = htmlHelper.ViewDataContainer as HtmlHelperExtensions.ProxyViewDataContainer;
            WebPageBase webPageBase = (proxyViewDataContainer == null ? htmlHelper.ViewDataContainer : proxyViewDataContainer.ViewDataContainer) as  WebPageBase;
            if(webPageBase == null)
            {
                throw new Exception ("Could not get WebPageBase which might be an indication Bootstrap is being used outside a page.");
            }
            return webPageBase.OutputStack;
        }

        public override Encoding Encoding
        {
            get { return _viewContextTextWriter.Encoding; }
        }

        public override void Write(bool value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(char value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(char[] buffer)
        {
            Start();
            _viewContextTextWriter.Write(buffer);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            Start();
            _viewContextTextWriter.Write(buffer, index, count);
        }

        public override void Write(decimal value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(double value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(float value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(int value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(long value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(object value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(string format, object arg0)
        {
            Start();
            _viewContextTextWriter.Write(format, arg0);
        }

        public override void Write(string format, object arg0, object arg1)
        {
            Start();
            _viewContextTextWriter.Write(format, arg0, arg1);
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            Start();
            _viewContextTextWriter.Write(format, arg0, arg1, arg2);
        }

        public override void Write(string format, params object[] arg)
        {
            Start();
            _viewContextTextWriter.Write(format, arg);
        }

        public override void Write(string value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(uint value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override void Write(ulong value)
        {
            Start();
            _viewContextTextWriter.Write(value);
        }

        public override Task WriteAsync(char value)
        {
            Start();
            return _viewContextTextWriter.WriteAsync(value);
        }

        public override Task WriteAsync(char[] buffer, int index, int count)
        {
            Start();
            return _viewContextTextWriter.WriteAsync(buffer, index, count);
        }

        public override Task WriteAsync(string value)
        {
            Start();
            return _viewContextTextWriter.WriteAsync(value);
        }

        public override void WriteLine()
        {
            Start();
            _viewContextTextWriter.WriteLine();
        }

        public override void WriteLine(bool value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(char value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(char[] buffer)
        {
            Start();
            _viewContextTextWriter.WriteLine(buffer);
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            Start();
            _viewContextTextWriter.WriteLine(buffer, index, count);
        }

        public override void WriteLine(decimal value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(double value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(float value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(int value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(long value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(object value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(string format, object arg0)
        {
            Start();
            _viewContextTextWriter.WriteLine(format, arg0);
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            Start();
            _viewContextTextWriter.WriteLine(format, arg0, arg1);
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            Start();
            _viewContextTextWriter.WriteLine(format, arg0, arg1, arg2);
        }

        public override void WriteLine(string format, params object[] arg)
        {
            Start();
            _viewContextTextWriter.WriteLine(format, arg);
        }

        public override void WriteLine(string value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(uint value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override void WriteLine(ulong value)
        {
            Start();
            _viewContextTextWriter.WriteLine(value);
        }

        public override Task WriteLineAsync()
        {
            Start();
            return _viewContextTextWriter.WriteLineAsync();
        }

        public override Task WriteLineAsync(char value)
        {
            Start();
            return _viewContextTextWriter.WriteLineAsync(value);
        }

        public override Task WriteLineAsync(char[] buffer, int index, int count)
        {
            Start();
            return _viewContextTextWriter.WriteLineAsync(buffer, index, count);
        }

        public override Task WriteLineAsync(string value)
        {
            Start();
            return _viewContextTextWriter.WriteLineAsync(value);
        }
    }
}
