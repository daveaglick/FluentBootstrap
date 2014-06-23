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
    public class BootstrapHelper<TModel> : 
        // Buttons
        Buttons.IButtonCreator<TModel>,
        Buttons.ILinkButtonCreator<TModel>,
        // Forms
        Forms.IFormCreator<TModel>,
        Forms.IFieldSetCreator<TModel>,
        Forms.IFormGroupCreator<TModel>,
        Forms.ILabelCreator<TModel>,
        Forms.IFormControlCreator<TModel>,
        // Grids
        Grids.IContainerCreator<TModel>,
        Grids.IGridColumnCreator<TModel>,
        Grids.IGridRowCreator<TModel>,
        // Links
        Links.ILinkCreator<TModel>,
        // Panels
        Panels.IPanelCreator<TModel>,
        // Tables
        Tables.ITableCreator<TModel>,
        Tables.ITableSectionCreator<TModel>,
        Tables.ITableRowCreator<TModel>,
        Tables.ITableCellCreator<TModel>
    {
        internal HtmlHelper<TModel> HtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper<TModel> htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        public BootstrapHelper<TModel> GetHelper()
        {
            return this;
        }
    }
}
