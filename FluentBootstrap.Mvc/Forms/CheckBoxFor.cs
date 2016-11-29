using System;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FluentBootstrap.Mvc.Internals;

namespace FluentBootstrap.Mvc.Forms
{
    public class CheckBoxFor<TModel, TValue> : Component
    {
        private readonly Expression<Func<TModel, TValue>> _expression;
        private readonly bool _isNameInLabel;
        private string _name;

        internal CheckBoxFor(BootstrapHelper helper, Expression<Func<TModel, TValue>> expression, bool isNameInLabel = true)
            : base(helper)
        {
            _expression = expression;
            _isNameInLabel = isNameInLabel;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(_expression, this.GetHtmlHelper<TModel>().ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(_expression);
            _name = MvcFormExtensions.GetControlName(this.GetHelper<TModel>(), expressionText);
            string label = MvcFormExtensions.GetControlLabel(metadata, expressionText);
            bool isChecked = false;
            if (metadata.Model == null || !bool.TryParse(metadata.Model.ToString(), out isChecked))
            {
                isChecked = false;
            }
            writer.Write(_isNameInLabel 
                ? GetHelper().CheckBox(_name, label, null, isChecked).AddAttribute("value", isChecked)
                : GetHelper().CheckBox(_name, null, label, isChecked).AddAttribute("value", isChecked));
        }

        protected override void OnFinish(TextWriter writer)
        {
            writer.Write(GetHelper().Hidden(_name, false));
            base.OnFinish(writer);
        }
    }
}