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
            Panel<TModel> panel = new Panel<TModel>(creator.GetHelper());
            if (!string.IsNullOrWhiteSpace(title))
            {
                panel.Child(x => x.PanelTitle(title, titleHeadingLevel));
            }
            return panel;
        }

        public static Panel<TModel> Default<TModel>(this Panel<TModel> panel, bool @default = true)
        {
            return SetClass(panel, "panel-default", @default);
        }

        public static Panel<TModel> Primary<TModel>(this Panel<TModel> panel, bool @default = true)
        {
            return SetClass(panel, "panel-primary", @default);
        }

        public static Panel<TModel> Success<TModel>(this Panel<TModel> panel, bool @default = true)
        {
            return SetClass(panel, "panel-success", @default);
        }

        public static Panel<TModel> Info<TModel>(this Panel<TModel> panel, bool @default = true)
        {
            return SetClass(panel, "panel-info", @default);
        }

        public static Panel<TModel> Warning<TModel>(this Panel<TModel> panel, bool @default = true)
        {
            return SetClass(panel, "panel-warning", @default);
        }

        public static Panel<TModel> Danger<TModel>(this Panel<TModel> panel, bool @default = true)
        {
            return SetClass(panel, "panel-danger", @default);
        }       

        private static Panel<TModel> SetClass<TModel>(Panel<TModel> panel, string cls, bool add)
        {
            panel.ToggleCssClass(cls, add, "panel-default", "panel-primary", "panel-success", "panel-info", "panel-warning", "panel-danger");
            return panel;
        }

        // Sections

        public static PanelHeading<TModel> PanelHeading<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelHeading<TModel>(creator.GetHelper());
        }

        public static PanelBody<TModel> PanelBody<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelBody<TModel>(creator.GetHelper());
        }

        public static PanelFooter<TModel> PanelFooter<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelFooter<TModel>(creator.GetHelper());
        }

        public static PanelTable<TModel> PanelTable<TModel>(this IPanelSectionCreator<TModel> creator)
        {
            return new PanelTable<TModel>(creator.GetHelper());
        }

        // PanelTitle

        public static PanelTitle<TModel> PanelTitle<TModel>(this IPanelTitleCreator<TModel> creator, string text, int headingLevel = 4)
        {
            return new PanelTitle<TModel>(creator.GetHelper(), text, headingLevel);
        }
    }
}
