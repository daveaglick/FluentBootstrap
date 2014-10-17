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
    }

    public abstract class Tag<TModel, TThis, TWrapper> : Component<TModel, TThis, TWrapper>, ITag
        where TThis : Tag<TModel, TThis, TWrapper>
        where TWrapper : TagWrapper<TModel>, new()
    {
        internal TagBuilder TagBuilder { get; private set; }
        internal HashSet<string> CssClasses { get; private set; }

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
            foreach (string cssClass in cssClasses.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                CssClasses.Add(cssClass);
            }
        }

        internal TThis MergeAttributes(object attributes, bool replaceExisting = true)
        {
            if (attributes == null)
                return GetThis();
            MergeAttributes(System.Web.Mvc.HtmlHelper.AnonymousObjectToHtmlAttributes(attributes), replaceExisting);
            return GetThis();
        }

        internal TThis MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting = true)
        {
            if (attributes == null)
                return GetThis();
            foreach (KeyValuePair<TKey, TValue> attribute in attributes)
            {
                string key = Convert.ToString(attribute.Key, CultureInfo.InvariantCulture);
                string value = Convert.ToString(attribute.Value, CultureInfo.InvariantCulture);
                MergeAttribute(key, value, replaceExisting);
            }
            return GetThis();
        }

        // This works a little bit differently then the TagBuilder.MergeAttribute() method
        // This version does not throw on null or whitespace key and removes the attribute if value is null
        internal TThis MergeAttribute(string key, string value, bool replaceExisting = true)
        {
            if (string.IsNullOrWhiteSpace(key))
                return GetThis();
            if (value == null && replaceExisting && TagBuilder.Attributes.ContainsKey(key))
            {
                TagBuilder.Attributes.Remove(key);
            }
            else if (value != null && (replaceExisting || !TagBuilder.Attributes.ContainsKey(key)))
            {
                TagBuilder.Attributes[key] = value;
            }
            return GetThis();
        }

        void ITag.MergeAttribute(string key, string value, bool replaceExisting)
        {
            MergeAttribute(key, value, replaceExisting);
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

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);

            // Add the text content as a child
            if (!string.IsNullOrEmpty(TextContent))
            {
                this.AddChild(new Content<TModel>(Helper, TextContent));
            }
        }

        protected override void OnStart(TextWriter writer)
        {
            // Pretty print
            if (Bootstrap.PrettyPrint)
            {
                writer.WriteLine();
                writer.Write(new String(' ', Bootstrap.TagIndent++));
                Bootstrap.LastToWrite = this;
            }

            // Set CSS classes
            foreach (string cssClass in CssClasses)
            {
                TagBuilder.AddCssClass(cssClass);
            }

            // Append the start tag
            writer.Write(TagBuilder.ToString(TagRenderMode.StartTag));
        }

        protected virtual bool OutputEndTag
        {
            get { return true; }
        }
        
        protected override void OnFinish(TextWriter writer)
        {
            // Pretty print
            if (Bootstrap.PrettyPrint)
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
        }
    }
}
