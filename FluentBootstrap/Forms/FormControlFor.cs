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

namespace FluentBootstrap.Forms
{
    internal interface IFormControlForBase : IFormControl
    {
    }

    public abstract class FormControlForBase<TModel, TValue, TThis> : FormControl<TModel, TThis>, IFormControlForBase
        where TThis : FormControlForBase<TModel, TValue, TThis>
    {
        private readonly bool _editor;
        protected Expression<Func<TModel, TValue>> Expression { get; private set; }

        internal bool AddDescription { get; set; }
        internal bool AddValidationMessage { get; set; }
        internal bool AddHidden { get; set; }   // No effect if Editor == true
        internal bool AddFormControlClass { get; set; }  // No effect if Editor == false
        internal string TemplateName { get; set; }
        internal object AdditionalViewData { get; set; }

        protected FormControlForBase(BootstrapHelper<TModel> helper, bool editor, Expression<Func<TModel, TValue>> expression)
            : base(helper, "div", editor ? null : Css.FormControlStatic)
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
                writer.Write(HtmlHelper.ValidationMessageFor(Expression));
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
                    new Element<TModel>(Helper, "p", Css.HelpBlock)
                        .AddChild(new Content<TModel>(Helper, metadata.Description))
                        .StartAndFinish(writer);
                }
            }

            base.OnFinish(writer);
        }

        protected virtual void WriteDisplay(TextWriter writer)
        {
            // Insert the hidden control if requested
            if (AddHidden)
            {
                new HiddenFor<TModel, TValue>(Helper, Expression).StartAndFinish(writer);
            }

            writer.Write(HtmlHelper.DisplayFor(Expression, TemplateName, AdditionalViewData));
        }

        protected virtual void WriteEditor(TextWriter writer)
        {
            writer.Write(GetEditor(HtmlHelper.EditorFor(Expression, TemplateName, AdditionalViewData).ToString()));
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

    internal interface IFormControlListFor : IFormControl
    {
    }

    public class FormControlListFor<TModel, TValue> : FormControlForBase<TModel, IEnumerable<TValue>, FormControlListFor<TModel, TValue>>, IFormControlListFor
    {
        private readonly Typography.ListType _listType;

        public FormControlListFor(BootstrapHelper<TModel> helper, bool editor, Expression<Func<TModel, IEnumerable<TValue>>> expression, Typography.ListType listType) 
            : base(helper, editor, expression)
        {
            _listType = listType;
        }

        protected override void WriteDisplay(TextWriter writer)
        {
            // Get the values
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(Expression, HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values == null)
            {
                base.WriteDisplay(writer);
                return;
            }

            // Iterate
            Typography.List<TModel> list = new Typography.List<TModel>(Helper, _listType);
            PendingComponents.Remove(HtmlHelper, list);
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(
                    (AddHidden ? new HiddenFor<TModel, TValue>(Helper, _ => value).ToHtmlString() : string.Empty)
                        + HtmlHelper.DisplayFor(_ => value, TemplateName, AdditionalViewData).ToString()));
            }
            list.StartAndFinish(writer);
        }

        protected override void WriteEditor(TextWriter writer)
        {
            // Get the values
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(Expression, HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values == null)
            {
                base.WriteEditor(writer);
                return;
            }

            // Iterate
            Typography.List<TModel> list = new Typography.List<TModel>(Helper, _listType);
            PendingComponents.Remove(HtmlHelper, list);
            int c = 0;
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(GetEditor(HtmlHelper.EditorFor(_ => value, TemplateName, AdditionalViewData).ToString())));
                c++;
            }
            list.StartAndFinish(writer);
        }
    }

    internal interface IFormControlFor : IFormControl
    {
    }

    public class FormControlFor<TModel, TValue> : FormControlForBase<TModel, TValue, FormControlFor<TModel, TValue>>, IFormControlFor
    {
        public FormControlFor(BootstrapHelper<TModel> helper, bool editor, Expression<Func<TModel, TValue>> expression)
            : base(helper, editor, expression)
        {
        }
    }
}
