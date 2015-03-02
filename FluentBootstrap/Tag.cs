using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    public abstract class Tag : Component
    {
        protected readonly static object TagIndentKey = new object();
        protected readonly static object LastToWriteKey = new object();

        private string _tagName;
        public MergeableDictionary Attributes { get; private set; }
        public MergeableDictionary InlineStyles { get; private set; }
        public HashSet<string> CssClasses { get; private set; }
        private bool _startTagOutput;

        public string TextContent { get; set; }   // Can be used to set simple text content for the tag
        public bool PrettyPrint { get; set; }  // Set to false to suppress pretty printing, even if turned on globally (I.e., for links)
        public bool OutputEndTag { get; set; }

        protected Tag(BootstrapHelper helper, string tagName, params string[] cssClasses)
            : base(helper)
        {
            _tagName = tagName;
            CssClasses = new HashSet<string>();
            Attributes = new MergeableDictionary();
            InlineStyles = new MergeableDictionary();
            foreach (string cssClass in cssClasses.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                CssClasses.Add(cssClass);
            }
            PrettyPrint = helper.GetConfig().PrettyPrint;
            OutputEndTag = true;
        }

        // Setting this will create a new TagBuilder and copy over all items in Attributes
        // Note that you should not change this after OnStart has been called (otherwise you'll get different start and end tags)
        public string TagName
        {
            get { return _tagName; }
            set
            {
                if (_startTagOutput)
                {
                    throw new InvalidOperationException("Can't change tag name after the start tag has been output.");
                }
                _tagName = value;
            }
        }

        public void AddCss(params string[] cssClasses)
        {
            foreach (string cssClass in cssClasses)
            {
                CssClasses.Add(cssClass);
            }
        }

        public void RemoveCss(params string[] cssClasses)
        {
            foreach (string cssClass in cssClasses)
            {
                CssClasses.Remove(cssClass);
            }
        }

        public void MergeAttributes(object attributes)
        {
            Attributes.Merge(attributes);
        }

        public void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            Attributes.Merge(attributes);
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        public void MergeAttribute(string key, string value)
        {
            Attributes.Merge(key, value);
        }

        public string GetAttribute(string key)
        {
            return Attributes.GetValue(key);
        }

        public void MergeStyles(object attributes)
        {
            InlineStyles.Merge(attributes);
        }

        public void MergeStyles<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            InlineStyles.Merge(attributes);
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        public void MergeStyle(string key, string value)
        {
            InlineStyles.Merge(key, value);
        }

        public string GetStyle(string key)
        {
            return InlineStyles.GetValue(key);
        }

        public void ToggleCss(string cssClass, bool add, params string[] removeIfAdding)
        {
            if (add)
            {
                foreach (string remove in removeIfAdding)
                {
                    CssClasses.Remove(remove);
                }
                CssClasses.Add(cssClass);
            }
            else
            {
                CssClasses.Remove(cssClass);
            }
        }

        // This takes a flags enum and adds all css classes that are on and removes all that are off
        // Or if not flags, adds the current enum description and turns all others off
        // The CSS class is specified as a DescriptionAttribute on each enum value (use description of null to indicate a default state)
        public void ToggleCss(Enum css)
        {
            bool flags = css.GetType().GetCustomAttributes(typeof(FlagsAttribute), true).Any();
            foreach (Enum value in Enum.GetValues(css.GetType()))
            {
                string description = value.GetDescription();
                if (!string.IsNullOrWhiteSpace(description))
                {
                    ToggleCss(description, flags ? css.HasFlag(value) : css.Equals(value));
                }
            }
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the text content as a child
            if (!string.IsNullOrEmpty(TextContent))
            {
                this.AddChild(GetHelper().Content(TextContent));
            }

            base.OnStart(writer);

            // Pretty print
            if (PrettyPrint && !(writer is SuppressOutputWriter))
            {
                writer.WriteLine();
                int tagIndent = (int)Config.GetItem(TagIndentKey, 0);
                writer.Write(new String(' ', tagIndent++));
                Config.AddItem(TagIndentKey, tagIndent);
                Config.AddItem(LastToWriteKey, this);
            }
            else
            {
                PrettyPrint = false;
            }

            // Merge CSS classes
            if (CssClasses.Count > 0)
            {
                Attributes.Merge("class",
                    (Attributes.Dictionary.ContainsKey("class") ? Attributes.GetValue("class") + " " : string.Empty)
                    + string.Join(" ", CssClasses));
            }

            // Generate the inline CSS style
            if (InlineStyles.Dictionary.Count > 0)
            {
                Attributes.Merge("style", string.Join(" ", InlineStyles.Dictionary.Select(x => x.Key + ": " + x.Value + ";")));
            }

            // Append the start tag and any attributes
            StringBuilder startTag = new StringBuilder("<" + _tagName);
            foreach (KeyValuePair<string, string> attribute in Attributes.Dictionary)
            {
                // Skip over empty Ids
                if (string.Equals(attribute.Key, "id", StringComparison.Ordinal) && string.IsNullOrEmpty(attribute.Value))
                {
                    continue;
                }

                // We could suppress output of the value when the value is string.Empty, but leaving it there is still valid HTML5 and works better for other standards like XHTML
                // See https://html.spec.whatwg.org/multipage/infrastructure.html#boolean-attribute
                string encoded = HttpUtility.HtmlAttributeEncode(attribute.Value);
                startTag.Append(" " + attribute.Key + "=\"" + encoded + "\"");
            }
            startTag.Append(">");
            writer.Write(startTag.ToString());
            _startTagOutput = true;
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Pretty print
            if (PrettyPrint)
            {
                int tagIndent = ((int)Config.GetItem(TagIndentKey, 0)) - 1;
                Config.AddItem(TagIndentKey, tagIndent);
                Tag lastToWrite = Config.GetItem(LastToWriteKey, null) as Tag;
                if (lastToWrite != this)
                {
                    writer.WriteLine();
                    writer.Write(new String(' ', tagIndent));
                }
            }

            // Append the end tag
            if (OutputEndTag)
            {
                writer.Write("</" + _tagName + ">");
            }

            base.OnFinish(writer);
        }
    }
}
