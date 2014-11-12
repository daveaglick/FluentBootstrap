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

        public static Form<THelper> Form<THelper>(this IFormCreator<THelper> creator, FormMethod method = FormMethod.Post)
        {
            return new Form<THelper>(creator).SetAction(null).SetMethod(method);
        }

        public static Form<THelper> Form<THelper>(this IFormCreator<THelper> creator, string action, FormMethod method = FormMethod.Post)
        {
            return new Form<THelper>(creator).SetAction(action).SetMethod(method);
        }

        public static Form<THelper> Form<THelper>(this IFormCreator<THelper> creator, string actionName, string controllerName, FormMethod method = FormMethod.Post)
        {
            return new Form<THelper>(creator).SetAction(actionName, controllerName).SetMethod(method);
        }

        public static Form<THelper> SetInline<THelper>(this Form<THelper> form, bool inline = true)
        {
            return form.ToggleCss(Css.FormInline, inline, Css.FormHorizontal);
        }

        public static Form<THelper> SetHorizontal<THelper>(this Form<THelper> form, int? defaultlabelWidth = null, bool horizontal = true)
        {
            form.ToggleCss(Css.FormHorizontal, horizontal, Css.FormInline);
            if (defaultlabelWidth.HasValue)
            {
                form.DefaultLabelWidth = defaultlabelWidth.Value;
            }
            return form;
        }

        // Use action = null to reset form action to current request url
        public static Form<THelper> SetAction<THelper>(this Form<THelper> form, string action)
        {
            return form.MergeAttribute("action", action == null ? form.ViewContext.HttpContext.Request.RawUrl : action);
        }

        public static Form<THelper> SetAction<THelper>(this Form<THelper> form, string actionName, string controllerName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if(routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.SetAction(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary, 
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, true));
        }

        public static Form<THelper> SetRoute<THelper>(this Form<THelper> form, string routeName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.SetAction(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, false));
        }

        public static Form<THelper> SetMethod<THelper>(this Form<THelper> form, FormMethod method)
        {
            form.MergeAttribute("method", HtmlHelper.GetFormMethodString(method));
            return form;
        }

        public static Form<THelper> HideValidationSummary<THelper>(this Form<THelper> form, bool hideValidationSummary = true)
        {
            form.HideValidationSummary = hideValidationSummary;
            return form;
        }

        // ValidationSummary

        public static ValidationSummary<THelper> ValidationSummary<THelper>(this IFormControlCreator<THelper> creator, bool includePropertyErrors = false)
        {
            return new ValidationSummary<THelper>(creator);
        }

        public static ValidationSummary<THelper> IncludePropertyErrors<THelper>(this ValidationSummary<THelper> validationSummary, bool includePropertyErrors = false)
        {
            validationSummary.IncludePropertyErrors = includePropertyErrors;
            return validationSummary;
        }

        // FieldSet

        public static FieldSet<THelper> FieldSet<THelper>(this IFieldSetCreator<THelper> creator)
        {
            return new FieldSet<THelper>(creator);
        }

        // FormGroup

        public static FormGroup<THelper> FormGroup<THelper>(this IFormGroupCreator<THelper> creator, string label = null, string labelFor = null)
        {
            FormGroup<THelper> formGroup = new FormGroup<THelper>(creator);
            if (label != null)
            {
                formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(label, labelFor);
            }
            return formGroup;
        }

        public static FormGroup<THelper> FormGroup<THelper, TValue>(this IFormGroupCreator<THelper> creator, Expression<Func<THelper, TValue>> labelExpression)
        {
            FormGroup<THelper> formGroup = new FormGroup<THelper>(creator);
            formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(labelExpression);
            return formGroup;
        }

        public static FormGroup<THelper> SetGroupLabel<THelper, TThis>(this FormGroup<THelper> formGroup, string label, string labelFor = null, Action<ControlLabel<THelper>> labelAction = null)
        {
            if (label != null)
            {
                ControlLabel<THelper> controlLabel = new ControlLabel<THelper>(formGroup.Helper, label).For(labelFor);
                formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(label, labelFor);
                if (labelAction != null)
                {
                    labelAction(controlLabel);
                }
            }
            return formGroup;
        }

        public static FormGroup<THelper> SetGroupLabel<THelper, TValue, TThis>(this FormGroup<THelper> formGroup, Expression<Func<THelper, TValue>> expression, Action<ControlLabel<THelper>> labelAction = null)
        {
            ControlLabel<THelper> controlLabel = GetControlLabel(formGroup.Helper, expression);
            formGroup.ControlLabel = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return formGroup;
        }

        public static FormGroup<THelper> SetHorizontal<THelper>(this FormGroup<THelper> formGroup, bool? horizontal = true)
        {
            formGroup.Horizontal = horizontal;
            return formGroup;
        }

        // ControlLabel

        public static ControlLabel<THelper> ControlLabel<THelper>(this IControlLabelCreator<THelper> creator, string text, string labelFor = null)
        {
            return new ControlLabel<THelper>(creator, text).For(labelFor);
        }

        public static ControlLabel<THelper> ControlLabel<THelper, TValue>(this IControlLabelCreator<THelper> creator, Expression<Func<THelper, TValue>> textExpression)
        {
            return GetControlLabel(creator, textExpression);
        }

        private static ControlLabel<THelper> GetControlLabel<THelper, TValue>(IComponentCreator<THelper> creator, Expression<Func<THelper, TValue>> expression)
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
            return new ControlLabel<THelper>(creator, text).For(TagBuilder.CreateSanitizedId(
                creator.GetHelper().HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
        }

        public static ControlLabel<THelper> For<THelper>(this ControlLabel<THelper> label, string labelFor)
        {
            return label.MergeAttribute("for", labelFor);
        }

        // Hidden

        public static Hidden<THelper> Hidden<THelper>(this IFormControlCreator<THelper> creator, string name = null, object value = null)
        {
            return new Hidden<THelper>(creator).SetName(name).SetValue(value);
        }

        public static Hidden<THelper> SetName<THelper>(this Hidden<THelper> hidden, string name)
        {
            return hidden.MergeAttribute("name", name == null ? null : hidden.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
        }

        // Input

        public static Input<THelper> Input<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input<THelper>(creator, inputType).SetName(name).SetControlLabel(label).SetValue(value, format);
        }

        public static Input<THelper> SetPlaceholder<THelper>(this Input<THelper> input, string placeholder)
        {
            return input.MergeAttribute("placeholder", placeholder);
        }

        public static Input<THelper> SetReadonly<THelper>(this Input<THelper> input, bool toggle = true)
        {
            return input.MergeAttribute("readonly", toggle ? string.Empty : null);
        }

        public static Input<THelper> SetFeedback<THelper>(this Input<THelper> input, Icon icon)
        {
            if (icon != Icon.None)
            {
                input.ToggleCss(Css.HasFeedback, true);
                input.Icon = icon;
            }
            return input;
        }

        // TextArea

        public static TextArea<THelper> TextArea<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, object value = null, string format = null, int? rows = null)
        {
            return new TextArea<THelper>(creator).SetName(name).SetControlLabel(label).SetValue(value, format).SetRows(rows);
        }

        public static TextArea<THelper> SetRows<THelper>(this TextArea<THelper> textArea, int? rows)
        {
            return textArea.MergeAttribute("rows", rows == null ? null : rows.Value.ToString());
        }

        public static TextArea<THelper> SetValue<THelper>(this TextArea<THelper> textArea, object value, string format = null)
        {
            textArea.TextContent = value == null ? null : textArea.HtmlHelper.FormatValue(value, format);
            return textArea;
        }

        public static TextArea<THelper> SetPlaceholder<THelper>(this TextArea<THelper> textArea, string placeholder)
        {
            return textArea.MergeAttribute("placeholder", placeholder);
        }

        // CheckedControl

        public static CheckedControl<THelper> CheckBox<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, string description = null, bool isChecked = false)
        {
            return new CheckedControl<THelper>(creator, Css.Checkbox).SetName(name).SetControlLabel(label).SetDescription(description).SetChecked(isChecked);
        }

        public static CheckedControl<THelper> Radio<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, string description = null, object value = null, bool isChecked = false)
        {
            return new CheckedControl<THelper>(creator, Css.Radio).SetName(name).SetControlLabel(label).SetDescription(description).SetValue(value).SetChecked(isChecked);
        }

        public static CheckedControl<THelper> SetDescription<THelper>(this CheckedControl<THelper> checkedControl, string description)
        {
            checkedControl.Description = description;
            return checkedControl;
        }

        public static CheckedControl<THelper> SetInline<THelper>(this CheckedControl<THelper> checkedControl, bool inline = true)
        {
            checkedControl.Inline = inline;
            return checkedControl;
        }

        public static CheckedControl<THelper> SetChecked<THelper>(this CheckedControl<THelper> checkedControl, bool @checked = true)
        {
            return checkedControl.MergeAttribute("checked", @checked ? "checked" : null);
        }

        // Select

        public static Select<THelper> Select<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, params object[] options)
        {
            return new Select<THelper>(creator).SetName(name).SetControlLabel(label).AddOptions(options);
        }

        public static Select<THelper> SetMultiple<THelper>(this Select<THelper> select, bool multiple = true)
        {
            return select.MergeAttribute("multiple", multiple ? "multiple" : null);
        }

        public static Select<THelper> AddOptions<THelper>(this Select<THelper> select, params object[] options)
        {
            select.Options.Clear();
            foreach (object option in options)
            {
                select.AddOption(option);
            }
            return select;
        }

        public static Select<THelper> AddOption<THelper>(this Select<THelper> select, object option, string format = null)
        {
            if (option != null)
            {
                select.Options.Add(select.HtmlHelper.FormatValue(option, format));
            }
            return select;
        }

        // Static

        public static Static<THelper> Static<THelper>(this IFormControlCreator<THelper> creator, string label = null, object value = null, string format = null)
        {
            return new Static<THelper>(creator).SetControlLabel(label).SetValue(value, format);
        }

        public static Static<THelper> SetValue<THelper>(this Static<THelper> @static, object value, string format = null)
        {
            @static.TextContent = value == null ? null : @static.HtmlHelper.FormatValue(value, format);
            return @static;
        }

        // Buttons

        public static InputButton<THelper> InputButton<THelper>(this IFormControlCreator<THelper> creator, ButtonType buttonType = ButtonType.Button, string text = null, string label = null, object value = null)
        {
            return new InputButton<THelper>(creator, buttonType).SetText(text).SetControlLabel(label).SetValue(value);
        }

        public static FormButton<THelper> FormButton<THelper>(this IFormControlCreator<THelper> creator, ButtonType buttonType = ButtonType.Button, string text = null, string label = null, object value = null)
        {
            return new FormButton<THelper>(creator, buttonType).SetText(text).SetControlLabel(label).SetValue(value);
        }

        public static FormButton<THelper> Submit<THelper>(this IFormControlCreator<THelper> creator, string text = "Submit", string label = null, object value = null)
        {
            return new FormButton<THelper>(creator, ButtonType.Submit).SetText(text).SetControlLabel(label).SetValue(value).SetState(ButtonState.Primary);
        }

        public static FormButton<THelper> Reset<THelper>(this IFormControlCreator<THelper> creator, string text = "Reset", string label = null, object value = null)
        {
            return new FormButton<THelper>(creator, ButtonType.Reset).SetText(text).SetControlLabel(label).SetValue(value);
        }

        // FormControlFor

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

        // HiddenFor

        public static HiddenFor<THelper, TValue> HiddenFor<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, TValue>> expression)
        {
            return new HiddenFor<THelper, TValue>(creator, expression);
        }

        // FormControl (instance)

        public static FormControl<THelper> FormControl<THelper>(this IFormControlCreator<THelper> creator, string label = null, string labelFor = null)
        {
            FormControl<THelper> formControl = new FormControl<THelper>(creator);
            formControl.Label = new ControlLabel<THelper>(formControl.Helper, label).For(labelFor);
            return formControl;
        }

        public static FormControl<THelper> FormControl<THelper, TValue>(this IFormControlCreator<THelper> creator, Expression<Func<THelper, TValue>> labelExpression)
        {
            return new FormControl<THelper>(creator).SetControlLabel(labelExpression);
        }

        public static FormControl<THelper> AddStaticClass<THelper>(this FormControl<THelper> formControl, bool addStaticClass = true)
        {
            formControl.ToggleCss(Css.FormControlStatic, addStaticClass);
            return formControl;
        }

        // Help

        public static HelpBlock<THelper> HelpBlock<THelper>(this IFormControlCreator<THelper> creator, string text = null)
        {
            return new HelpBlock<THelper>(creator).SetText(text);
        }

        // FormControl

        public static TThis SetControlLabel<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string label, Action<ControlLabel<THelper>> labelAction = null)
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            TThis control = component.GetThis();
            if (label != null)
            {
                ControlLabel<THelper> controlLabel = new ControlLabel<THelper>(control.Helper, label).For(control.GetName());
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

        public static TThis SetHelp<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string help)
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            TThis control = component.GetThis();
            control.Help = help;
            return control;
        }

        public static TThis EnsureFormGroup<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool ensureFormGroup = true)
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            TThis control = component.GetThis();
            control.EnsureFormGroup = ensureFormGroup;
            return control;
        }

        public static TThis SetSize<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, InputSize size)
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(size);
        }

        // IFormValidation

        public static TThis SetState<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, ValidationState state)
            where TThis : Tag<THelper, TThis, TWrapper>, IFormValidation
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        // InputGroup

        public static InputGroup<THelper> InputGroup<THelper>(this IInputGroupCreator<THelper> creator)
        {
            return new InputGroup<THelper>(creator);
        }

        public static InputGroup<THelper> SetSize<THelper>(this InputGroup<THelper> inputGroup, InputGroupSize size)
        {
            return inputGroup.ToggleCss(size);
        }

        public static InputGroupAddon<THelper> InputGroupAddon<THelper>(this IInputGroupAddonCreator<THelper> creator, object content = null)
        {
            return new InputGroupAddon<THelper>(creator).AddContent(content);
        }

        public static InputGroupButton<THelper> InputGroupButton<THelper>(this IInputGroupButtonCreator<THelper> creator)
        {
            return new InputGroupButton<THelper>(creator);
        }

        // Use special creator extensions to create input group addons so we can control the output more closely (I.e., no labels, form groups, etc.)

        public static Input<THelper> Input<THelper>(this InputGroupWrapper<THelper> inputGroup, string name = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input<THelper>(inputGroup, inputType).SetName(name).SetValue(value, format).EnsureFormGroup(false);
        }

        public static CheckedControl<THelper> CheckBox<THelper>(this InputGroupAddonWrapper<THelper> inputGroupAddon, string name = null, bool isChecked = false)
        {
            return new CheckedControl<THelper>(inputGroupAddon, Css.Checkbox) { SuppressLabelWrapper = true }
                .SetName(name).SetChecked(isChecked).EnsureFormGroup(false).SetInline(true);
        }

        public static CheckedControl<THelper> Radio<THelper>(this InputGroupAddonWrapper<THelper> inputGroupAddon, string name = null, object value = null, bool isChecked = false)
        {
            return new CheckedControl<THelper>(inputGroupAddon, Css.Radio) { SuppressLabelWrapper = true }
                .SetName(name).SetValue(value).SetChecked(isChecked).EnsureFormGroup(false).SetInline(true);
        }
    }
}
