using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Alerts
{
    public interface IAlertCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class AlertWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IAlert : ITag
    {
    }

    public class Alert<THelper> : Tag<THelper, Alert<THelper>, AlertWrapper<THelper>>, IAlert, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal bool Dismissible { set; get; }
        internal string Heading { set; get; }

        internal Alert(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Alert, Css.AlertInfo)
        {
            this.MergeAttribute("role", "alert");
        }

        protected override void OnStart(TextWriter writer)
        {
            if(Dismissible)
            {
                this.AddCss(Css.AlertDismissible);
            }

            base.OnStart(writer);

            if(Dismissible)
            {
                Helper.Element("button").MergeAttribute("type", "button").AddCss(Css.Close).MergeAttribute("data-dismiss", "alert")
                    .AddChild(_ => Helper.Span().MergeAttribute("aria-hidden", "true").SetText("&times;"))
                    .AddChild(_ => Helper.Span().AddCss(Css.SrOnly).SetText("Close"))
                    .StartAndFinish(writer);                    
            }

            if(!string.IsNullOrWhiteSpace(Heading))
            {
                Helper.Strong(Heading + " ").StartAndFinish(writer);
            }
        }
    }
}
