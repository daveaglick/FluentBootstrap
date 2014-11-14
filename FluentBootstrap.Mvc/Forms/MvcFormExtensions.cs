using FluentBootstrap.Forms;
using FluentBootstrap.Mvc;
using FluentBootstrap.Mvc.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace FluentBootstrap
{
    public static class MvcFormExtensions
    {
        public static Form<MvcBootstrapHelper<TModel>> Form<TModel>(this IFormCreator<MvcBootstrapHelper<TModel>> creator, string actionName, string controllerName, FormMethod method = FormMethod.Post, object routeValues = null)
        {
            return new Form<MvcBootstrapHelper<TModel>>(creator).SetAction(actionName, controllerName, routeValues).SetMethod(method);
        }

        public static Form<MvcBootstrapHelper<TModel>> SetAction<TModel>(this Form<MvcBootstrapHelper<TModel>> form, string actionName, string controllerName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.SetAction(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                form.Helper.HtmlHelper.RouteCollection, form.Helper.HtmlHelper.ViewContext.RequestContext, true));
        }

        public static Form<MvcBootstrapHelper<TModel>> SetRoute<TModel>(this Form<MvcBootstrapHelper<TModel>> form, string routeName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.SetAction(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                form.Helper.HtmlHelper.RouteCollection, form.Helper.HtmlHelper.ViewContext.RequestContext, false));
        }

        public static Form<MvcBootstrapHelper<TModel>> HideValidationSummary<TModel>(this Form<MvcBootstrapHelper<TModel>> form, bool hideValidationSummary = true)
        {
            form.GetOverride<FormOverride<TModel>>().HideValidationSummary = hideValidationSummary;
            return form;
        }

        public static ValidationSummary<TModel, MvcBootstrapHelper<TModel>> ValidationSummary<TModel>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, bool includePropertyErrors = false)
        {
            return new ValidationSummary<TModel, MvcBootstrapHelper<TModel>>(creator);
        }

        public static ValidationSummary<TModel, MvcBootstrapHelper<TModel>> IncludePropertyErrors<TModel>(this ValidationSummary<TModel, MvcBootstrapHelper<TModel>> validationSummary, bool includePropertyErrors = false)
        {
            validationSummary.IncludePropertyErrors = includePropertyErrors;
            return validationSummary;
        }

        public static FormGroup<THelper> FormGroup<THelper, TValue>(this IFormGroupCreator<THelper> creator, Expression<Func<THelper, TValue>> labelExpression)
            where THelper : BootstrapHelper<THelper>
        {
            FormGroup<THelper> formGroup = new FormGroup<THelper>(creator);
            formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(labelExpression);
            return formGroup;
        }

        public static FormGroup<MvcBootstrapHelper<TModel>> SetGroupLabel<TModel, TValue, TThis>(this FormGroup<MvcBootstrapHelper<TModel>> formGroup, Expression<Func<TModel, TValue>> expression, Action<ControlLabel<MvcBootstrapHelper<TModel>>> labelAction = null)
        {
            ControlLabel<MvcBootstrapHelper<TModel>> controlLabel = GetControlLabel<TModel, TValue>(formGroup.Helper, expression);
            formGroup.ControlLabel = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return formGroup;
        }

        public static ControlLabel<MvcBootstrapHelper<TModel>> ControlLabel<TModel, TValue>(this IControlLabelCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> textExpression)
        {
            return GetControlLabel<TModel, TValue>(creator, textExpression);
        }

        private static ControlLabel<MvcBootstrapHelper<TModel>> GetControlLabel<TModel, TValue>(IComponentCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> expression)
        {
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, creator.GetHelper().HtmlHelper.ViewData);
            string text = metadata.DisplayName;
            if (text == null)
            {
                text = metadata.PropertyName;
                if (text == null)
                {
                    char[] chrArray = new char[] { '.' };
                    text = htmlFieldName.Split(chrArray).Last<string>();
                }
            }
            return new ControlLabel<MvcBootstrapHelper<TModel>>(creator, text).For(TagBuilder.CreateSanitizedId(
                creator.GetHelper().HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
        }

        public static FormControlFor<THelper, TValue> DisplayFor<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, TValue>> expression,
            bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayFor(false, expression, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        }

        public static FormControlFor<THelper, TValue> EditorFor<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, TValue>> expression,
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayFor(true, expression, addDescription, addValidationMessage, templateName, additionalViewData);
        }

        public static FormControlFor<THelper, TValue> EditorOrDisplayFor<THelper, TValue>(this IFormControlCreator<THelper> creator, bool editor, Expression<Func<THelper, TValue>> expression,
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
        {
            FormControlFor<THelper, TValue> formControl = new FormControlFor<THelper, TValue>(creator, editor, expression)
                .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
                .SetTemplateName(templateName).AddAdditionalViewData(additionalViewData);
            formControl.Label = GetControlLabel(creator, expression);
            return formControl;
        }

        public static FormControlListFor<THelper, TValue> DisplayListFor<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayListFor(false, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        }

        public static FormControlListFor<THelper, TValue> EditorListFor<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayListFor(true, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData);
        }

        public static FormControlListFor<THelper, TValue> EditorOrDisplayListFor<THelper, TValue>(this IFormControlCreator<THelper> creator, bool editor, Expression<Func<THelper, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
        {
            FormControlListFor<THelper, TValue> formControl = new FormControlListFor<THelper, TValue>(creator, editor, expression, listType)
                .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
                .SetTemplateName(templateName).AddAdditionalViewData(additionalViewData);
            formControl.Label = GetControlLabel(creator, expression);
            return formControl;
        }

        public static TThis AddHidden<THelper, TValue, TThis, TWrapper>(this FormControlForBase<THelper, TValue, TThis, TWrapper> component, bool addHidden = true)
            where TThis : FormControlForBase<THelper, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<THelper>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddHidden = addHidden;
            return formControl;
        }

        public static TThis AddStaticClass<THelper, TValue, TThis, TWrapper>(this FormControlForBase<THelper, TValue, TThis, TWrapper> component, bool addStaticClass = true)
            where TThis : FormControlForBase<THelper, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<THelper>, new()
        {
            TThis formControl = component.GetThis();
            formControl.ToggleCss(Css.FormControlStatic, addStaticClass);
            return formControl;
        }

        public static TThis AddFormControlClass<THelper, TValue, TThis, TWrapper>(this FormControlForBase<THelper, TValue, TThis, TWrapper> component, bool addFormControlClass = true)
            where TThis : FormControlForBase<THelper, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<THelper>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddFormControlClass = addFormControlClass;
            return formControl;
        }

        public static TThis AddDescription<THelper, TValue, TThis, TWrapper>(this FormControlForBase<THelper, TValue, TThis, TWrapper> component, bool addDescription = true)
            where TThis : FormControlForBase<THelper, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<THelper>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddDescription = addDescription;
            return formControl;
        }

        public static TThis AddValidationMessage<THelper, TValue, TThis, TWrapper>(this FormControlForBase<THelper, TValue, TThis, TWrapper> component, bool addValidationMessage = true)
            where TThis : FormControlForBase<THelper, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<THelper>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddValidationMessage = addValidationMessage;
            return formControl;
        }

        public static TThis SetTemplateName<THelper, TValue, TThis, TWrapper>(this FormControlForBase<THelper, TValue, TThis, TWrapper> component, string templateName)
            where TThis : FormControlForBase<THelper, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<THelper>, new()
        {
            TThis formControl = component.GetThis();
            formControl.TemplateName = templateName;
            return formControl;
        }

        public static TThis AddAdditionalViewData<THelper, TValue, TThis, TWrapper>(this FormControlForBase<THelper, TValue, TThis, TWrapper> component, object additionalViewData)
            where TThis : FormControlForBase<THelper, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<THelper>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AdditionalViewData = additionalViewData;
            return formControl;
        }

        public static HiddenFor<THelper, TValue> HiddenFor<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, TValue>> expression)
        {
            return new HiddenFor<THelper, TValue>(creator, expression);
        }

        public static FormControl<THelper> FormControl<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, TValue>> labelExpression)
        {
            return new FormControl<THelper>(creator).SetControlLabel(labelExpression);
        }

        public static TThis SetControlLabel<THelper, TValue, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, Expression<Func<THelper, TValue>> expression, Action<ControlLabel<THelper>> labelAction = null)
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            TThis control = component.GetThis();
            ControlLabel<THelper> controlLabel = GetControlLabel(component.Helper, expression).For(control.GetName());
            control.Label = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return control;
        }
    }
}
