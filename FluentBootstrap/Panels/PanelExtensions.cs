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

        public static Panel<TModel> Panel<TModel>(this IPanelCreator<TModel> creator, string title = null, int titleHeadingLevel = 4)
        {
            Panel<TModel> panel = new Panel<TModel>(creator);
            if (!string.IsNullOrWhiteSpace(title))
            {
                panel.AddChild(x => x.PanelHeading().AddChild(y => y.PanelTitle(title, titleHeadingLevel)));
            }
            return panel;
        }

        public static Panel<TModel> SetState<TModel>(this Panel<TModel> panel, PanelState state)
        {
            return panel.ToggleCss(state);
        }

        // Sections

        public static PanelHeading<TModel> PanelHeading<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelHeading<TModel>(creator);
        }

        public static PanelBody<TModel> PanelBody<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelBody<TModel>(creator);
        }

        public static PanelFooter<TModel> PanelFooter<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelFooter<TModel>(creator);
        }

        public static PanelTable<TModel> PanelTable<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelTable<TModel>(creator);
        }

        // PanelTitle

        public static PanelTitle<TModel> PanelTitle<TModel>(this IPanelTitleCreator<TModel> creator, string text = null, int headingLevel = 4)
        {
            return new PanelTitle<TModel>(creator, text, headingLevel);
        }
    }
}
