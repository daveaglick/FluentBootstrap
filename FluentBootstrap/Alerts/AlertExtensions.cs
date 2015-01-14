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
        public static ComponentBuilder<TConfig, Alert> Alert<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, AlertState state, string text = null)
            where TConfig: BootstrapConfig
            where TComponent : Component, ICanCreate<Alert>
        {
            return new ComponentBuilder<TConfig, Alert>(helper.Config, new Alert(helper))
                .SetState(state)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Alert> Alert<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, AlertState state, string heading, string text)
            where TConfig: BootstrapConfig
            where TComponent : Component, ICanCreate<Alert>
        {
            return new ComponentBuilder<TConfig, Alert>(helper.Config, new Alert(helper))
                .SetState(state)
                .SetHeading(heading)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Alert> SetState<TConfig>(this ComponentBuilder<TConfig, Alert> builder, AlertState state)
            where TConfig: BootstrapConfig
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        public static ComponentBuilder<TConfig, Alert> SetHeading<TConfig>(this ComponentBuilder<TConfig, Alert> builder, string heading)
            where TConfig: BootstrapConfig
        {
            builder.Component.Heading = heading;
            return builder;
        }

        public static ComponentBuilder<TConfig, Alert> SetDismissible<TConfig>(this ComponentBuilder<TConfig, Alert> builder, bool dismissible = true)
            where TConfig: BootstrapConfig
        {
            builder.Component.Dismissible = dismissible;
            return builder;
        }
    }
}
