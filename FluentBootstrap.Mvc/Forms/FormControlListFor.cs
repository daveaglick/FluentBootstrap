using System.Collections;
using FluentBootstrap;
using FluentBootstrap.Internals;
using FluentBootstrap.Mvc.Internals;
using FluentBootstrap.Typography;
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

namespace FluentBootstrap.Mvc.Forms
{
    public class FormControlListFor<TModel, TValue> : FormControlForBase<TModel, IEnumerable<TValue>>
    {
        private readonly ListType _listType;

        public FormControlListFor(BootstrapHelper helper, bool editor, Expression<Func<TModel, IEnumerable<TValue>>> expression, ListType listType)
            : base(helper, editor, expression)
        {
            _listType = listType;
        }

        protected override void WriteDisplay(TextWriter writer)
        {
            // Get the values
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(Expression, this.GetHtmlHelper<TModel>().ViewData).Model as IEnumerable<TValue>;
            if (values == null)
            {
                base.WriteDisplay(writer);
                return;
            }

            // Iterate
            ComponentBuilder<MvcBootstrapConfig<TModel>, List> list = this.GetHelper<TModel>().List(_listType);
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(
                    (AddHidden ? this.GetHelper<TModel>().HiddenFor(_ => value).ToHtmlString() : string.Empty)
                        + this.GetHtmlHelper<TModel>().DisplayFor(_ => value, TemplateName, AdditionalViewData).ToString()));
            }
            list.GetComponent().StartAndFinish(writer);
        }

        protected override void WriteEditor(TextWriter writer)
        {
            // Get the values
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(Expression, this.GetHtmlHelper<TModel>().ViewData).Model as IEnumerable<TValue>;
            if (values == null)
            {
                base.WriteEditor(writer);
                return;
            }

            // Iterate
            ComponentBuilder<MvcBootstrapConfig<TModel>, List> list = this.GetHelper<TModel>().List(_listType);
            int c = 0;
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(GetEditor(this.GetHtmlHelper<TModel>().EditorFor(_ => value, TemplateName, AdditionalViewData).ToString())));
                c++;
            }
            list.GetComponent().StartAndFinish(writer);
        }
    }
}
