using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    internal interface IElement : ITag
    {
    }

    public class Element<TModel> : Tag<TModel, Element<TModel>>, IElement
    {
        internal Element(BootstrapHelper<TModel> helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }
    }
}
