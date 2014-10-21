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
        // Links
        Links.ILinkCreator<TModel>,
        // Navs
        Navs.ITabsCreator<TModel>,
        Navs.IPillsCreator<TModel>,
        // Panels
        Panels.IPanelCreator<TModel>,
        // Tables
        Tables.ITableCreator<TModel>,
        // Typography
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
        Forms.ILabelCreator<TModel>,
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
        // Links
        Links.ILinkCreator<TModel>,
        // Navs
        Navs.ITabsCreator<TModel>,
        Navs.IPillsCreator<TModel>,
        Navs.INavLinkCreator<TModel>,
        // Panels
        Panels.IPanelCreator<TModel>,
        Panels.IPanelSectionCreator<TModel>,
        Panels.IPanelTitleCreator<TModel>,
        // Tables
        Tables.ITableCreator<TModel>,
        Tables.ITableSectionCreator<TModel>,
        Tables.ITableRowCreator<TModel>,
        Tables.ITableCellCreator<TModel>,
        // Typography
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
