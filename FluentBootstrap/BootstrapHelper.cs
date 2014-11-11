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
    public class BootstrapHelper<THelper> :
        ITagCreator<THelper>,
        // Alerts
        Alerts.IAlertCreator<THelper>,
        // Badges
        Badges.IBadgeCreator<THelper>,
        // Breadcrumbs
        Breadcrumbs.IBreadcrumbCreator<THelper>,
        // Buttons
        Buttons.IButtonToolbarCreator<THelper>,
        Buttons.IButtonGroupCreator<THelper>,
        Buttons.IDropdownButtonCreator<THelper>,
        Buttons.IButtonCreator<THelper>,
        Buttons.ILinkButtonCreator<THelper>,
        // Dropdowns
        Dropdowns.IDropdownCreator<THelper>,
        // Forms
        Forms.IFormCreator<THelper>,
        // Grids
        Grids.IContainerCreator<THelper>,
        Grids.IGridRowCreator<THelper>,
        // Html
        Html.IParagraphCreator<THelper>,
        // Images
        Images.IImageCreator<THelper>,
        // Labels
        Labels.ILabelCreator<THelper>,
        // List Groups
        ListGroups.IListGroupCreator<THelper>,
        // Links
        Links.ILinkCreator<THelper>,
        // Media Objects
        MediaObjects.IMediaCreator<THelper>,
        MediaObjects.IMediaListCreator<THelper>,
        // Misc
        Misc.IJumbotronCreator<THelper>,
        Misc.IPageHeaderCreator<THelper>,
        // Navbars,
        Navbars.INavbarCreator<THelper>,
        // Navs
        Navs.ITabsCreator<THelper>,
        Navs.IPillsCreator<THelper>,
        // Pagers
        Pagers.IPagerCreator<THelper>,
        // Pagination
        Paginations.IPaginationCreator<THelper>,
        // Panels
        Panels.IPanelCreator<THelper>,
        // Progress Bars
        ProgressBars.IProgressCreator<THelper>,
        ProgressBars.IProgressBarCreator<THelper>,
        // Tables
        Tables.ITableCreator<THelper>,
        // Thumbnails
        Thumbnails.IThumbnailCreator<THelper>,
        Thumbnails.IThumbnailContainerCreator<THelper>,
        // Typography
        Typography.IHeadingCreator<THelper>,
        Typography.ISmallCreator<THelper>,
        Typography.IListCreator<THelper>,
        Typography.IDescriptionListCreator<THelper>,
        // Wells
        Wells.IWellCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
        public IOutputContext OutputContext { get; private set; }

        public BootstrapHelper(IOutputContext outputContext)
        {
            // Sanity check
            if (typeof(THelper) != this.GetType())
            {
                throw new Exception("Invalid THelper generic type parameter for " + this.GetType().Name + " (you should never see this).");
            }

            OutputContext = outputContext;
        }

        public THelper GetHelper()
        {
            return (THelper)this;
        }

        public Component GetParent()
        {
            return null;
        }

        public BootstrapHelperAll<THelper> All()
        {
            return new BootstrapHelperAll<THelper>(OutputContext);
        }
    }

    // This provides expanded access to all extensions
    public class BootstrapHelperAll<THelper> : BootstrapHelper<THelper>,
        ITagCreator<THelper>,
        // Alerts
        Alerts.IAlertCreator<THelper>,
        // Badges
        Badges.IBadgeCreator<THelper>,
        // Breadcrumbs
        Breadcrumbs.IBreadcrumbCreator<THelper>,
        Breadcrumbs.ICrumbCreator<THelper>,
        // Buttons
        Buttons.IButtonToolbarCreator<THelper>,
        Buttons.IButtonGroupCreator<THelper>,
        Buttons.IDropdownButtonCreator<THelper>,
        Buttons.IButtonCreator<THelper>,
        Buttons.ILinkButtonCreator<THelper>,
        // Dropdowns
        Dropdowns.IDropdownCreator<THelper>,
        Dropdowns.IDropdownDividerCreator<THelper>,
        Dropdowns.IDropdownHeaderCreator<THelper>,
        Dropdowns.IDropdownLinkCreator<THelper>,
        // Forms
        Forms.IFormCreator<THelper>,
        Forms.IFieldSetCreator<THelper>,
        Forms.IFormGroupCreator<THelper>,
        Forms.IControlLabelCreator<THelper>,
        Forms.IFormControlCreator<THelper>,
        Forms.IHelpBlockCreator<THelper>,
        Forms.IInputGroupCreator<THelper>,
        Forms.IInputGroupAddonCreator<THelper>,
        Forms.IInputGroupButtonCreator<THelper>,
        // Grids
        Grids.IContainerCreator<THelper>,
        Grids.IGridColumnCreator<THelper>,
        Grids.IGridRowCreator<THelper>,
        // Html
        Html.IParagraphCreator<THelper>,
        // Images
        Images.IImageCreator<THelper>,
        // Labels
        Labels.ILabelCreator<THelper>,
        // List Groups
        ListGroups.IListGroupCreator<THelper>,
        ListGroups.IListGroupItemCreator<THelper>,
        // Links
        Links.ILinkCreator<THelper>,
        // Media Objects
        MediaObjects.IMediaCreator<THelper>,
        MediaObjects.IMediaListCreator<THelper>,
        MediaObjects.IMediaObjectCreator<THelper>,
        MediaObjects.IMediaBodyCreator<THelper>,
        // Misc
        Misc.IJumbotronCreator<THelper>,
        Misc.IPageHeaderCreator<THelper>,
        // Navbars,
        Navbars.INavbarCreator<THelper>,
        Navbars.INavbarHeaderCreator<THelper>,
        Navbars.INavbarToggleCreator<THelper>,
        Navbars.IBrandCreator<THelper>,
        Navbars.INavbarCollapseCreator<THelper>,
        Navbars.INavbarNavCreator<THelper>,
        Navbars.INavbarFormCreator<THelper>,
        Navbars.INavbarButtonCreator<THelper>,
        Navbars.INavbarTextCreator<THelper>,
        Navbars.INavbarLinkCreator<THelper>,
        // Navs
        Navs.ITabsCreator<THelper>,
        Navs.ITabCreator<THelper>,
        Navs.IPillsCreator<THelper>,
        Navs.IPillCreator<THelper>,
        // Pagers
        Pagers.IPagerCreator<THelper>,
        Pagers.IPageCreator<THelper>,
        // Pagination
        Paginations.IPaginationCreator<THelper>,
        Paginations.IPageNumCreator<THelper>,
        // Panels
        Panels.IPanelCreator<THelper>,
        Panels.IPanelSectionCreator<THelper>,
        Panels.IPanelTitleCreator<THelper>,
        // Progress Bars
        ProgressBars.IProgressCreator<THelper>,
        ProgressBars.IProgressBarCreator<THelper>,
        // Tables
        Tables.ITableCreator<THelper>,
        Tables.ITableSectionCreator<THelper>,
        Tables.ITableRowCreator<THelper>,
        Tables.ITableCellCreator<THelper>,
        // Thumbnails
        Thumbnails.IThumbnailCreator<THelper>,
        Thumbnails.IThumbnailContainerCreator<THelper>,
        Thumbnails.ICaptionCreator<THelper>,
        // Typography
        Typography.IHeadingCreator<THelper>,
        Typography.ISmallCreator<THelper>,
        Typography.IListCreator<THelper>,
        Typography.IListItemCreator<THelper>,
        Typography.IDescriptionListCreator<THelper>,
        Typography.IDescriptionCreator<THelper>,
        Typography.IDescriptionTermCreator<THelper>,
        // Wells
        Wells.IWellCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
        public BootstrapHelperAll(IOutputContext outputContext) : base(outputContext)
        {
        }
    }
}
