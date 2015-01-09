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
        public static ComponentBuilder<TConfig, TTag> AddHtml<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, Func<dynamic, HelperResult> content)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.GetComponent().AddChild(builder.GetHelper().Content(content(null).ToHtmlString()).GetComponent());
            return builder;
        }
    }
}
