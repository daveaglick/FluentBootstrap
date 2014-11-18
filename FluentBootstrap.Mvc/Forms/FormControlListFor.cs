using System.Collections;
using FluentBootstrap;
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
    public interface IFormControlListForCreator<TModel> : IComponentCreator<MvcBootstrapHelper<TModel>>
    {
    }

    public class FormControlListForWrapper<TModel> : FormControlForBaseWrapper<TModel>
    {
    }

    internal interface IFormControlListFor : IFormControlForBase
    {
    }

    public class FormControlListFor<TModel, TValue> : FormControlForBase<TModel, IEnumerable<TValue>, FormControlListFor<TModel, TValue>, FormControlListForWrapper<TModel>>, IFormControlListFor
    {
        private readonly ListType _listType;

        public FormControlListFor(IComponentCreator<MvcBootstrapHelper<TModel>> creator, bool editor, Expression<Func<TModel, IEnumerable<TValue>>> expression, ListType listType)
            : base(creator, editor, expression)
        {
            _listType = listType;
        }

        protected override void WriteDisplay(TextWriter writer)
        {
            // Get the values
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(Expression, Helper.HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values == null)
            {
                base.WriteDisplay(writer);
                return;
            }

            // Iterate
            Typography.List<MvcBootstrapHelper<TModel>> list = new Typography.List<MvcBootstrapHelper<TModel>>(Helper, _listType);
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(
                    (AddHidden ? Helper.HiddenFor(_ => value).ToHtmlString() : string.Empty)
                        + Helper.HtmlHelper.DisplayFor(_ => value, TemplateName, AdditionalViewData).ToString()));
            }
            list.StartAndFinish(writer);
        }

        protected override void WriteEditor(TextWriter writer)
        {
            // Get the values
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(Expression, Helper.HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values == null)
            {
                base.WriteEditor(writer);
                return;
            }

            // Iterate
            Typography.List<MvcBootstrapHelper<TModel>> list = new Typography.List<MvcBootstrapHelper<TModel>>(Helper, _listType);
            int c = 0;
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(GetEditor(Helper.HtmlHelper.EditorFor(_ => value, TemplateName, AdditionalViewData).ToString())));
                c++;
            }
            list.StartAndFinish(writer);
        }
    }
}
