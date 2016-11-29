using FluentBootstrap.Forms;
using FluentBootstrap.Mvc;
using FluentBootstrap.Mvc.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{
    public static class MvcFormExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Form> Form<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string actionName, string controllerName, FormMethod method = FormMethod.Post, object routeValues = null)
            where TComponent : Component, ICanCreate<Form>
        {
            return helper.Form()
                .SetAction(actionName, controllerName, routeValues)
                .SetFormMethod(method);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Form> Form<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, FormMethod method)
            where TComponent : Component, ICanCreate<Form>
        {
            return helper.Form()
                .SetAction(null)
                .SetFormMethod(method);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Form> Form<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string action, FormMethod method)
            where TComponent : Component, ICanCreate<Form>
        {
            return helper.Form()
                .SetAction(action)
                .SetFormMethod(method);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> SetFormMethod<TModel, TForm>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> builder, FormMethod method)
            where TForm : Form
        {
            builder.GetComponent().MergeAttribute("method", HtmlHelper.GetFormMethodString(method));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> SetAction<TModel, TForm>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> builder, string actionName, string controllerName, object routeValues = null)
            where TForm : Form
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                routeValueDictionary = new RouteValueDictionary(routeValues);
            }
            builder.SetAction(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                builder.GetConfig().HtmlHelper.RouteCollection, builder.GetConfig().HtmlHelper.ViewContext.RequestContext, true));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> SetRoute<TModel, TForm>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> builder, string routeName, object routeValues = null)
            where TForm : Form
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                routeValueDictionary = new RouteValueDictionary(routeValues);
            }
            builder.SetAction(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                builder.GetConfig().HtmlHelper.RouteCollection, builder.GetConfig().HtmlHelper.ViewContext.RequestContext, false));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> HideValidationSummary<TModel, TForm>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> builder, bool hideValidationSummary = true)
            where TForm : Form
        {
            builder.GetComponent().GetOverride<FormOverride<TModel>>().HideValidationSummary = hideValidationSummary;
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, ValidationSummary<TModel>> ValidationSummary<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, bool includePropertyErrors = false) 
            where TComponent : Component, ICanCreate<FormControl>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, ValidationSummary<TModel>>(helper.GetConfig(), new ValidationSummary<TModel>(helper));
        }

        public static ValidationSummary<TModel> IncludePropertyErrors<TModel>(this ValidationSummary<TModel> validationSummary, bool includePropertyErrors = false)
        {
            validationSummary.IncludePropertyErrors = includePropertyErrors;
            return validationSummary;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormGroup> FormGroup<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> labelExpression)
            where TComponent : Component, ICanCreate<FormGroup>
        {
            ComponentBuilder<MvcBootstrapConfig<TModel>, FormGroup> builder = helper.FormGroup();
            builder.GetComponent().ControlLabel = builder.GetHelper().ControlLabel(labelExpression).GetComponent();
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormGroup> SetGroupLabel<TModel, TValue, TThis>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, FormGroup> builder, Expression<Func<TModel, TValue>> expression, Action<ControlLabel> labelAction = null)
        {
            ControlLabel controlLabel = GetControlLabel(builder.GetHelper(), expression).GetComponent();
            builder.GetComponent().ControlLabel = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, ControlLabel> ControlLabel<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression)
            where TComponent : Component, ICanCreate<ControlLabel>
        {
            return GetControlLabel(helper, expression);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlFor<TModel, TValue>> DisplayFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression,
            bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
            where TComponent : Component, ICanCreate<FormControl>
        {
            return helper.EditorOrDisplayFor(false, expression, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlFor<TModel, TValue>> EditorFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression,
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
            where TComponent : Component, ICanCreate<FormControl>
        {
            return helper.EditorOrDisplayFor(true, expression, addDescription, addValidationMessage, templateName, additionalViewData);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlFor<TModel, TValue>> EditorOrDisplayFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, bool editor, Expression<Func<TModel, TValue>> expression,
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
            where TComponent : Component, ICanCreate<FormControl>
        {
            ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlFor<TModel, TValue>> builder =
                new ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlFor<TModel, TValue>>(helper.GetConfig(), new FormControlFor<TModel, TValue>(helper, editor, expression))
                    .AddHidden(addHidden)
                    .AddDescription(addDescription)
                    .AddValidationMessage(addValidationMessage)
                    .SetTemplateName(templateName)
                    .AddAdditionalViewData(additionalViewData);
            builder.GetComponent().Label = GetControlLabel(helper, expression).GetComponent();
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlListFor<TModel, TValue>> DisplayListFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
            where TComponent : Component, ICanCreate<FormControl>
        {
            return helper.EditorOrDisplayListFor(false, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlListFor<TModel, TValue>> EditorListFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
            where TComponent : Component, ICanCreate<FormControl>
        {
            return helper.EditorOrDisplayListFor(true, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlListFor<TModel, TValue>> EditorOrDisplayListFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, bool editor, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
            where TComponent : Component, ICanCreate<FormControl>
        {
            ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlListFor<TModel, TValue>> builder =
                new ComponentBuilder<MvcBootstrapConfig<TModel>, FormControlListFor<TModel, TValue>>(helper.GetConfig(), new FormControlListFor<TModel, TValue>(helper, editor, expression, listType))
                    .AddHidden(addHidden)
                    .AddDescription(addDescription)
                    .AddValidationMessage(addValidationMessage)
                    .SetTemplateName(templateName)
                    .AddAdditionalViewData(additionalViewData);
            builder.GetComponent().Label = GetControlLabel(helper, expression).GetComponent();
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> AddHidden<TModel, TFormControlFor>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> builder, bool addHidden = true)
            where TFormControlFor : FormControlForBase
        {
            builder.GetComponent().AddHidden = addHidden;
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> AddStaticClass<TModel, TFormControlFor>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> builder, bool addStaticClass = true)
            where TFormControlFor : FormControlForBase
        {
            builder.GetComponent().ToggleCss(Css.FormControlStatic, addStaticClass);
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> AddFormControlClass<TModel, TFormControlFor>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> builder, bool addFormControlClass = true)
            where TFormControlFor : FormControlForBase
        {
            builder.GetComponent().AddFormControlClass = addFormControlClass;
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> AddDescription<TModel, TFormControlFor>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> builder, bool addDescription = true)
            where TFormControlFor : FormControlForBase
        {
            builder.GetComponent().AddDescription = addDescription;
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> AddValidationMessage<TModel, TFormControlFor>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> builder, bool addValidationMessage = true)
            where TFormControlFor : FormControlForBase
        {
            builder.GetComponent().AddValidationMessage = addValidationMessage;
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> SetTemplateName<TModel, TFormControlFor>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> builder, string templateName)
            where TFormControlFor : FormControlForBase
        {
            builder.GetComponent().TemplateName = templateName;
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> AddAdditionalViewData<TModel, TFormControlFor>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControlFor> builder, object additionalViewData)
            where TFormControlFor : FormControlForBase
        {
            builder.GetComponent().AdditionalViewData = additionalViewData;
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Input> InputFor<TModel, TValue>(
            this ComponentWrapper<MvcBootstrapConfig<TModel>, InputGroup> wrapper, Expression<Func<TModel, TValue>> expression, FormInputType inputType = FormInputType.Text)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, wrapper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(wrapper, expressionText);
            return wrapper.Input(name, metadata.Model, metadata.EditFormatString, inputType);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Input> InputFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression, FormInputType inputType = FormInputType.Text)
            where TComponent : Component, ICanCreate<Input>
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            return helper.Input(name, label, metadata.Model, metadata.EditFormatString, inputType);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Input> PasswordFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression)
            where TComponent : Component, ICanCreate<Input>
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            return helper.Input(name, label, null, null, FormInputType.Password);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, CheckBoxFor<TModel, TValue>> CheckBoxFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression, bool isNameInLabel = true)
            where TComponent : Component, ICanCreate<CheckedControl>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, CheckBoxFor<TModel, TValue>>(helper.GetConfig(), new CheckBoxFor<TModel, TValue>(helper, expression, isNameInLabel));
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, CheckedControl> RadioFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression, object value = null, bool isNameInLabel = true)
            where TComponent : Component, ICanCreate<CheckedControl>
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            string valueString = Convert.ToString(value, (IFormatProvider)CultureInfo.CurrentCulture);
            bool isChecked = metadata.Model != null && !string.IsNullOrEmpty(name) && string.Equals(metadata.Model.ToString(), valueString, StringComparison.OrdinalIgnoreCase);
            return isNameInLabel ? helper.Radio(name, label, null, value, isChecked) : helper.Radio(name, null, label, value, isChecked);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Select> SelectFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression, params string[] options)
            where TComponent : Component, ICanCreate<Select>
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            ComponentBuilder<MvcBootstrapConfig<TModel>, Select> builder = helper.Select(name, label);
            if (metadata.Model != null && !string.IsNullOrEmpty(name))
            {
                // Add the model value before adding options so they'll get selected on a match
                builder.GetComponent().ModelValue = metadata.Model.ToString();
            }
            return builder.AddOptions(options);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Select> SelectFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression, IEnumerable<KeyValuePair<string, string>> options)
            where TComponent : Component, ICanCreate<Select>
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            ComponentBuilder<MvcBootstrapConfig<TModel>, Select> builder = helper.Select(name, label);
            if (metadata.Model != null && !string.IsNullOrEmpty(name))
            {
                // Add the model value before adding options so they'll get selected on a match
                builder.GetComponent().ModelValue = metadata.Model.ToString();
            }
            return builder.AddOptions(options);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Select> SelectFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList = null)
            where TComponent : Component, ICanCreate<Select>
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            ComponentBuilder<MvcBootstrapConfig<TModel>, Select> builder = helper.Select(name, label);
            if (metadata.Model != null && !string.IsNullOrEmpty(name))
            {
                // Add the model value before adding options so they'll get selected on a match
                builder.GetComponent().ModelValue = metadata.Model.ToString();
            }
            return builder.AddOptions(selectList);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Select> Select<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string name, string label, IEnumerable<SelectListItem> selectList)
            where TComponent : Component, ICanCreate<Select>
        {
            return helper.Select(name, label)
                .AddOptions(selectList);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Select> AddOptions<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Select> builder, IEnumerable<SelectListItem> selectList)
        {
            if (selectList != null)
            {
                foreach (SelectListItem item in selectList)
                {
                    var item1 = item; // Avoid foreach variable access in closure
                    builder.AddChild(x => x.SelectOption(item1.Text, item1.Value, item1.Selected));
                }
            }
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TextArea> TextAreaFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression, int? rows = null)
            where TComponent : Component, ICanCreate<TextArea>
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            return helper.TextArea(name, label, metadata.Model, null, rows);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, HiddenFor<TModel, TValue>> HiddenFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression)
            where TComponent : Component, ICanCreate<Hidden>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, HiddenFor<TModel, TValue>>(helper.GetConfig(), new HiddenFor<TModel, TValue>(helper, expression));
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, FormControl> FormControl<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> labelExpression)
            where TComponent : Component, ICanCreate<FormControl>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, FormControl>(helper.GetConfig(), helper.FormControl().GetComponent())
                .SetControlLabel(labelExpression);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControl> SetControlLabel<TModel, TValue, TFormControl>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TFormControl> builder, Expression<Func<TModel, TValue>> expression, Action<ControlLabel> labelAction = null)
            where TFormControl : FormControl
        {
            ControlLabel controlLabel = GetControlLabel(builder.GetHelper(), expression).For(TagBuilder.CreateSanitizedId(builder.GetComponent().GetAttribute("name"))).GetComponent();
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            builder.GetComponent().Label = controlLabel;
            return builder;
        }

        private static ComponentBuilder<MvcBootstrapConfig<TModel>, ControlLabel> GetControlLabel<TComponent, TModel, TValue>(
            BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, Expression<Func<TModel, TValue>> expression)
            where TComponent : Component
        {
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.GetConfig().HtmlHelper.ViewData);
            string name = GetControlName(helper, expressionText);
            string label = GetControlLabel(metadata, expressionText);
            return new MvcBootstrapHelper<TModel>(helper.GetConfig().HtmlHelper).ControlLabel(label).For(TagBuilder.CreateSanitizedId(name));
        }

        internal static string GetControlName<TComponent, TModel>(BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string expressionText)
            where TComponent : Component
        {
            return helper.GetConfig().HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);
        }

        internal static string GetControlLabel(ModelMetadata metadata, string expressionText)
        {
            string label = metadata.DisplayName;
            if (label == null)
            {
                label = metadata.PropertyName;
                if (label == null)
                {
                    char[] chrArray = new char[] { '.' };
                    label = expressionText.Split(chrArray).Last<string>();
                }
            }
            return label;
        }

        public static ComponentBuilder<TConfig, TTag> AddLabelCss<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, params string[] cssClasses)
            where TConfig : BootstrapConfig
            where TTag : FormControl
        {
            var formControl = builder.GetComponent();
            formControl.AddLabelCss(cssClasses);

            return builder;
        }
    }
}
