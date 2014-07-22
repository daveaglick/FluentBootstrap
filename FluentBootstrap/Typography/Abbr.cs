using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IAbbr : ITag
    {
    }

    public class Abbr<TModel> : Tag<TModel, Abbr<TModel>>, IAbbr, IHasTextAttribute
    {
        internal Abbr(BootstrapHelper<TModel> helper, string title, string abbreviation, params string[] cssClasses)
            : base(helper, "abbr", cssClasses)
        {
            this.MergeAttribute("title", title);
            TextContent = abbreviation;
        }
    }
}
