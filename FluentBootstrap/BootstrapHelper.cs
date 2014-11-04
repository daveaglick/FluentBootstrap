using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap
{
    // This just provides access to top-level extensions
    public class BootstrapHelper<TModel> : 
        ITagCreator<TModel>,
        // Alerts
        Alerts.IAlertCreator<TModel>,
        // Badges
        Badges.IBadgeCreator<TModel>,
        // Breadcrumbs
        Breadcrumbs.IBreadcrumbCreator<TModel>,
        // Buttons
        Buttons.IButtonToolbarCreator<TModel>,
        Buttons.IButtonGroupCreator<TModel>,
        Buttons.IDropdownButtonCreator<TModel>,
        Buttons.IButtonCreator<TModel>,
        Buttons.ILinkButtonCreator<TModel>,
        // Dropdowns
        Dropdowns.IDropdownCreator<TModel>,
        // Forms
        Forms.IFormCreator<TModel>,
        // Grids
        Grids.IContainerCreator<TModel>,
        Grids.IGridRowCreator<TModel>,
        // Images
        Images.IImageCreator<TModel>,
        // Labels
        Labels.ILabelCreator<TModel>,
        // Links
        Links.ILinkCreator<TModel>,
        // Media Objects
        MediaObjects.IMediaCreator<TModel>,
        MediaObjects.IMediaListCreator<TModel>,
        // Misc
        Misc.IJumbotronCreator<TModel>,
        Misc.IPageHeaderCreator<TModel>,
        // Navbars,
        Navbars.INavbarCreator<TModel>,
        // Navs
        Navs.ITabsCreator<TModel>,
        Navs.IPillsCreator<TModel>,
        // Pagers
        Pagers.IPagerCreator<TModel>,
        // Pagination
        Paginations.IPaginationCreator<TModel>,
        // Panels
        Panels.IPanelCreator<TModel>,
        // Progress Bars
        ProgressBars.IProgressCreator<TModel>,
        ProgressBars.IProgressBarCreator<TModel>,
        // Tables
        Tables.ITableCreator<TModel>,
        // Thumbnails
        Thumbnails.IThumbnailCreator<TModel>,
        Thumbnails.IThumbnailContainerCreator<TModel>,
        // Typography
        Typography.ISmallCreator<TModel>,
        Typography.IListCreator<TModel>,
        Typography.IDescriptionListCreator<TModel>
    {
        public HtmlHelper<TModel> HtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper<TModel> htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        public BootstrapHelper<TModel> GetHelper()
        {
            return this;
        }

        public Component GetParent()
        {
            return null;
        }

        public BootstrapHelperAll<TModel> All()
        {
            return new BootstrapHelperAll<TModel>(HtmlHelper);
        }
    }

    // This provides expanded access to all extensions
    public class BootstrapHelperAll<TModel> : BootstrapHelper<TModel>,
        ITagCreator<TModel>,
        // Alerts
        Alerts.IAlertCreator<TModel>,
        // Badges
        Badges.IBadgeCreator<TModel>,
        // Breadcrumbs
        Breadcrumbs.IBreadcrumbCreator<TModel>,
        Breadcrumbs.ICrumbCreator<TModel>,
        // Buttons
        Buttons.IButtonToolbarCreator<TModel>,
        Buttons.IButtonGroupCreator<TModel>,
        Buttons.IDropdownButtonCreator<TModel>,
        Buttons.IButtonCreator<TModel>,
        Buttons.ILinkButtonCreator<TModel>,
        // Dropdowns
        Dropdowns.IDropdownCreator<TModel>,
        Dropdowns.IDropdownDividerCreator<TModel>,
        Dropdowns.IDropdownHeaderCreator<TModel>,
        Dropdowns.IDropdownLinkCreator<TModel>,
        // Forms
        Forms.IFormCreator<TModel>,
        Forms.IFieldSetCreator<TModel>,
        Forms.IFormGroupCreator<TModel>,
        Forms.IControlLabelCreator<TModel>,
        Forms.IFormControlCreator<TModel>,
        Forms.IHelpBlockCreator<TModel>,
        Forms.IInputGroupCreator<TModel>,
        Forms.IInputGroupAddonCreator<TModel>,
        Forms.IInputGroupButtonCreator<TModel>,
        // Grids
        Grids.IContainerCreator<TModel>,
        Grids.IGridColumnCreator<TModel>,
        Grids.IGridRowCreator<TModel>,
        // Images
        Images.IImageCreator<TModel>,
        // Labels
        Labels.ILabelCreator<TModel>,
        // Links
        Links.ILinkCreator<TModel>,
        // Media Objects
        MediaObjects.IMediaCreator<TModel>,
        MediaObjects.IMediaListCreator<TModel>,
        MediaObjects.IMediaObjectCreator<TModel>,
        MediaObjects.IMediaBodyCreator<TModel>,
        // Misc
        Misc.IJumbotronCreator<TModel>,
        Misc.IPageHeaderCreator<TModel>,
        // Navbars,
        Navbars.INavbarCreator<TModel>,
        Navbars.INavbarHeaderCreator<TModel>,
        Navbars.INavbarToggleCreator<TModel>,
        Navbars.IBrandCreator<TModel>,
        Navbars.INavbarCollapseCreator<TModel>,
        Navbars.INavbarNavCreator<TModel>,
        Navbars.INavbarFormCreator<TModel>,
        Navbars.INavbarButtonCreator<TModel>,
        Navbars.INavbarTextCreator<TModel>,
        Navbars.INavbarLinkCreator<TModel>,
        // Navs
        Navs.ITabsCreator<TModel>,
        Navs.ITabCreator<TModel>,
        Navs.IPillsCreator<TModel>,
        Navs.IPillCreator<TModel>,
        // Pagers
        Pagers.IPagerCreator<TModel>,
        Pagers.IPageCreator<TModel>,
        // Pagination
        Paginations.IPaginationCreator<TModel>,
        Paginations.IPageNumCreator<TModel>,
        // Panels
        Panels.IPanelCreator<TModel>,
        Panels.IPanelSectionCreator<TModel>,
        Panels.IPanelTitleCreator<TModel>,
        // Progress Bars
        ProgressBars.IProgressCreator<TModel>,
        ProgressBars.IProgressBarCreator<TModel>,
        // Tables
        Tables.ITableCreator<TModel>,
        Tables.ITableSectionCreator<TModel>,
        Tables.ITableRowCreator<TModel>,
        Tables.ITableCellCreator<TModel>,
        // Thumbnails
        Thumbnails.IThumbnailCreator<TModel>,
        Thumbnails.IThumbnailContainerCreator<TModel>,
        Thumbnails.ICaptionCreator<TModel>,
        // Typography
        Typography.ISmallCreator<TModel>,
        Typography.IListCreator<TModel>,
        Typography.IListItemCreator<TModel>,
        Typography.IDescriptionListCreator<TModel>,
        Typography.IDescriptionCreator<TModel>,
        Typography.IDescriptionTermCreator<TModel>
    {
        public BootstrapHelperAll(HtmlHelper<TModel> htmlHelper) : base(htmlHelper)
        {
        }
    }
}
