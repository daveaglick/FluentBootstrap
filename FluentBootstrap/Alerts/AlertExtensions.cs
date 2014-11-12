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
        public static Alert<THelper> Alert<THelper>(this IAlertCreator<THelper> creator, AlertState state, string text = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new Alert<THelper>(creator).SetState(state).SetText(text);
        }

        public static Alert<THelper> Alert<THelper>(this IAlertCreator<THelper> creator, AlertState state, string heading, string text)
            where THelper : BootstrapHelper<THelper>
        {
            return new Alert<THelper>(creator).SetState(state).SetHeading(heading).SetText(text);
        }

        public static Alert<THelper> SetState<THelper>(this Alert<THelper> alert, AlertState state)
            where THelper : BootstrapHelper<THelper>
        {
            return alert.ToggleCss(state);
        }

        public static Alert<THelper> SetHeading<THelper>(this Alert<THelper> alert, string heading)
            where THelper : BootstrapHelper<THelper>
        {
            alert.Heading = heading;
            return alert;
        }

        public static Alert<THelper> SetDismissible<THelper>(this Alert<THelper> alert, bool dismissible = true)
            where THelper : BootstrapHelper<THelper>
        {
            alert.Dismissible = dismissible;
            return alert;
        }
    }
}
