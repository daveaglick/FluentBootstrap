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

        public static Panel<THelper> Panel<THelper>(this IPanelCreator<THelper> creator, string title = null, int titleHeadingLevel = 4)
            where THelper : BootstrapHelper<THelper>
        {
            Panel<THelper> panel = new Panel<THelper>(creator);
            if (!string.IsNullOrWhiteSpace(title))
            {
                panel.AddChild(x => x.PanelHeading().AddChild(y => y.PanelTitle(title, titleHeadingLevel)));
            }
            return panel;
        }

        public static Panel<THelper> SetState<THelper>(this Panel<THelper> panel, PanelState state)
            where THelper : BootstrapHelper<THelper>
        {
            return panel.ToggleCss(state);
        }

        // Sections

        public static PanelHeading<THelper> PanelHeading<THelper>(this IPanelSectionCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new PanelHeading<THelper>(creator);
        }

        public static PanelBody<THelper> PanelBody<THelper>(this IPanelSectionCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new PanelBody<THelper>(creator);
        }

        public static PanelFooter<THelper> PanelFooter<THelper>(this IPanelSectionCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new PanelFooter<THelper>(creator);
        }

        public static PanelTable<THelper> PanelTable<THelper>(this IPanelSectionCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new PanelTable<THelper>(creator);
        }

        // PanelTitle

        public static PanelTitle<THelper> PanelTitle<THelper>(this IPanelTitleCreator<THelper> creator, string text = null, int headingLevel = 4)
            where THelper : BootstrapHelper<THelper>
        {
            return new PanelTitle<THelper>(creator, text, headingLevel);
        }
    }
}
