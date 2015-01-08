using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Alerts
{
    public class Alert : Tag, IHasTextContent
    {
        public bool Dismissible { set; get; }
        public string Heading { set; get; }

        internal Alert(IComponentCreator creator)
            : base(creator, "div", Css.Alert, Css.AlertInfo)
        {
            MergeAttribute("role", "alert");
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Dismissible)
            {
                AddCss(Css.AlertDismissible);
            }

            base.OnStart(writer);

            if (Dismissible)
            {
                Helper.Element("button").AddAttribute("type", "button").AddCss(Css.Close).AddAttribute("data-dismiss", "alert")
                    .AddChild(_ => Helper.Span().AddAttribute("aria-hidden", "true").SetText("&times;"))
                    .AddChild(_ => Helper.Span().AddCss(Css.SrOnly).SetText("Close"))
                    .Component.StartAndFinish(writer);
            }

            if (!string.IsNullOrWhiteSpace(Heading))
            {
                Helper.Strong(Heading + " ").Component.StartAndFinish(writer);
            }
        }
    }
}
