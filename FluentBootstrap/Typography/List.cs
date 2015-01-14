using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public class List : Tag,
        ICanCreate<ListItem>
    {
        internal List(BootstrapHelper helper, ListType listType)
            : base(helper, listType == ListType.Ordered ? "ol" : "ul", 
                listType == ListType.Unstyled ? Css.ListUnstyled : null,
                listType == ListType.Inline ? Css.ListInline : null)
        {
        }
    }
}
