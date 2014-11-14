using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Mvc.Forms
{
    public class FormControlOverride<TModel> : ComponentOverride<FormControl<MvcBootstrapHelper<TModel>, FormControl<MvcBootstrapHelper<TModel>>, FormControlWrapper<MvcBootstrapHelper<TModel>>>, MvcBootstrapHelper<TModel>>
    {
        protected internal override void OnStart(TextWriter writer)
        {
            Component.Prepare(writer);

            // Add the validation data
            string name = Component.GetAttribute("name");
            if (!string.IsNullOrWhiteSpace(name))
            {
                // Use a TagBuilder to generate the Id
                TagBuilder tagBuilder = new TagBuilder("form");
                string id = Component.GetAttribute("id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    tagBuilder.MergeAttribute("id", id);
                }
                tagBuilder.GenerateId(name);
                Component.AddAttribute("id", tagBuilder.Attributes["id"]);

                // Set the validation class
                ModelState modelState;
                if (Component.Helper.HtmlHelper.ViewData.ModelState.TryGetValue(name, out modelState) && modelState.Errors.Count > 0)
                {
                    Component.CssClasses.Add(System.Web.Mvc.HtmlHelper.ValidationInputCssClassName);
                }

                // Add other validation attributes
                Component.MergeAttributes<string, object>(Component.Helper.HtmlHelper.GetUnobtrusiveValidationAttributes(name, null));
            }

            base.OnStart(writer);
        }
    }
}
