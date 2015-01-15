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
    internal class FormControlOverride<TModel> : ComponentOverride<FormControl>
    {
        protected override void OnStart(TextWriter writer)
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
                Component.MergeAttribute("id", tagBuilder.Attributes["id"]);

                // Set the validation class
                ModelState modelState;
                MvcBootstrapConfig<TModel> config = (MvcBootstrapConfig<TModel>)Config;
                if (config.HtmlHelper.ViewData.ModelState.TryGetValue(name, out modelState) && modelState.Errors.Count > 0)
                {
                    Component.CssClasses.Add(System.Web.Mvc.HtmlHelper.ValidationInputCssClassName);
                }

                // Add other validation attributes
                Component.MergeAttributes<string, object>(config.HtmlHelper.GetUnobtrusiveValidationAttributes(name, null));
            }

            base.OnStart(writer);
        }
    }
}
