using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Alerts
{
    public interface IAlertCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class AlertWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IAlert : ITag
    {
    }

    public class Alert<TModel> : Tag<TModel, Alert<TModel>, AlertWrapper<TModel>>, IAlert, IHasTextContent
    {
        internal bool Dismissible { set; private get; }
        internal string Heading { set; private get; }

        internal Alert(IComponentCreator<TModel> creator)
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
