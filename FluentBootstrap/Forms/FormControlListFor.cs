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
    public interface IFormControlListForCreator<THelper> : IComponentCreator<THelper> 
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class FormControlListForWrapper<THelper> : FormControlForBaseWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IFormControlListFor : IFormControlForBase
    {
    }

    public class FormControlListFor<THelper, TValue> : FormControlForBase<THelper, IEnumerable<TValue>, FormControlListFor<THelper, TValue>, FormControlListForWrapper<THelper>>, IFormControlListFor
        where THelper : BootstrapHelper<THelper>
    {
        private readonly ListType _listType;

        public FormControlListFor(IComponentCreator<THelper> creator, bool editor, Expression<Func<THelper, IEnumerable<TValue>>> expression, ListType listType)
            : base(creator, editor, expression)
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
            Typography.List<THelper> list = new Typography.List<THelper>(Helper, _listType);
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(
                    (AddHidden ? new HiddenFor<THelper, TValue>(Helper, _ => value).ToHtmlString() : string.Empty)
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
            Typography.List<THelper> list = new Typography.List<THelper>(Helper, _listType);
            int c = 0;
            foreach (TValue value in values)
            {
                list.AddChild(x => x.ListItem(GetEditor(HtmlHelper.EditorFor(_ => value, TemplateName, AdditionalViewData).ToString())));
                c++;
            }
            list.StartAndFinish(writer);
        }
    }
}
