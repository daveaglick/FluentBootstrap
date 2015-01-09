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
using FluentBootstrap.Internals;
using FluentBootstrap.Mvc.Internals;

namespace FluentBootstrap
{
    public static class MvcFormExtensions
    {
        // !!
        //public static MvcComponentBuilder<Form, TModel> Form<TComponent, TModel>(this IMvcComponentCreator<TComponent, TModel> creator, string actionName, string controllerName, FormMethod method = FormMethod.Post, object routeValues = null)
        //    where TComponent : Component, ICanCreate<Form>
        //{
        //    return new MvcComponentBuilder<Form, TModel>(creator.Helper, creator.Helper.Form().GetComponent())
        //        .SetAction(actionName, controllerName, routeValues)
        //        .SetFormMethod(method);
        //}

        //public static Form<MvcBootstrapHelper<TModel>> Form<TModel>(this IFormCreator<MvcBootstrapHelper<TModel>> creator, FormMethod method)
        //{
        //    return new Form<MvcBootstrapHelper<TModel>>(creator).SetAction(null).SetFormMethod(method);
        //}

        //public static Form<MvcBootstrapHelper<TModel>> Form<TModel>(this IFormCreator<MvcBootstrapHelper<TModel>> creator, string action, FormMethod method)
        //{
        //    return new Form<MvcBootstrapHelper<TModel>>(creator).SetAction(action).SetFormMethod(method);
        //}

        // !!
        //public static MvcComponentBuilder<Form, TModel> SetFormMethod<TModel>(this MvcComponentBuilder<Form, TModel> builder, FormMethod method)
        //{
        //    // TODO: This isn't working because the FluentBootstrap.Internals extension is for ComponentBuilder<Form> and we have a MvcComponentBuilder<Form, TModel>
        //    builder.GetComponent().MergeAttribute("method", HtmlHelper.GetFormMethodString(method));
        //    return builder;
        //}

        // !!
        //public static MvcComponentBuilder<Form, TModel> SetAction<TModel>(this MvcComponentBuilder<Form, TModel> builder, string actionName, string controllerName, object routeValues = null)
        //{
        //    RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
        //    if (routeValueDictionary == null)
        //        new RouteValueDictionary(routeValues);

        //    // TODO: This is a problem because the .SetAction() extension expects a ComponentBuilder<Form> and we have a MvcComponentBuilder<Form, TModel>
        //    // Might need to use some kind of interface for builders/wrappers - ugh.
        //    builder.SetAction(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
        //        builder.Helper.GetHtmlHelper<TModel>().RouteCollection, builder.Helper.GetHtmlHelper<TModel>().ViewContext.RequestContext, true));
        //    return builder;
        //}

        //public static Form<MvcBootstrapHelper<TModel>> SetRoute<TModel>(this Form<MvcBootstrapHelper<TModel>> form, string routeName, object routeValues = null)
        //{
        //    RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
        //    if (routeValueDictionary == null)
        //        new RouteValueDictionary(routeValues);

        //    return form.SetAction(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
        //        form.Helper.HtmlHelper.RouteCollection, form.Helper.HtmlHelper.ViewContext.RequestContext, false));
        //}

        //public static Form<MvcBootstrapHelper<TModel>> HideValidationSummary<TModel>(this Form<MvcBootstrapHelper<TModel>> form, bool hideValidationSummary = true)
        //{
        //    form.GetOverride<FormOverride<TModel>>().HideValidationSummary = hideValidationSummary;
        //    return form;
        //}

        //public static ValidationSummary<TModel> ValidationSummary<TModel>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, bool includePropertyErrors = false)
        //{
        //    return new ValidationSummary<TModel>(creator);
        //}

        public static ComponentBuilder<TConfig, ValidationSummary<TModel>> ValidationSummary<TConfig, TComponent, TModel>(this BootstrapHelper<TConfig, TComponent> helper, bool includePropertyErrors = false)
            where TConfig : MvcBootstrapConfig<TModel>
            where TComponent : Component, ICanCreate<ValidationSummary<TModel>>
        {
            return new ComponentBuilder<TConfig, ValidationSummary<TModel>>(helper.GetConfig(), new ValidationSummary<TModel>(helper));
        }

        //public static ValidationSummary<TModel> IncludePropertyErrors<TModel>(this ValidationSummary<TModel> validationSummary, bool includePropertyErrors = false)
        //{
        //    validationSummary.IncludePropertyErrors = includePropertyErrors;
        //    return validationSummary;
        //}

        //public static FormGroup<MvcBootstrapHelper<TModel>> FormGroup<TModel, TValue>(this IFormGroupCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> labelExpression)
        //{
        //    FormGroup<MvcBootstrapHelper<TModel>> formGroup = new FormGroup<MvcBootstrapHelper<TModel>>(creator);
        //    formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(labelExpression);
        //    return formGroup;
        //}

        //public static FormGroup<MvcBootstrapHelper<TModel>> SetGroupLabel<TModel, TValue, TThis>(this FormGroup<MvcBootstrapHelper<TModel>> formGroup, Expression<Func<TModel, TValue>> expression, Action<ControlLabel<MvcBootstrapHelper<TModel>>> labelAction = null)
        //{
        //    ControlLabel<MvcBootstrapHelper<TModel>> controlLabel = GetControlLabel<TModel, TValue>(formGroup.Helper, expression);
        //    formGroup.ControlLabel = controlLabel;
        //    if (labelAction != null)
        //    {
        //        labelAction(controlLabel);
        //    }
        //    return formGroup;
        //}

        //public static ControlLabel<MvcBootstrapHelper<TModel>> ControlLabel<TModel, TValue>(this IControlLabelCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> textExpression)
        //{
        //    return GetControlLabel<TModel, TValue>(creator, textExpression);
        //}

        //private static ControlLabel<MvcBootstrapHelper<TModel>> GetControlLabel<TModel, TValue>(IComponentCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> expression)
        //{
        //    string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
        //    ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, creator.GetHelper().HtmlHelper.ViewData);
        //    string text = metadata.DisplayName;
        //    if (text == null)
        //    {
        //        text = metadata.PropertyName;
        //        if (text == null)
        //        {
        //            char[] chrArray = new char[] { '.' };
        //            text = htmlFieldName.Split(chrArray).Last<string>();
        //        }
        //    }
        //    return new ControlLabel<MvcBootstrapHelper<TModel>>(creator, text).For(TagBuilder.CreateSanitizedId(
        //        creator.GetHelper().HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
        //}

        //public static FormControlFor<TModel, TValue> DisplayFor<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> expression,
        //    bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        //{
        //    return creator.EditorOrDisplayFor(false, expression, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        //}

        //public static FormControlFor<TModel, TValue> EditorFor<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> expression,
        //    bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        //{
        //    return creator.EditorOrDisplayFor(true, expression, addDescription, addValidationMessage, templateName, additionalViewData);
        //}

        //public static FormControlFor<TModel, TValue> EditorOrDisplayFor<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, bool editor, Expression<Func<TModel, TValue>> expression,
        //    bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
        //{
        //    FormControlFor<TModel, TValue> formControl = new FormControlFor<TModel, TValue>(creator, editor, expression)
        //        .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
        //        .SetTemplateName(templateName).AddAdditionalViewData(additionalViewData);
        //    formControl.Label = GetControlLabel(creator, expression);
        //    return formControl;
        //}

        //public static FormControlListFor<TModel, TValue> DisplayListFor<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression,
        //    ListType listType = ListType.Unstyled, bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        //{
        //    return creator.EditorOrDisplayListFor(false, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        //}

        //public static FormControlListFor<TModel, TValue> EditorListFor<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression,
        //    ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        //{
        //    return creator.EditorOrDisplayListFor(true, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData);
        //}

        //public static FormControlListFor<TModel, TValue> EditorOrDisplayListFor<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, bool editor, Expression<Func<TModel, IEnumerable<TValue>>> expression,
        //    ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
        //{
        //    FormControlListFor<TModel, TValue> formControl = new FormControlListFor<TModel, TValue>(creator, editor, expression, listType)
        //        .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
        //        .SetTemplateName(templateName).AddAdditionalViewData(additionalViewData);
        //    formControl.Label = GetControlLabel(creator, expression);
        //    return formControl;
        //}

        //public static TThis AddHidden<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addHidden = true)
        //    where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        //    where TWrapper : FormControlForBaseWrapper<TModel>, new()
        //{
        //    TThis formControl = component.GetThis();
        //    formControl.AddHidden = addHidden;
        //    return formControl;
        //}

        //public static TThis AddStaticClass<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addStaticClass = true)
        //    where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        //    where TWrapper : FormControlForBaseWrapper<TModel>, new()
        //{
        //    TThis formControl = component.GetThis();
        //    formControl.ToggleCss(Css.FormControlStatic, addStaticClass);
        //    return formControl;
        //}

        //public static TThis AddFormControlClass<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addFormControlClass = true)
        //    where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        //    where TWrapper : FormControlForBaseWrapper<TModel>, new()
        //{
        //    TThis formControl = component.GetThis();
        //    formControl.AddFormControlClass = addFormControlClass;
        //    return formControl;
        //}

        //public static TThis AddDescription<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addDescription = true)
        //    where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        //    where TWrapper : FormControlForBaseWrapper<TModel>, new()
        //{
        //    TThis formControl = component.GetThis();
        //    formControl.AddDescription = addDescription;
        //    return formControl;
        //}

        //public static TThis AddValidationMessage<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addValidationMessage = true)
        //    where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        //    where TWrapper : FormControlForBaseWrapper<TModel>, new()
        //{
        //    TThis formControl = component.GetThis();
        //    formControl.AddValidationMessage = addValidationMessage;
        //    return formControl;
        //}

        //public static TThis SetTemplateName<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, string templateName)
        //    where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        //    where TWrapper : FormControlForBaseWrapper<TModel>, new()
        //{
        //    TThis formControl = component.GetThis();
        //    formControl.TemplateName = templateName;
        //    return formControl;
        //}

        //public static TThis AddAdditionalViewData<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, object additionalViewData)
        //    where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
        //    where TWrapper : FormControlForBaseWrapper<TModel>, new()
        //{
        //    TThis formControl = component.GetThis();
        //    formControl.AdditionalViewData = additionalViewData;
        //    return formControl;
        //}

        //public static HiddenFor<TModel, TValue> HiddenFor<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> expression)
        //{
        //    return new HiddenFor<TModel, TValue>(creator, expression);
        //}

        //public static FormControl<MvcBootstrapHelper<TModel>> FormControl<TModel, TValue>(this IFormControlCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> labelExpression)
        //{
        //    return new FormControl<MvcBootstrapHelper<TModel>>(creator).SetControlLabel(labelExpression);
        //}

        //public static TThis SetControlLabel<TModel, TValue, TThis, TWrapper>(this Component<MvcBootstrapHelper<TModel>, TThis, TWrapper> component, Expression<Func<TModel, TValue>> expression, Action<ControlLabel<MvcBootstrapHelper<TModel>>> labelAction = null)
        //    where TThis : FormControl<MvcBootstrapHelper<TModel>, TThis, TWrapper>
        //    where TWrapper : FormControlWrapper<MvcBootstrapHelper<TModel>>, new()
        //{
        //    TThis control = component.GetThis();
        //    ControlLabel<MvcBootstrapHelper<TModel>> controlLabel = GetControlLabel(component.Helper, expression).For(control.GetName());
        //    control.Label = controlLabel;
        //    if (labelAction != null)
        //    {
        //        labelAction(controlLabel);
        //    }
        //    return control;
        //}
    }
}
