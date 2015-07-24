using FluentBootstrap.Badges;
using FluentBootstrap.Html;
using FluentBootstrap.Links;
using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Icons;

namespace FluentBootstrap.ListGroups
{
    public class ListGroupButton : Tag, IHasIconExtensions, IHasDisabledAttribute, IHasTextContent, IHasValueAttribute,
        ICanCreate<Badge>
    {
        internal ListGroupButton(BootstrapHelper helper)
            : base(helper, "button", Css.ListGroupItem)
        {
            MergeAttribute("type", "button");
        }
    }
}
