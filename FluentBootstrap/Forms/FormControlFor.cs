using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Forms
{
    public interface IFormControlFor : IFormControl
    {
    }

    public class FormControlFor<TModel, TValue> : FormControl<TModel, FormControlFor<TModel, TValue>>, IFormControlFor
    {
        internal bool Editor { get; set; }
        protected Expression<Func<TModel, TValue>> Expression { get; private set; }
        internal bool AddDescription { get; set; }
        internal bool AddValidationMessage { get; set; }
        internal bool AddHidden { get; set; }   // No effect if Editor == true
        internal bool AddFormControlClass { get; set; }  // No effect if Editor == false
        internal string TemplateName { get; set; }
        internal object AdditionalViewData { get; set; }

        internal FormControlFor(BootstrapHelper<TModel> helper, bool editor, Expression<Func<TModel, TValue>> expression)
            : base(helper, "div", editor ? null : "form-control-static")
        {
            Editor = editor;
            Expression = expression;
            AddFormControlClass = true;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (Editor)
            {
                WriteEditor(writer);
            }
            else
            {
                WriteDisplay(writer);
            }

            // Add the validation message if requested
            if (AddValidationMessage)
            {
                writer.Write(HtmlHelper.ValidationMessageFor(Expression));
            }
        }

        private void WriteDisplay(TextWriter writer)
        {
            // Insert the hidden control if requested
            if (AddHidden)
            {
                new HiddenFor<TModel, TValue>(Helper, Expression).StartAndFinish(writer);
            }
            writer.Write(HtmlHelper.DisplayFor(Expression, TemplateName, AdditionalViewData));
        }

        private void WriteEditor(TextWriter writer)
        {
            string html = HtmlHelper.EditorFor(Expression, TemplateName, AdditionalViewData).ToString();
            if (AddFormControlClass)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                bool addedFormControl = false;
                foreach (HtmlNode node in doc.DocumentNode.ChildNodes)
                {
                    if ((node.Name == "input" && (!node.Attributes.Contains("type")
                        || (node.Attributes["type"].Value != "hidden"
                        && node.Attributes["type"].Value != "radio"
                        && node.Attributes["type"].Value != "checkbox")))
                        || node.Name == "textarea"
                        || node.Name == "select")
                    {
                        if (node.Attributes.Contains("class"))
                            node.Attributes["class"].Value += " form-control";
                        else
                            node.Attributes.Add("class", "form-control");
                        addedFormControl = true;
                    }
                    else if (node.Name == "script" && node.InnerHtml.Contains("kendo"))
                    {
                        // Don't set the form-control class for Kendo controls
                        addedFormControl = false;
                        break;
                    }
                }
                if (addedFormControl)
                {
                    html = doc.DocumentNode.OuterHtml;
                }
            }
            writer.Write(html);
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the description text if requested
            if (AddDescription)
            {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(Expression, Helper.HtmlHelper.ViewData);
                if (!string.IsNullOrWhiteSpace(metadata.Description))
                {
                    new Tag<TModel>(Helper, "p", "help-block")
                        .AddChild(new Content<TModel>(Helper, metadata.Description))
                        .StartAndFinish(writer);
                }
            }

            base.OnFinish(writer);
        }
    }
}
