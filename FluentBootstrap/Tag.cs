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
        private string _tagName;
        internal MergeableDictionary Attributes { get; private set; }
        internal MergeableDictionary InlineStyles { get; private set; }
        internal HashSet<string> CssClasses { get; private set; }
        private bool _startTagOutput;
        private bool _prettyPrint;

        internal string TextContent { get; set; }   // Can be used to set simple text content for the tag

        protected internal Tag(IComponentCreator creator, string tagName, params string[] cssClasses)
            : base(creator)
        {
            _tagName = tagName;
            CssClasses = new HashSet<string>();
            Attributes = new MergeableDictionary();
            InlineStyles = new MergeableDictionary();
            foreach (string cssClass in cssClasses.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                CssClasses.Add(cssClass);
            }
            _prettyPrint = creator.GetHelper().PrettyPrint;
        }

        // Setting this will create a new TagBuilder and copy over all items in Attributes
        // Note that you should not change this after OnStart has been called (otherwise you'll get different start and end tags)
        internal string TagName
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

        internal void AddCss(params string[] cssClasses)
        {
            foreach (string cssClass in cssClasses)
            {
                CssClasses.Add(cssClass);
            }
        }

        internal void RemoveCss(params string[] cssClasses)
        {
            foreach (string cssClass in cssClasses)
            {
                CssClasses.Remove(cssClass);
            }
        }

        internal void MergeAttributes(object attributes, bool replaceExisting = true)
        {
            Attributes.Merge(attributes, replaceExisting);
        }

        internal void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            Attributes.Merge(attributes, replaceExisting);
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        internal void MergeAttribute(string key, string value, bool replaceExisting = true)
        {
            Attributes.Merge(key, value, replaceExisting);
        }

        internal string GetAttribute(string key)
        {
            return Attributes.GetValue(key);
        }

        internal void MergeStyles(object attributes, bool replaceExisting = true)
        {
            InlineStyles.Merge(attributes, replaceExisting);
        }

        internal void MergeStyles<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            InlineStyles.Merge(attributes, replaceExisting);
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        internal void MergeStyle(string key, string value, bool replaceExisting = true)
        {
            InlineStyles.Merge(key, value, replaceExisting);
        }

        internal string GetStyle(string key)
        {
            return InlineStyles.GetValue(key);
        }

        internal void ToggleCss(string cssClass, bool add, params string[] removeIfAdding)
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
        internal void ToggleCss(Enum css)
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

        protected virtual bool OutputEndTag
        {
            get { return true; }
        }

        protected override void OnStart<THelper>(THelper helper, TextWriter writer)
        {
            // Add the text content as a child
            if (!string.IsNullOrEmpty(TextContent))
            {
                this.AddChild(new Content(helper, TextContent));
            }

            base.OnStart(helper, writer);

            // Pretty print
            if (_prettyPrint && !(writer is SuppressOutputWriter))
            {
                writer.WriteLine();
                int tagIndent = (int)helper.GetItem(TagIndentKey, 0);
                writer.Write(new String(' ', tagIndent++));
                helper.AddItem(TagIndentKey, tagIndent);
                helper.AddItem(LastToWriteKey, this);
            }
            else
            {
                _prettyPrint = false;
            }

            // Merge CSS classes
            if (CssClasses.Count > 0)
            {
                Attributes.Merge("class",
                    (Attributes.Dictionary.ContainsKey("class") ? Attributes.GetValue("class") + " " : string.Empty)
                    + string.Join(" ", CssClasses.Reverse()));  // TODO: Remove the reverse call
            }

            // Generate the inline CSS style
            if (InlineStyles.Dictionary.Count > 0)
            {
                Attributes.Merge("style", string.Join(" ", InlineStyles.Dictionary.Select(x => x.Key + ": " + x.Value + ";")));
            }

            // Append the start tag
            StringBuilder startTag = new StringBuilder("<" + _tagName);
            foreach (KeyValuePair<string, string> attribute in Attributes.Dictionary.Reverse()) // TODO: Remove the reverse call
            {
                if (string.Equals(attribute.Key, "id", StringComparison.Ordinal) && string.IsNullOrEmpty(attribute.Value))
                {
                    continue;
                }
                string encoded = HttpUtility.HtmlAttributeEncode(attribute.Value);
                startTag.Append(" " + attribute.Key + "=\"" + encoded + "\"");
            }
            startTag.Append(">");
            writer.Write(startTag.ToString());
            _startTagOutput = true;
        }

        protected override void OnFinish<THelper>(THelper helper, TextWriter writer)
        {
            // Pretty print
            if (_prettyPrint)
            {
                int tagIndent = ((int)helper.GetItem(TagIndentKey, 0)) - 1;
                helper.AddItem(TagIndentKey, tagIndent);
                Tag lastToWrite = helper.GetItem(LastToWriteKey, null) as Tag;
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

            base.OnFinish(helper, writer);
        }
    }
}
