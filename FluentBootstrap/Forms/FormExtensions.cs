using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using FluentBootstrap.Forms;
using System.Linq.Expressions;

namespace FluentBootstrap
{
    public static class FormExtensions
    {
        // Form

        public static Form<TModel> Form<TModel>(this IFormCreator<TModel> creator, FormMethod method = FormMethod.Post)
        {
            return new Form<TModel>(creator).SetAction(null).SetMethod(method);
        }

        public static Form<TModel> Form<TModel>(this IFormCreator<TModel> creator, string action, FormMethod method = FormMethod.Post)
        {
            return new Form<TModel>(creator).SetAction(action).SetMethod(method);
        }

        public static Form<TModel> Form<TModel>(this IFormCreator<TModel> creator, string actionName, string controllerName, FormMethod method = FormMethod.Post)
        {
            return new Form<TModel>(creator).SetAction(actionName, controllerName).SetMethod(method);
        }

        public static Form<TModel> SetInline<TModel>(this Form<TModel> form, bool inline = true)
        {
            return form.ToggleCss(Css.FormInline, inline, Css.FormHorizontal);
        }

        public static Form<TModel> SetHorizontal<TModel>(this Form<TModel> form, int? defaultlabelWidth = null, bool horizontal = true)
        {
            form.ToggleCss(Css.FormHorizontal, horizontal, Css.FormInline);
            if (defaultlabelWidth.HasValue)
            {
                form.DefaultLabelWidth = defaultlabelWidth.Value;
            }
            return form;
        }

        // Use action = null to reset form action to current request url
        public static Form<TModel> SetAction<TModel>(this Form<TModel> form, string action)
        {
            return form.MergeAttribute("action", action == null ? form.ViewContext.HttpContext.Request.RawUrl : action);
        }

        public static Form<TModel> SetAction<TModel>(this Form<TModel> form, string actionName, string controllerName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if(routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.SetAction(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary, 
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, true));
        }

        public static Form<TModel> SetRoute<TModel>(this Form<TModel> form, string routeName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.SetAction(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, false));
        }

        public static Form<TModel> SetMethod<TModel>(this Form<TModel> form, FormMethod method)
        {
            form.MergeAttribute("method", HtmlHelper.GetFormMethodString(method));
            return form;
        }

        public static Form<TModel> HideValidationSummary<TModel>(this Form<TModel> form, bool hideValidationSummary = true)
        {
            form.HideValidationSummary = hideValidationSummary;
            return form;
        }

        // ValidationSummary

        public static ValidationSummary<TModel> ValidationSummary<TModel>(this IFormControlCreator<TModel> creator, bool includePropertyErrors = false)
        {
            return new ValidationSummary<TModel>(creator);
        }

        public static ValidationSummary<TModel> IncludePropertyErrors<TModel>(this ValidationSummary<TModel> validationSummary, bool includePropertyErrors = false)
        {
            validationSummary.IncludePropertyErrors = includePropertyErrors;
            return validationSummary;
        }

        // FieldSet

        public static FieldSet<TModel> FieldSet<TModel>(this IFieldSetCreator<TModel> creator)
        {
            return new FieldSet<TModel>(creator);
        }

        // FormGroup

        public static FormGroup<TModel> FormGroup<TModel>(this IFormGroupCreator<TModel> creator, string label = null, string labelFor = null)
        {
            FormGroup<TModel> formGroup = new FormGroup<TModel>(creator);
            if (label != null)
            {
                formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(label, labelFor);
            }
            return formGroup;
        }

        public static FormGroup<TModel> FormGroup<TModel, TValue>(this IFormGroupCreator<TModel> creator, Expression<Func<TModel, TValue>> labelExpression)
        {
            FormGroup<TModel> formGroup = new FormGroup<TModel>(creator);
            formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(labelExpression);
            return formGroup;
        }

        public static FormGroup<TModel> SetGroupLabel<TModel, TThis>(this FormGroup<TModel> formGroup, string label, string labelFor = null, Action<ControlLabel<TModel>> labelAction = null)
        {
            if (label != null)
            {
                ControlLabel<TModel> controlLabel = new ControlLabel<TModel>(formGroup.Helper, label).For(labelFor);
                formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(label, labelFor);
                if (labelAction != null)
                {
                    labelAction(controlLabel);
                }
            }
            return formGroup;
        }

        public static FormGroup<TModel> SetGroupLabel<TModel, TValue, TThis>(this FormGroup<TModel> formGroup, Expression<Func<TModel, TValue>> expression, Action<ControlLabel<TModel>> labelAction = null)
        {
            ControlLabel<TModel> controlLabel = GetControlLabel(formGroup.Helper, expression);
            formGroup.ControlLabel = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return formGroup;
        }

        public static FormGroup<TModel> SetHorizontal<TModel>(this FormGroup<TModel> formGroup, bool? horizontal = true)
        {
            formGroup.Horizontal = horizontal;
            return formGroup;
        }

        // ControlLabel

        public static ControlLabel<TModel> ControlLabel<TModel>(this IControlLabelCreator<TModel> creator, string text, string labelFor = null)
        {
            return new ControlLabel<TModel>(creator, text).For(labelFor);
        }

        public static ControlLabel<TModel> ControlLabel<TModel, TValue>(this IControlLabelCreator<TModel> creator, Expression<Func<TModel, TValue>> textExpression)
        {
            return GetControlLabel(creator, textExpression);
        }

        private static ControlLabel<TModel> GetControlLabel<TModel, TValue>(IComponentCreator<TModel> creator, Expression<Func<TModel, TValue>> expression)
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
            return new ControlLabel<TModel>(creator, text).For(TagBuilder.CreateSanitizedId(
                creator.GetHelper().HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
        }

        public static ControlLabel<TModel> For<TModel>(this ControlLabel<TModel> label, string labelFor)
        {
            return label.MergeAttribute("for", labelFor);
        }

        // Hidden

        public static Hidden<TModel> Hidden<TModel>(this IFormControlCreator<TModel> creator, string name = null, object value = null)
        {
            return new Hidden<TModel>(creator).SetName(name).SetValue(value);
        }

        public static Hidden<TModel> SetName<TModel>(this Hidden<TModel> hidden, string name)
        {
            return hidden.MergeAttribute("name", name == null ? null : hidden.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
        }

        // Input

        public static Input<TModel> Input<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input<TModel>(creator, inputType).SetName(name).SetControlLabel(label).SetValue(value, format);
        }

        public static Input<TModel> SetPlaceholder<TModel>(this Input<TModel> input, string placeholder)
        {
            return input.MergeAttribute("placeholder", placeholder);
        }

        public static Input<TModel> SetReadonly<TModel>(this Input<TModel> input, bool toggle = true)
        {
            return input.MergeAttribute("readonly", toggle ? string.Empty : null);
        }

        public static Input<TModel> SetFeedback<TModel>(this Input<TModel> input, Icon icon)
        {
            if (icon != Icon.None)
            {
                input.ToggleCss(Css.HasFeedback, true);
                input.Icon = icon;
            }
            return input;
        }

        // TextArea

        public static TextArea<TModel> TextArea<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, object value = null, string format = null, int? rows = null)
        {
            return new TextArea<TModel>(creator).SetName(name).SetControlLabel(label).SetValue(value, format).SetRows(rows);
        }

        public static TextArea<TModel> SetRows<TModel>(this TextArea<TModel> textArea, int? rows)
        {
            return textArea.MergeAttribute("rows", rows == null ? null : rows.Value.ToString());
        }

        public static TextArea<TModel> SetValue<TModel>(this TextArea<TModel> textArea, object value, string format = null)
        {
            textArea.TextContent = value == null ? null : textArea.HtmlHelper.FormatValue(value, format);
            return textArea;
        }

        public static TextArea<TModel> SetPlaceholder<TModel>(this TextArea<TModel> textArea, string placeholder)
        {
            return textArea.MergeAttribute("placeholder", placeholder);
        }

        // CheckedControl

        public static CheckedControl<TModel> CheckBox<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, string description = null, bool isChecked = false)
        {
            return new CheckedControl<TModel>(creator, Css.Checkbox).SetName(name).SetControlLabel(label).SetDescription(description).SetChecked(isChecked);
        }

        public static CheckedControl<TModel> Radio<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, string description = null, object value = null, bool isChecked = false)
        {
            return new CheckedControl<TModel>(creator, Css.Radio).SetName(name).SetControlLabel(label).SetDescription(description).SetValue(value).SetChecked(isChecked);
        }

        public static CheckedControl<TModel> SetDescription<TModel>(this CheckedControl<TModel> checkedControl, string description)
        {
            checkedControl.Description = description;
            return checkedControl;
        }

        public static CheckedControl<TModel> SetInline<TModel>(this CheckedControl<TModel> checkedControl, bool inline = true)
        {
            checkedControl.Inline = inline;
            return checkedControl;
        }

        public static CheckedControl<TModel> SetChecked<TModel>(this CheckedControl<TModel> checkedControl, bool @checked = true)
        {
            return checkedControl.MergeAttribute("checked", @checked ? "checked" : null);
        }

        // Select

        public static Select<TModel> Select<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, params object[] options)
        {
            return new Select<TModel>(creator).SetName(name).SetControlLabel(label).AddOptions(options);
        }

        public static Select<TModel> SetMultiple<TModel>(this Select<TModel> select, bool multiple = true)
        {
            return select.MergeAttribute("multiple", multiple ? "multiple" : null);
        }

        public static Select<TModel> AddOptions<TModel>(this Select<TModel> select, params object[] options)
        {
            select.Options.Clear();
            foreach (object option in options)
            {
                select.AddOption(option);
            }
            return select;
        }

        public static Select<TModel> AddOption<TModel>(this Select<TModel> select, object option, string format = null)
        {
            if (option != null)
            {
                select.Options.Add(select.HtmlHelper.FormatValue(option, format));
            }
            return select;
        }

        // Static

        public static Static<TModel> Static<TModel>(this IFormControlCreator<TModel> creator, string label = null, object value = null, string format = null)
        {
            return new Static<TModel>(creator).SetControlLabel(label).SetValue(value, format);
        }

        public static Static<TModel> SetValue<TModel>(this Static<TModel> @static, object value, string format = null)
        {
            @static.TextContent = value == null ? null : @static.HtmlHelper.FormatValue(value, format);
            return @static;
        }

        // Buttons

        public static InputButton<TModel> InputButton<TModel>(this IFormControlCreator<TModel> creator, ButtonType buttonType = ButtonType.Button, string text = null, string label = null, object value = null)
        {
            return new InputButton<TModel>(creator, buttonType).SetText(text).SetControlLabel(label).SetValue(value);
        }

        public static FormButton<TModel> FormButton<TModel>(this IFormControlCreator<TModel> creator, ButtonType buttonType = ButtonType.Button, string text = null, string label = null, object value = null)
        {
            return new FormButton<TModel>(creator, buttonType).SetText(text).SetControlLabel(label).SetValue(value);
        }

        public static FormButton<TModel> Submit<TModel>(this IFormControlCreator<TModel> creator, string text = "Submit", string label = null, object value = null)
        {
            return new FormButton<TModel>(creator, ButtonType.Submit).SetText(text).SetControlLabel(label).SetValue(value).SetState(ButtonState.Primary);
        }

        public static FormButton<TModel> Reset<TModel>(this IFormControlCreator<TModel> creator, string text = "Reset", string label = null, object value = null)
        {
            return new FormButton<TModel>(creator, ButtonType.Reset).SetText(text).SetControlLabel(label).SetValue(value);
        }

        // FormControlFor

        public static FormControlFor<TModel, TValue> DisplayFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> expression, 
            bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayFor(false, expression, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        }

        public static FormControlFor<TModel, TValue> EditorFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> expression,
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayFor(true, expression, addDescription, addValidationMessage, templateName, additionalViewData);
        }

        public static FormControlFor<TModel, TValue> EditorOrDisplayFor<TModel, TValue>(this IFormControlCreator<TModel> creator, bool editor, Expression<Func<TModel, TValue>> expression,
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
        {
            FormControlFor<TModel, TValue> formControl = new FormControlFor<TModel, TValue>(creator, editor, expression)
                .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
                .SetTemplateName(templateName).AddAdditionalViewData(additionalViewData);
            formControl.Label = GetControlLabel(creator, expression);
            return formControl;
        }

        public static FormControlListFor<TModel, TValue> DisplayListFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayListFor(false, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        }

        public static FormControlListFor<TModel, TValue> EditorListFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayListFor(true, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData);
        }

        public static FormControlListFor<TModel, TValue> EditorOrDisplayListFor<TModel, TValue>(this IFormControlCreator<TModel> creator, bool editor, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            ListType listType = ListType.Unstyled, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
        {
            FormControlListFor<TModel, TValue> formControl = new FormControlListFor<TModel, TValue>(creator, editor, expression, listType)
                .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
                .SetTemplateName(templateName).AddAdditionalViewData(additionalViewData);
            formControl.Label = GetControlLabel(creator, expression);
            return formControl;
        }

        public static TThis AddHidden<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addHidden = true)
            where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<TModel>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddHidden = addHidden;
            return formControl;
        }

        public static TThis AddStaticClass<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addStaticClass = true)
            where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<TModel>, new()
        {
            TThis formControl = component.GetThis();
            formControl.ToggleCss(Css.FormControlStatic, addStaticClass);
            return formControl;
        }

        public static TThis AddFormControlClass<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addFormControlClass = true)
            where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<TModel>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddFormControlClass = addFormControlClass;
            return formControl;
        }

        public static TThis AddDescription<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addDescription = true)
            where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<TModel>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddDescription = addDescription;
            return formControl;
        }

        public static TThis AddValidationMessage<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, bool addValidationMessage = true)
            where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<TModel>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AddValidationMessage = addValidationMessage;
            return formControl;
        }

        public static TThis SetTemplateName<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, string templateName)
            where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<TModel>, new()
        {
            TThis formControl = component.GetThis();
            formControl.TemplateName = templateName;
            return formControl;
        }

        public static TThis AddAdditionalViewData<TModel, TValue, TThis, TWrapper>(this FormControlForBase<TModel, TValue, TThis, TWrapper> component, object additionalViewData)
            where TThis : FormControlForBase<TModel, TValue, TThis, TWrapper>
            where TWrapper : FormControlForBaseWrapper<TModel>, new()
        {
            TThis formControl = component.GetThis();
            formControl.AdditionalViewData = additionalViewData;
            return formControl;
        }

        // HiddenFor

        public static HiddenFor<TModel, TValue> HiddenFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> expression)
        {
            return new HiddenFor<TModel, TValue>(creator, expression);
        }

        // FormControl (instance)

        public static FormControl<TModel> FormControl<TModel>(this IFormControlCreator<TModel> creator, string label = null, string labelFor = null)
        {
            FormControl<TModel> formControl = new FormControl<TModel>(creator);
            formControl.Label = new ControlLabel<TModel>(formControl.Helper, label).For(labelFor);
            return formControl;
        }

        public static FormControl<TModel> FormControl<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> labelExpression)
        {
            return new FormControl<TModel>(creator).SetControlLabel(labelExpression);
        }

        public static FormControl<TModel> AddStaticClass<TModel>(this FormControl<TModel> formControl, bool addStaticClass = true)
        {
            formControl.ToggleCss(Css.FormControlStatic, addStaticClass);
            return formControl;
        }

        // Help

        public static HelpBlock<TModel> HelpBlock<TModel>(this IFormControlCreator<TModel> creator, string text = null)
        {
            return new HelpBlock<TModel>(creator).SetText(text);
        }

        // FormControl

        public static TThis SetControlLabel<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string label, Action<ControlLabel<TModel>> labelAction = null)
            where TThis : FormControl<TModel, TThis, TWrapper>
            where TWrapper : FormControlWrapper<TModel>, new()
        {
            TThis control = component.GetThis();
            if (label != null)
            {
                ControlLabel<TModel> controlLabel = new ControlLabel<TModel>(control.Helper, label).For(control.GetName());
                control.Label = controlLabel;
                if (labelAction != null)
                {
                    labelAction(controlLabel);
                }
            }
            else
            {
                control.Label = null;
            }
            return control;
        }

        public static TThis SetControlLabel<TModel, TValue, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, Expression<Func<TModel, TValue>> expression, Action<ControlLabel<TModel>> labelAction = null)
            where TThis : FormControl<TModel, TThis, TWrapper>
            where TWrapper : FormControlWrapper<TModel>, new()
        {
            TThis control = component.GetThis();
            ControlLabel<TModel> controlLabel = GetControlLabel(component.Helper, expression).For(control.GetName());
            control.Label = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return control;
        }

        public static TThis SetHelp<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string help)
            where TThis : FormControl<TModel, TThis, TWrapper>
            where TWrapper : FormControlWrapper<TModel>, new()
        {
            TThis control = component.GetThis();
            control.Help = help;
            return control;
        }

        public static TThis EnsureFormGroup<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool ensureFormGroup = true)
            where TThis : FormControl<TModel, TThis, TWrapper>
            where TWrapper : FormControlWrapper<TModel>, new()
        {
            TThis control = component.GetThis();
            control.EnsureFormGroup = ensureFormGroup;
            return control;
        }

        public static TThis SetSize<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, InputSize size)
            where TThis : FormControl<TModel, TThis, TWrapper>
            where TWrapper : FormControlWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(size);
        }

        // IFormValidation

        public static TThis SetState<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, ValidationState state)
            where TThis : Tag<TModel, TThis, TWrapper>, IFormValidation
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        // InputGroup

        public static InputGroup<TModel> InputGroup<TModel>(this IInputGroupCreator<TModel> creator)
        {
            return new InputGroup<TModel>(creator);
        }

        public static InputGroup<TModel> SetSize<TModel>(this InputGroup<TModel> inputGroup, InputGroupSize size)
        {
            return inputGroup.ToggleCss(size);
        }

        public static InputGroupAddon<TModel> InputGroupAddon<TModel>(this IInputGroupAddonCreator<TModel> creator, object content = null)
        {
            return new InputGroupAddon<TModel>(creator).AddContent(content);
        }

        public static InputGroupButton<TModel> InputGroupButton<TModel>(this IInputGroupButtonCreator<TModel> creator)
        {
            return new InputGroupButton<TModel>(creator);
        }

        // Use special creator extensions to create input group addons so we can control the output more closely (I.e., no labels, form groups, etc.)

        public static Input<TModel> Input<TModel>(this InputGroupWrapper<TModel> inputGroup, string name = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input<TModel>(inputGroup, inputType).SetName(name).SetValue(value, format).EnsureFormGroup(false);
        }

        public static CheckedControl<TModel> CheckBox<TModel>(this InputGroupAddonWrapper<TModel> inputGroupAddon, string name = null, bool isChecked = false)
        {
            return new CheckedControl<TModel>(inputGroupAddon, Css.Checkbox) { SuppressLabelWrapper = true }
                .SetName(name).SetChecked(isChecked).EnsureFormGroup(false).SetInline(true);
        }

        public static CheckedControl<TModel> Radio<TModel>(this InputGroupAddonWrapper<TModel> inputGroupAddon, string name = null, object value = null, bool isChecked = false)
        {
            return new CheckedControl<TModel>(inputGroupAddon, Css.Radio) { SuppressLabelWrapper = true }
                .SetName(name).SetValue(value).SetChecked(isChecked).EnsureFormGroup(false).SetInline(true);
        }
    }
}
