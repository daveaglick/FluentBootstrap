using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Forms
{
    public interface IEditorFor : IFormControlFor
    {
    }

    public class EditorFor<TModel, TValue> : FormControlFor<TModel, TValue, EditorFor<TModel, TValue>>, IEditorFor
    {
        internal bool AddFormControlClass { get; set; }

        internal EditorFor(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            : base(helper, expression)
        {
            AddFormControlClass = true;
        }

        protected override void WriteTemplate(TextWriter writer)
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
    }
}
