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
    public class BootstrapHelper : IComponentCreator<BootstrapHelper>,
        // Grids
        Grids.Container.ICreate,
        Grids.GridColumn.ICreate,
        Grids.GridRow.ICreate,
        // Tables
        Tables.Table.ICreate,
        Tables.TableHead.ICreate,
        Tables.TableBody.ICreate,
        Tables.TableFoot.ICreate,
        Tables.TableRow.ICreate,
        Tables.TableHeading.ICreate,
        Tables.TableData.ICreate,
        // Forms
        Forms.Form.ICreate,
        Forms.FormGroup.ICreate,
        Forms.Label.ICreate,
        Forms.Input.ICreate,
        Forms.CheckedControl.ICreate,
        Forms.Select.ICreate,
        Forms.TextArea.ICreate
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
