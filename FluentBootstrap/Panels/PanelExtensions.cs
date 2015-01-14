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

        public static Panel<TConfig> Panel<TConfig>(this IPanelCreator<TConfig> creator, string title = null, int titleHeadingLevel = 4)
            where TConfig : BootstrapConfig
        {
            Panel<TConfig> panel = new Panel<TConfig>(creator);
            if (!string.IsNullOrWhiteSpace(title))
            {
                panel.AddChild(x => x.PanelHeading().AddChild(y => y.PanelTitle(title, titleHeadingLevel)));
            }
            return panel;
        }

        public static Panel<TConfig> SetState<TConfig>(this Panel<TConfig> panel, PanelState state)
            where TConfig : BootstrapConfig
        {
            return panel.ToggleCss(state);
        }

        // Sections

        public static PanelHeading<TConfig> PanelHeading<TConfig>(this IPanelSectionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new PanelHeading<TConfig>(creator);
        }

        public static PanelBody<TConfig> PanelBody<TConfig>(this IPanelSectionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new PanelBody<TConfig>(creator);
        }

        public static PanelFooter<TConfig> PanelFooter<TConfig>(this IPanelSectionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new PanelFooter<TConfig>(creator);
        }

        public static PanelTable<TConfig> PanelTable<TConfig>(this IPanelSectionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new PanelTable<TConfig>(creator);
        }

        // PanelTitle

        public static PanelTitle<TConfig> PanelTitle<TConfig>(this IPanelTitleCreator<TConfig> creator, string text = null, int headingLevel = 4)
            where TConfig : BootstrapConfig
        {
            return new PanelTitle<TConfig>(creator, text, headingLevel);
        }
    }
}
