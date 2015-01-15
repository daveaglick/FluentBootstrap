using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Panels;

namespace FluentBootstrap
{
    public static class PanelExtensions
    {
        // Panel

        public static ComponentBuilder<TConfig, Panel> Panel<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string title = null, int titleHeadingLevel = 4)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Panel>
        {
            ComponentBuilder<TConfig, Panel> builder = new ComponentBuilder<TConfig, Panel>(helper.Config, new Panel(helper));
            if (!string.IsNullOrWhiteSpace(title))
            {
                builder.AddChild(x => x.PanelHeading().AddChild(y => y.PanelTitle(title, titleHeadingLevel)));
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, Panel> SetState<TConfig>(this ComponentBuilder<TConfig, Panel> builder, PanelState state)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        // Sections

        public static ComponentBuilder<TConfig, PanelHeading> PanelHeading<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<PanelHeading>
        {
            return new ComponentBuilder<TConfig, PanelHeading>(helper.Config, new PanelHeading(helper));
        }

        public static ComponentBuilder<TConfig, PanelBody> PanelBody<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<PanelBody>
        {
            return new ComponentBuilder<TConfig, PanelBody>(helper.Config, new PanelBody(helper));
        }

        public static ComponentBuilder<TConfig, PanelFooter> PanelFooter<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<PanelFooter>
        {
            return new ComponentBuilder<TConfig, PanelFooter>(helper.Config, new PanelFooter(helper));
        }

        public static ComponentBuilder<TConfig, PanelTable> PanelTable<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<PanelTable>
        {
            return new ComponentBuilder<TConfig, PanelTable>(helper.Config, new PanelTable(helper));
        }

        // PanelTitle

        public static ComponentBuilder<TConfig, PanelTitle> PanelTitle<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null, int headingLevel = 4)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<PanelTitle>
        {
            return new ComponentBuilder<TConfig, PanelTitle>(helper.Config, new PanelTitle(helper, text, headingLevel));
        }
    }
}
