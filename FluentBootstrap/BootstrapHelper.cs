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
    public class BootstrapHelper :
        // Grids
        Grids.Container.ICreate,
        Grids.GridColumn.ICreate,
        Grids.GridRow.ICreate,
        // Tables
        Tables.Table.ICreate,
        Tables.TableSection.ICreate,
        Tables.TableRow.ICreate,
        Tables.TableCell.ICreate,
        // Forms
        Forms.Form.ICreate,
        Forms.FieldSet.ICreate,
        Forms.FormGroup.ICreate,
        Forms.Label.ICreate,
        Forms.FormControl.ICreate,
        // Buttons
        Buttons.Button.ICreate,
        Buttons.LinkButton.ICreate,
        // Links
        Links.Link.ICreate
    {
        public static int GridColumns = 12;

        internal HtmlHelper HtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        public BootstrapHelper GetHelper()
        {
            return this;
        }
    }

    public class BootstrapHelper<TModel> : BootstrapHelper
    {
        internal HtmlHelper<TModel> StrongHtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            StrongHtmlHelper = htmlHelper;
        }
    }
}
