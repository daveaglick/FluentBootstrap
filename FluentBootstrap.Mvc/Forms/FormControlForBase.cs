using System.Collections;
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
using FluentBootstrap.Html;
using FluentBootstrap.Forms;

namespace FluentBootstrap.Mvc.Forms
{
    public interface IFormControlForBaseCreator<TModel> : IComponentCreator<MvcBootstrapHelper<TModel>>
    {
    }

    public class FormControlForBaseWrapper<TModel> : FormControlWrapper<MvcBootstrapHelper<TModel>>
    {
    }

    internal interface IFormControlForBase : IFormControl
    {
    }

    public abstract class FormControlForBase<TModel, TValue, TThis, TWrapper> : FormControl<MvcBootstrapHelper<TModel>, TThis, TWrapper>, IFormControlForBase
        where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        where TWrapper : FormControlForBaseWrapper<TModel>, new()
    {
        private readonly bool _editor;
        protected Expression<Func<TModel, TValue>> Expression { get; private set; }

        internal bool AddDescription { get; set; }
        internal bool AddValidationMessage { get; set; }
        internal bool AddHidden { get; set; }   // No effect if Editor == true
        internal bool AddFormControlClass { get; set; }  // No effect if Editor == false
        internal string TemplateName { get; set; }
        internal object AdditionalViewData { get; set; }

        protected FormControlForBase(IComponentCreator<MvcBootstrapHelper<TModel>> creator, bool editor, Expression<Func<TModel, TValue>> expression)
            : base(creator, "div", editor ? null : Css.FormControlStatic)
        {
            _editor = editor;
            Expression = expression;
            AddFormControlClass = true;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (_editor)
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
                writer.Write(Helper.HtmlHelper.ValidationMessageFor(Expression));
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the description text if requested
            if (AddDescription)
            {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(Expression, Helper.HtmlHelper.ViewData);
                if (!string.IsNullOrWhiteSpace(metadata.Description))
                {
                    Element<MvcBootstrapHelper<TModel>> element = Helper.Element("p").AddCss(Css.HelpBlock);
                    element.AddChild(new Content<MvcBootstrapHelper<TModel>>(Helper, metadata.Description));
                    element.StartAndFinish(writer);
                }
            }

            base.OnFinish(writer);
        }

        protected virtual void WriteDisplay(TextWriter writer)
        {
            // Insert the hidden control if requested
            if (AddHidden)
            {
                Helper.HiddenFor(Expression).StartAndFinish(writer);
            }

            writer.Write(Helper.HtmlHelper.DisplayFor(Expression, TemplateName, AdditionalViewData));
        }

        protected virtual void WriteEditor(TextWriter writer)
        {
            writer.Write(GetEditor(Helper.HtmlHelper.EditorFor(Expression, TemplateName, AdditionalViewData).ToString()));
        }

        protected string GetEditor(string html)
        {
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
            return html;
        }
    }
}
