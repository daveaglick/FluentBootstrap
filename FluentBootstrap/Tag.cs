using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public class Tag : Component
    {
        private readonly string _tagName;
        private readonly List<Component> _children = new List<Component>();

        internal HashSet<string> CssClasses { get; private set; }
        internal Dictionary<string, string> Attributes { get; private set; }

        protected internal Tag(BootstrapHelper helper, string tagName, params string[] cssClasses) : base(helper)
        {
            CssClasses = new HashSet<string>();
            Attributes = new Dictionary<string, string>();
            _tagName = tagName;
            foreach (string cssClass in cssClasses)
                CssClasses.Add(cssClass);
        }

        internal void AddChild(Component component)
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

        internal void ToggleCssClass(string cssClass, bool add)
        {
            if (add)
            {
                CssClasses.Add(cssClass);
            }
            else
            {
                CssClasses.Remove(cssClass);
            }
        }

        protected override void OnStart(TextWriter writer)
        {
            // Append the start tag
            TagBuilder tag = new TagBuilder(_tagName);
            tag.MergeAttributes(Attributes);
            foreach (string cssClass in CssClasses)
            {
                tag.AddCssClass(cssClass);
            }
            writer.Write(tag.ToString(TagRenderMode.StartTag));

            // Append any children
            foreach (Component child in _children)
            {
                child.Start(writer);
                child.End(writer);
            }
        }

        protected override void OnEnd(TextWriter writer)
        {
            // Append the end tag
            TagBuilder tag = new TagBuilder(_tagName);
            writer.Write(tag.ToString(TagRenderMode.EndTag));
        }
    }
}
