using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    public interface ITagCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public abstract class TagWrapper<THelper> : ComponentWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ITag : IComponent
    {
        HashSet<string> CssClasses { get; }
        void MergeAttributes(object attributes, bool replaceExisting = true);
        void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true);
        void MergeAttribute(string key, string value, bool replaceExisting = true);
        string GetAttribute(string key);
        void MergeStyle(string key, string value, bool replaceExisting = true);
        string GetStyle(string key);
    }

    public abstract class Tag<THelper, TThis, TWrapper> : Component<THelper, TThis, TWrapper>, ITag
        where THelper : BootstrapHelper<THelper>
        where TThis : Tag<THelper, TThis, TWrapper>
        where TWrapper : TagWrapper<THelper>, new()
    {
        private string _tagName;
        internal MergeableDictionary Attributes { get; private set; }
        internal MergeableDictionary InlineStyles { get; private set; }
        internal HashSet<string> CssClasses { get; private set; }
        private bool _startTagOutput;
        private bool _prettyPrint = Bootstrap.PrettyPrint;
        
        internal string TextContent { get; set; }   // Can be used to set simple text content for the tag

        protected internal Tag(IComponentCreator<THelper> creator, string tagName, params string[] cssClasses)
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
        }

        // Setting this will create a new TagBuilder and copy over all items in Attributes
        // Note that you should not change this after OnStart has been called (otherwise you'll get different start and end tags)
        internal string TagName
        {
            get { return _tagName; }
            set
            {
                if(_startTagOutput)
                {
                    throw new InvalidOperationException("Can't change tag name after the start tag has been output.");
                }
                _tagName = value;
            }
        }

        internal TThis MergeAttributes(object attributes, bool replaceExisting = true)
        {
            Attributes.Merge(attributes, replaceExisting);
            return this.GetThis();
        }

        internal TThis MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            Attributes.Merge(attributes, replaceExisting);
            return this.GetThis();
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        internal TThis MergeAttribute(string key, string value, bool replaceExisting = true)
        {
            Attributes.Merge(key, value, replaceExisting);
            return this.GetThis();
        }

        internal string GetAttribute(string key)
        {
            return Attributes.GetValue(key);
        }

        internal TThis MergeStyles(object attributes, bool replaceExisting = true)
        {
            InlineStyles.Merge(attributes, replaceExisting);
            return this.GetThis();
        }

        internal TThis MergeStyles<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            InlineStyles.Merge(attributes, replaceExisting);
            return this.GetThis();
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        internal TThis MergeStyle(string key, string value, bool replaceExisting = true)
        {
            InlineStyles.Merge(key, value, replaceExisting);
            return this.GetThis();
        }

        internal string GetStyle(string key)
        {
            return InlineStyles.GetValue(key);
        }

        internal TThis ToggleCss(string cssClass, bool add, params string[] removeIfAdding)
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
            return this.GetThis();
        }

        // This takes a flags enum and adds all css classes that are on and removes all that are off
        // Or if not flags, adds the current enum description and turns all others off
        // The CSS class is specified as a DescriptionAttribute on each enum value (use description of null to indicate a default state)
        internal TThis ToggleCss(Enum css)
        {
            bool flags = css.GetType().GetCustomAttributes(typeof(FlagsAttribute), true).Any();
            foreach(Enum value in Enum.GetValues(css.GetType()))
            {
                string description = value.GetDescription();
                if (!string.IsNullOrWhiteSpace(description))
                {
                    ToggleCss(description, flags ? css.HasFlag(value) : css.Equals(value));
                }
            }
            return this.GetThis();
        }

        HashSet<string> ITag.CssClasses
        {
            get { return CssClasses; }
        }

        void ITag.MergeAttributes(object attributes, bool replaceExisting)
        {
            MergeAttributes(attributes, replaceExisting);
        }

        void ITag.MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting)
        {
            MergeAttributes<TKey, TValue>(attributes, replaceExisting);
        }

        void ITag.MergeAttribute(string key, string value, bool replaceExisting)
        {
            MergeAttribute(key, value, replaceExisting);
        }

        string ITag.GetAttribute(string key)
        {
            return GetAttribute(key);
        }

        void ITag.MergeStyle(string key, string value, bool replaceExisting)
        {
            MergeStyle(key, value, replaceExisting);
        }

        string ITag.GetStyle(string key)
        {
            return GetStyle(key);
        }

        protected virtual bool OutputEndTag
        {
            get { return true; }
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the text content as a child
            if (!string.IsNullOrEmpty(TextContent))
            {
                this.AddChild(new Content<THelper>(Helper, TextContent));
            }

            base.OnStart(writer);

            // Pretty print
            if (_prettyPrint && !(writer is SuppressOutputWriter))
            {
                writer.WriteLine();
                writer.Write(new String(' ', Bootstrap.TagIndent++));
                Bootstrap.LastToWrite = this;
            }
            else
            {
                _prettyPrint = false;
            }

            // Merge CSS classes
            if(CssClasses.Count > 0)
            {
                Attributes.Merge("class",
                    (Attributes.Dictionary.ContainsKey("class") ? Attributes.GetValue("class") + " " : string.Empty)
                    + string.Join(" ", CssClasses.Reverse()));  // TODO: Remove the reverse call
            }

            // Generate the inline CSS style
            if(InlineStyles.Dictionary.Count > 0)
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
        
        protected override void OnFinish(TextWriter writer)
        {
            // Pretty print
            if (_prettyPrint)
            {
                Bootstrap.TagIndent--;
                if (Bootstrap.LastToWrite != this)
                {
                    writer.WriteLine();
                    writer.Write(new String(' ', Bootstrap.TagIndent));
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
