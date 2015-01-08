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
        internal bool Dismissible { set; get; }
        internal string Heading { set; get; }

        internal Alert(IComponentCreator creator)
            : base(creator, "div", Css.Alert, Css.AlertInfo)
        {
            MergeAttribute("role", "alert");
        }

        protected override void OnStart<THelper>(THelper helper, TextWriter writer)
        {
            if (Dismissible)
            {
                AddCss(Css.AlertDismissible);
            }

            base.OnStart(helper, writer);

            if (Dismissible)
            {
                helper.Element("button").AddAttribute("type", "button").AddCss(Css.Close).AddAttribute("data-dismiss", "alert")
                    .AddChild(_ => helper.Span().AddAttribute("aria-hidden", "true").SetText("&times;"))
                    .AddChild(_ => helper.Span().AddCss(Css.SrOnly).SetText("Close"))
                    .Component.StartAndFinish(helper, writer);
            }

            if (!string.IsNullOrWhiteSpace(Heading))
            {
                helper.Strong(Heading + " ").Component.StartAndFinish(helper, writer);
            }
        }
    }
}
