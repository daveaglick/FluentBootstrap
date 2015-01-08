//using FluentBootstrap.ListGroups;
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
        public Paragraph(IComponentCreator creator)
            : base(creator, "p")
        {
        }

        protected override void OnStart<THelper>(THelper helper, TextWriter writer)
        {
            // TODO: Add the appropriate CSS class if in a list group item
            //if (GetComponent<IListGroupItem>() != null)
            //{
            //    this.AddCss(Css.ListGroupItemText);
            //}

            base.OnStart(helper, writer);
        }
    }
}
