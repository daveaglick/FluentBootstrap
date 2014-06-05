using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public abstract class BootstrapComponent : IDisposable, IHtmlString
    {
        private bool _started;
        private bool _ended;

        private readonly string _tagName;
        private readonly List<BootstrapComponent> _children = new List<BootstrapComponent>();
        private readonly StringBuilder _content = new StringBuilder();

        internal BootstrapHelper Helper { get; private set; }
        internal HashSet<string> CssClasses { get; private set; }
        internal Dictionary<string, string> Attributes { get; private set; }

        protected internal BootstrapComponent(string tagName, BootstrapHelper helper, params string[] cssClasses)
        {
            CssClasses = new HashSet<string>();
            Attributes = new Dictionary<string, string>();
            _tagName = tagName;
            Helper = helper;
            foreach (string cssClass in cssClasses)
                CssClasses.Add(cssClass);
        }

        public void Dispose()
        {
            throw new InvalidOperationException("A component was directly disposed, which is usually an indication that it needs to be passed as an argument to Html.Bootstrap([component]).");
        }

        internal void AddChild(BootstrapComponent component)
        {
            _children.Add(component);
        }

        internal void MergeAttributes(object attributes, bool replaceExisting = true)
        {
            if (attributes == null)
                return;
            MergeAttributes(System.Web.Mvc.HtmlHelper.AnonymousObjectToHtmlAttributes(attributes), replaceExisting);
        }

        internal void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            if (attributes == null)
                return;
            foreach (KeyValuePair<TKey, TValue> attribute in attributes)
            {
                string key = Convert.ToString(attribute.Key, CultureInfo.InvariantCulture);
                string value = Convert.ToString(attribute.Value, CultureInfo.InvariantCulture);
                MergeAttribute(key, value, replaceExisting);
            }
        }

        internal void MergeAttribute(string key, string value, bool replaceExisting = true)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (value == null && replaceExisting && Attributes.ContainsKey(key))
            {
                Attributes.Remove(key);
            }
            else if (value != null && (replaceExisting || !Attributes.ContainsKey(key)))
            {
                Attributes[key] = value;
            }
        }

        internal void AppendContent(string content)
        {
            _content.Append(content);
        }

        // If any manipulation based on the component stack has to happen, do it in an
        // override of Start() and make sure to call base.Start() when done
        internal virtual string Start()
        {
            // Only write content once
            if (_started)
                throw new InvalidOperationException("This component has already generated starting content.");
            _started = true;

            // Add this component to the stack
            Helper.PushComponent(this);

            // Append the start tag
            StringBuilder stringBuilder = new StringBuilder();
            TagBuilder tag = new TagBuilder(_tagName);
            tag.MergeAttributes(Attributes);
            foreach (string cssClass in CssClasses)
            {
                tag.AddCssClass(cssClass);
            }
            stringBuilder.Append(tag.ToString(TagRenderMode.StartTag));

            // Append any content
            stringBuilder.Append(_content.ToString());

            // Append any children
            foreach (BootstrapComponent child in _children)
            {
                stringBuilder.Append(child.ToHtmlString());
            }

            return stringBuilder.ToString();
        }

        internal virtual string End()
        {
            // Only write content once
            if (_ended)
                throw new InvalidOperationException("This component has already generated ending content.");
            _ended = true;

            // Append the end tag
            StringBuilder stringBuilder = new StringBuilder();
            TagBuilder tag = new TagBuilder(_tagName);
            stringBuilder.Append(tag.ToString(TagRenderMode.EndTag));

            // Remove this component from the stack
            Helper.PopComponent(this);

            return stringBuilder.ToString();
        }

        // Outputs the start and end portions together
        public virtual string ToHtmlString()
        {
            return Start() + End();
        }
    }
}
