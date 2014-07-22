using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IHeading : ITag
    {
    }

    public class Heading<TModel> : Tag<TModel, Heading<TModel>>, IHeading, IHasTextAttribute
    {
        internal Heading(BootstrapHelper<TModel> helper, string tagName, string text, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
            TextContent = text;
        }

        internal string Small { get; set; }

        protected override void OnFinish(TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(Small))
            {
                new Element<TModel>(Helper, "small").Text(Small).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
