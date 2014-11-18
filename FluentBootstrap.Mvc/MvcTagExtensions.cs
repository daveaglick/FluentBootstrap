using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace FluentBootstrap
{
    public static class MvcTagExtensions
    {
        public static TThis AddHtml<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, Func<dynamic, HelperResult> content)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            tag.AddChild(new Content<THelper>(tag.Helper,
                content(null).ToHtmlString()));
            return tag;
        }
    }
}
