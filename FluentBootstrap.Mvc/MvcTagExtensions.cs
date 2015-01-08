using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{
    public static class MvcTagExtensions
    {
        public static ComponentBuilder<THelper, TTag> AddHtml<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, Func<dynamic, HelperResult> content)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.GetComponent().AddChild(new Content(builder.GetWrapper(),
                content(null).ToHtmlString()));
            return builder;
        }
    }
}
