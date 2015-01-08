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
        public static ComponentBuilder<THelper, Alert> Alert<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, AlertState state, string text = null)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Alert>
        {
            return new ComponentBuilder<THelper, Alert>(creator.Helper, new Alert(creator))
                .SetState(state).SetText(text);
        }

        public static ComponentBuilder<THelper, Alert> Alert<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, AlertState state, string heading, string text)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Alert>
        {
            return new ComponentBuilder<THelper, Alert>(creator.Helper, new Alert(creator))
                .SetState(state).SetHeading(heading).SetText(text);
        }

        public static ComponentBuilder<THelper, Alert> SetState<THelper>(this ComponentBuilder<THelper, Alert> builder, AlertState state)
            where THelper : BootstrapHelper<THelper>
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        public static ComponentBuilder<THelper, Alert> SetHeading<THelper>(this ComponentBuilder<THelper, Alert> builder, string heading)
            where THelper : BootstrapHelper<THelper>
        {
            builder.Component.Heading = heading;
            return builder;
        }

        public static ComponentBuilder<THelper, Alert> SetDismissible<THelper>(this ComponentBuilder<THelper, Alert> builder, bool dismissible = true)
            where THelper : BootstrapHelper<THelper>
        {
            builder.Component.Dismissible = dismissible;
            return builder;
        }
    }
}
