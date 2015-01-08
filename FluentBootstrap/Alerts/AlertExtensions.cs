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
        public static ComponentBuilder<Alert> Alert<TComponent>(this IComponentCreator<TComponent> creator, AlertState state, string text = null)
            where TComponent : Component, ICanCreate<Alert>
        {
            return new ComponentBuilder<Alert>(creator.Helper, new Alert(creator))
                .SetState(state).SetText(text);
        }

        public static ComponentBuilder<Alert> Alert<TComponent>(this IComponentCreator<TComponent> creator, AlertState state, string heading, string text)
            where TComponent : Component, ICanCreate<Alert>
        {
            return new ComponentBuilder<Alert>(creator.Helper, new Alert(creator))
                .SetState(state).SetHeading(heading).SetText(text);
        }

        public static ComponentBuilder<Alert> SetState(this ComponentBuilder<Alert> builder, AlertState state)
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        public static ComponentBuilder<Alert> SetHeading(this ComponentBuilder<Alert> builder, string heading)
        {
            builder.Component.Heading = heading;
            return builder;
        }

        public static ComponentBuilder<Alert> SetDismissible(this ComponentBuilder<Alert> builder, bool dismissible = true)
        {
            builder.Component.Dismissible = dismissible;
            return builder;
        }
    }
}
