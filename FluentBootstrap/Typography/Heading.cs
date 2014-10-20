using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IHeadingCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class HeadingWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IHeading : ITag
    {
    }

    public class Heading<TModel> : Tag<TModel, Heading<TModel>, HeadingWrapper<TModel>>, IHeading, IHasTextAttribute
    {
        internal Heading(IComponentCreator<TModel> creator, string tagName, string text, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
            TextContent = text;
        }

        internal string SmallText { get; set; }

        protected override void OnFinish(TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(SmallText))
            {
                new Element<TModel>(Helper, "small").SetText(SmallText).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
