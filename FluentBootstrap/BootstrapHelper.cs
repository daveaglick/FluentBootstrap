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
        // Grids
        Grids.Container<TModel>.ICreate,
        Grids.GridColumn<TModel>.ICreate,
        Grids.GridRow<TModel>.ICreate,
        // Tables
        Tables.Table<TModel>.ICreate,
        Tables.TableSection<TModel>.ICreate,
        Tables.TableRow<TModel>.ICreate,
        Tables.TableCell<TModel>.ICreate,
        // Forms
        Forms.Form<TModel>.ICreate,
        Forms.FieldSet<TModel>.ICreate,
        Forms.FormGroup<TModel>.ICreate,
        Forms.Label<TModel>.ICreate,
        Forms.FormControl<TModel>.ICreate,
        // Buttons
        Buttons.Button<TModel>.ICreate,
        Buttons.LinkButton<TModel>.ICreate,
        // Links
        Links.Link<TModel>.ICreate
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
