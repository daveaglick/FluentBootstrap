using FluentBootstrap.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class AlertExtensions
    {
        public static Alert<TModel> Alert<TModel>(this IAlertCreator<TModel> creator, AlertState state, string text = null)
        {
            return new Alert<TModel>(creator).SetState(state).SetText(text);
        }

        public static Alert<TModel> Alert<TModel>(this IAlertCreator<TModel> creator, AlertState state, string heading, string text)
        {
            return new Alert<TModel>(creator).SetState(state).SetHeading(heading).SetText(text);
        }

        public static Alert<TModel> SetState<TModel>(this Alert<TModel> alert, AlertState state)
        {
            return alert.ToggleCss(state);
        }

        public static Alert<TModel> SetHeading<TModel>(this Alert<TModel> alert, string heading)
        {
            alert.Heading = heading;
            return alert;
        }

        public static Alert<TModel> SetDismissible<TModel>(this Alert<TModel> alert, bool dismissible = true)
        {
            alert.Dismissible = dismissible;
            return alert;
        }
    }
}
