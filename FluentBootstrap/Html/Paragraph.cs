using FluentBootstrap.ListGroups;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    public class Paragraph : Tag, IHasTextContent
    {
        internal Paragraph(BootstrapHelper helper)
            : base(helper, "p")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the appropriate CSS class if in a list group item
            if (GetComponent<ListGroupItem>() != null)
            {
                AddCss(Css.ListGroupItemText);
            }

            base.OnStart(writer);
        }
    }
}
