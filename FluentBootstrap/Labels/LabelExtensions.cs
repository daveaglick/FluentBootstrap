using FluentBootstrap.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class LabelExtensions
    {
        public static ComponentBuilder<TConfig, Label> Label<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Label>
        {
            return new ComponentBuilder<TConfig, Label>(helper.Config, new Label(helper))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Label> SetState<TConfig>(this ComponentBuilder<TConfig, Label> builder, LabelState state)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(state);
            return builder;
        }
    }
}
