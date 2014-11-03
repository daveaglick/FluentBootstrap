using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public interface ITagCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public abstract class TagWrapper<TModel> : ComponentWrapper<TModel>
    {
    }

    internal interface ITag : IComponent
    {
        HashSet<string> CssClasses { get; }
        void MergeAttribute(string key, string value, bool replaceExisting = true);
        string GetAttribute(string key);
        void MergeStyle(string key, string value, bool replaceExisting = true);
        string GetStyle(string key);
    }

    public abstract class Tag<TModel, TThis, TWrapper> : Component<TModel, TThis, TWrapper>, ITag
        where TThis : Tag<TModel, TThis, TWrapper>
        where TWrapper : TagWrapper<TModel>, new()
    {
        internal TagBuilder TagBuilder { get; private set; }
        internal MergeableDictionary Attributes { get; private set; }
        internal MergeableDictionary InlineStyles { get; private set; }
        internal HashSet<string> CssClasses { get; private set; }
        private bool _startTagOutput;
        private bool _prettyPrint = Bootstrap.PrettyPrint;

        HashSet<string> ITag.CssClasses
        {
            get { return CssClasses; }
        }

        internal string TextContent { get; set; }   // Can be used to set simple text content for the tag

        protected internal Tag(IComponentCreator<TModel> creator, string tagName, params string[] cssClasses)
            : base(creator)
        {
            TagBuilder = new TagBuilder(tagName);
            CssClasses = new HashSet<string>();
            Attributes = new MergeableDictionary(TagBuilder.Attributes);
            InlineStyles = new MergeableDictionary(null);
            foreach (string cssClass in cssClasses.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                CssClasses.Add(cssClass);
            }
        }

        // Setting this will create a new TagBuilder and copy over all items in Attributes
        // Note that you should not change this after OnStart has been called (otherwise you'll get different start and end tags)
        internal string TagName
        {
            get { return TagBuilder.TagName; }
            set
            {
                if(_startTagOutput)
                {
                    throw new InvalidOperationException("Can't change tag name after the start tag has been output.");
                }
                TagBuilder oldTagBuilder = TagBuilder;
                TagBuilder = new TagBuilder(value);
                foreach (KeyValuePair<string, string> attribute in oldTagBuilder.Attributes)
                {
                    TagBuilder.Attributes.Add(attribute);
                }
                Attributes = new MergeableDictionary(TagBuilder.Attributes);
            }
        }

        internal TThis MergeAttributes(object attributes, bool replaceExisting = true)
        {
            Attributes.Merge(attributes, replaceExisting);
            return GetThis();
        }

        internal TThis MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            Attributes.Merge(attributes, replaceExisting);
            return GetThis();
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        internal TThis MergeAttribute(string key, string value, bool replaceExisting = true)
        {
            Attributes.Merge(key, value, replaceExisting);
            return GetThis();
        }

        void ITag.MergeAttribute(string key, string value, bool replaceExisting)
        {
            Attributes.Merge(key, value, replaceExisting);
        }

        string ITag.GetAttribute(string key)
        {
            return Attributes.GetValue(key);
        }

        internal TThis MergeStyles(object attributes, bool replaceExisting = true)
        {
            InlineStyles.Merge(attributes, replaceExisting);
            return GetThis();
        }

        internal TThis MergeStyles<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            InlineStyles.Merge(attributes, replaceExisting);
            return GetThis();
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        internal TThis MergeStyle(string key, string value, bool replaceExisting = true)
        {
            InlineStyles.Merge(key, value, replaceExisting);
            return GetThis();
        }

        void ITag.MergeStyle(string key, string value, bool replaceExisting)
        {
            InlineStyles.Merge(key, value, replaceExisting);
        }

        string ITag.GetStyle(string key)
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
            return GetThis();
        }

        // This takes a flags enum and adds all css classes that are on and removes all that are off
        // Or if not flags, adds the current enum description and turns all others off
        // The CSS class is specified as a DescriptionAttribute on each enum value (use description of null to indicate a default state)
        internal TThis ToggleCss(Enum css)
        {
            bool flags = css.GetType().GetCustomAttributes<FlagsAttribute>().Any();
            foreach(Enum value in Enum.GetValues(css.GetType()))
            {
                string description = value.GetDescription();
                if (!string.IsNullOrWhiteSpace(description))
                {
                    ToggleCss(description, flags ? css.HasFlag(value) : css.Equals(value));
                }
            }
            return GetThis();
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
                this.AddChild(new Content<TModel>(Helper, TextContent));
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

            // Set CSS classes
            foreach (string cssClass in CssClasses)
            {
                TagBuilder.AddCssClass(cssClass);
            }

            // Generate the inline CSS style
            if(InlineStyles.Dictionary.Count > 0)
            {
                Attributes.Merge("style", string.Join(" ", InlineStyles.Dictionary.Select(x => x.Key + ": " + x.Value + ";")));
            }

            // Append the start tag
            writer.Write(TagBuilder.ToString(TagRenderMode.StartTag));
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
                writer.Write(TagBuilder.ToString(TagRenderMode.EndTag));
            }

            base.OnFinish(writer);
        }
    }
}
