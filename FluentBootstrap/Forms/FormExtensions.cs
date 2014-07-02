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
            return new Form<TModel>(creator.GetHelper()).Action(null).Method(method);
        }

        public static Form<TModel> Form<TModel>(this IFormCreator<TModel> creator, string action, FormMethod method = FormMethod.Post)
        {
            return new Form<TModel>(creator.GetHelper()).Action(action).Method(method);
        }

        public static Form<TModel> Form<TModel>(this IFormCreator<TModel> creator, string actionName, string controllerName, FormMethod method = FormMethod.Post)
        {
            return new Form<TModel>(creator.GetHelper()).Action(actionName, controllerName).Method(method);
        }

        public static Form<TModel> Inline<TModel>(this Form<TModel> form, bool inline = true)
        {
            form.ToggleCssClass("form-inline", inline, "form-horizontal");
            return form;
        }

        public static Form<TModel> Horizontal<TModel>(this Form<TModel> form, int? defaultLabelWidth = null, bool horizontal = true)
        {
            form.ToggleCssClass("form-horizontal", horizontal, "form-inline");
            if (defaultLabelWidth.HasValue)
            {
                form.DefaultLabelWidth = defaultLabelWidth.Value;
            }
            return form;
        }

        // Use action = null to reset form action to current request url
        public static Form<TModel> Action<TModel>(this Form<TModel> form, string action)
        {
            form.MergeAttribute("action", action == null ? form.ViewContext.HttpContext.Request.RawUrl : action);
            return form;
        }

        public static Form<TModel> Action<TModel>(this Form<TModel> form, string actionName, string controllerName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if(routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.Action(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary, 
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, true));
        }

        public static Form<TModel> Route<TModel>(this Form<TModel> form, string routeName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return form.Action(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, false));
        }

        public static Form<TModel> Method<TModel>(this Form<TModel> form, FormMethod method)
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
            return new ValidationSummary<TModel>(creator.GetHelper());
        }

        public static ValidationSummary<TModel> IncludePropertyErrors<TModel>(this ValidationSummary<TModel> validationSummary, bool includePropertyErrors = false)
        {
            validationSummary.IncludePropertyErrors = includePropertyErrors;
            return validationSummary;
        }

        // FieldSet

        public static FieldSet<TModel> FieldSet<TModel>(this IFieldSetCreator<TModel> creator)
        {
            return new FieldSet<TModel>(creator.GetHelper());
        }

        // FormGroup

        public static FormGroup<TModel> FormGroup<TModel>(this IFormGroupCreator<TModel> creator, string label = null, string labelFor = null)
        {
            FormGroup<TModel> formGroup = new FormGroup<TModel>(creator.GetHelper());
            if (label != null)
            {
                formGroup.Label = formGroup.Label(label, labelFor);
            }
            return formGroup;
        }

        public static FormGroup<TModel> FormGroup<TModel, TValue>(this IFormGroupCreator<TModel> creator, Expression<Func<TModel, TValue>> labelExpression)
        {
            FormGroup<TModel> formGroup = new FormGroup<TModel>(creator.GetHelper());
            formGroup.Label = formGroup.Label(labelExpression);
            return formGroup;
        }

        public static FormGroup<TModel> GroupLabel<TModel, TThis>(this FormGroup<TModel> formGroup, string label, string labelFor = null, Action<Label<TModel>> labelAction = null)
        {
            if (label != null)
            {
                Label<TModel> controlLabel = new Label<TModel>(formGroup.Helper, label).For(labelFor);
                formGroup.Label = formGroup.Label(label, labelFor);
                if (labelAction != null)
                {
                    labelAction(controlLabel);
                }
            }
            return formGroup;
        }

        public static FormGroup<TModel> GroupLabel<TModel, TValue, TThis>(this FormGroup<TModel> formGroup, Expression<Func<TModel, TValue>> expression, Action<Label<TModel>> labelAction = null)
        {
            Label<TModel> controlLabel = GetLabel(formGroup.Helper, expression);
            formGroup.Label = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return formGroup;
        }

        public static FormGroup<TModel> Horizontal<TModel>(this FormGroup<TModel> formGroup, bool? horizontal = true)
        {
            formGroup.Horizontal = horizontal;
            return formGroup;
        }

        // Label

        public static Label<TModel> Label<TModel>(this ILabelCreator<TModel> creator, string text, string labelFor = null)
        {
            return new Label<TModel>(creator.GetHelper(), text).For(labelFor);
        }

        public static Label<TModel> Label<TModel, TValue>(this ILabelCreator<TModel> creator, Expression<Func<TModel, TValue>> textExpression)
        {
            return GetLabel(creator.GetHelper(), textExpression);
        }

        private static Label<TModel> GetLabel<TModel, TValue>(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.HtmlHelper.ViewData);
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
            return new Label<TModel>(helper, text).For(TagBuilder.CreateSanitizedId(
                helper.HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
        }

        public static Label<TModel> For<TModel>(this Label<TModel> label, string labelFor)
        {
            label.MergeAttribute("for", labelFor);
            return label;
        }

        public static Label<TModel> ScreenReaderOnly<TModel>(this Label<TModel> label, bool screenReaderOnly = true)
        {
            label.ToggleCssClass("sr-only", screenReaderOnly);
            return label;
        }

        // Hidden

        public static Hidden<TModel> Hidden<TModel>(this IFormControlCreator<TModel> creator, string name = null, object value = null)
        {
            return new Hidden<TModel>(creator.GetHelper()).Name(name).Value(value);
        }

        public static Hidden<TModel> Name<TModel>(this Hidden<TModel> hidden, string name)
        {
            hidden.MergeAttribute("name", name == null ? null : hidden.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return hidden;
        }

        // Input

        public static Input<TModel> Input<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input<TModel>(creator.GetHelper(), inputType).Name(name).ControlLabel(label).Value(value, format);
        }

        public static Input<TModel> Placeholder<TModel>(this Input<TModel> input, string placeholder)
        {
            input.MergeAttribute("placeholder", placeholder);
            return input;
        }

        // TextArea

        public static TextArea<TModel> TextArea<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, object value = null, string format = null, int? rows = null)
        {
            return new TextArea<TModel>(creator.GetHelper()).Name(name).ControlLabel(label).Value(value, format).Rows(rows);
        }

        public static TextArea<TModel> Rows<TModel>(this TextArea<TModel> textArea, int? rows)
        {
            textArea.MergeAttribute("rows", rows == null ? null : rows.Value.ToString());
            return textArea;
        }

        public static TextArea<TModel> Value<TModel>(this TextArea<TModel> textArea, object value, string format = null)
        {
            textArea.TextContent = value == null ? null : textArea.HtmlHelper.FormatValue(value, format);
            return textArea;
        }

        public static TextArea<TModel> Placeholder<TModel>(this TextArea<TModel> textArea, string placeholder)
        {
            textArea.MergeAttribute("placeholder", placeholder);
            return textArea;
        }

        // CheckedControl

        public static CheckedControl<TModel> CheckBox<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, string description = null, bool isChecked = false)
        {
            return new CheckedControl<TModel>(creator.GetHelper(), "checkbox").Name(name).ControlLabel(label).Description(description).IsChecked(isChecked);
        }

        public static CheckedControl<TModel> Radio<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, string description = null, object value = null, bool isChecked = false)
        {
            return new CheckedControl<TModel>(creator.GetHelper(), "radio").Name(name).ControlLabel(label).Description(description).Value(value).IsChecked(isChecked);
        }

        public static CheckedControl<TModel> Description<TModel>(this CheckedControl<TModel> checkedControl, string description)
        {
            checkedControl.Description = description;
            return checkedControl;
        }

        public static CheckedControl<TModel> Inline<TModel>(this CheckedControl<TModel> checkedControl, bool inline = true)
        {
            checkedControl.Inline = inline;
            return checkedControl;
        }

        public static CheckedControl<TModel> IsChecked<TModel>(this CheckedControl<TModel> checkedControl, bool isChecked = true)
        {
            checkedControl.MergeAttribute("checked", isChecked ? "checked" : null);
            return checkedControl;
        }

        // Select

        public static Select<TModel> Select<TModel>(this IFormControlCreator<TModel> creator, string name = null, string label = null, params object[] options)
        {
            return new Select<TModel>(creator.GetHelper()).Name(name).ControlLabel(label).Options(options);
        }

        public static Select<TModel> Multiple<TModel>(this Select<TModel> select, bool multiple = true)
        {
            select.MergeAttribute("multiple", multiple ? "multiple" : null);
            return select;
        }

        public static Select<TModel> Options<TModel>(this Select<TModel> select, params object[] options)
        {
            select.Options.Clear();
            foreach (object option in options)
            {
                select.Option(option);
            }
            return select;
        }

        public static Select<TModel> Option<TModel>(this Select<TModel> select, object option, string format = null)
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
            return new Static<TModel>(creator.GetHelper()).ControlLabel(label).Value(value, format);
        }

        public static Static<TModel> Value<TModel>(this Static<TModel> @static, object value, string format = null)
        {
            @static.TextContent = value == null ? null : @static.HtmlHelper.FormatValue(value, format);
            return @static;
        }

        // Buttons

        public static InputButton<TModel> InputButton<TModel>(this IFormControlCreator<TModel> creator, ButtonType buttonType = ButtonType.Button, string text = null, ButtonStyle buttonStyle = ButtonStyle.Default, string label = null, object value = null)
        {
            return new InputButton<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> FormButton<TModel>(this IFormControlCreator<TModel> creator, ButtonType buttonType = ButtonType.Button, string text = null, ButtonStyle buttonStyle = ButtonStyle.Default, string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> Submit<TModel>(this IFormControlCreator<TModel> creator, string text = "Submit", ButtonStyle buttonStyle = ButtonStyle.Primary, string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), ButtonType.Submit, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> Reset<TModel>(this IFormControlCreator<TModel> creator, string text = "Reset", ButtonStyle buttonStyle = ButtonStyle.Default, string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), ButtonType.Reset, buttonStyle).Text(text).ControlLabel(label).Value(value);
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
            FormControlFor<TModel, TValue> formControl = new FormControlFor<TModel, TValue>(creator.GetHelper(), editor, expression)
                .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
                .TemplateName(templateName).AdditionalViewData(additionalViewData);
            formControl.Label = GetLabel(creator.GetHelper(), expression);
            return formControl;
        }

        public static FormControlListFor<TModel, TValue> DisplayListFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            Typography.ListType listType = Typography.ListType.Unstyled, 
            bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayListFor(false, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData, addHidden);
        }

        public static FormControlListFor<TModel, TValue> EditorListFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            Typography.ListType listType = Typography.ListType.Unstyled, 
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            return creator.EditorOrDisplayListFor(true, expression, listType, addDescription, addValidationMessage, templateName, additionalViewData);
        }

        public static FormControlListFor<TModel, TValue> EditorOrDisplayListFor<TModel, TValue>(this IFormControlCreator<TModel> creator, bool editor, Expression<Func<TModel, IEnumerable<TValue>>> expression,
            Typography.ListType listType = Typography.ListType.Unstyled, 
            bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null, bool addHidden = true)
        {
            FormControlListFor<TModel, TValue> formControl = new FormControlListFor<TModel, TValue>(creator.GetHelper(), editor, expression, listType)
                .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage)
                .TemplateName(templateName).AdditionalViewData(additionalViewData);
            formControl.Label = GetLabel(creator.GetHelper(), expression);
            return formControl;
        }

        public static TThis AddHidden<TModel, TValue, TThis>(this FormControlForBase<TModel, TValue, TThis> component, bool addHidden = true)
            where TThis : FormControlForBase<TModel, TValue, TThis>
        {
            TThis formControl = component.GetThis();
            formControl.AddHidden = addHidden;
            return formControl;
        }

        public static TThis AddStaticClass<TModel, TValue, TThis>(this FormControlForBase<TModel, TValue, TThis> component, bool addStaticClass = true)
            where TThis : FormControlForBase<TModel, TValue, TThis>
        {
            TThis formControl = component.GetThis();
            formControl.ToggleCssClass("form-control-static", addStaticClass);
            return formControl;
        }

        public static TThis AddFormControlClass<TModel, TValue, TThis>(this FormControlForBase<TModel, TValue, TThis> component, bool addFormControlClass = true)
            where TThis : FormControlForBase<TModel, TValue, TThis>
        {
            TThis formControl = component.GetThis();
            formControl.AddFormControlClass = addFormControlClass;
            return formControl;
        }

        public static TThis AddDescription<TModel, TValue, TThis>(this FormControlForBase<TModel, TValue, TThis> component, bool addDescription = true)
            where TThis : FormControlForBase<TModel, TValue, TThis>
        {
            TThis formControl = component.GetThis();
            formControl.AddDescription = addDescription;
            return formControl;
        }

        public static TThis AddValidationMessage<TModel, TValue, TThis>(this FormControlForBase<TModel, TValue, TThis> component, bool addValidationMessage = true)
            where TThis : FormControlForBase<TModel, TValue, TThis>
        {
            TThis formControl = component.GetThis();
            formControl.AddValidationMessage = addValidationMessage;
            return formControl;
        }

        public static TThis TemplateName<TModel, TValue, TThis>(this FormControlForBase<TModel, TValue, TThis> component, string templateName)
            where TThis : FormControlForBase<TModel, TValue, TThis>
        {
            TThis formControl = component.GetThis();
            formControl.TemplateName = templateName;
            return formControl;
        }

        public static TThis AdditionalViewData<TModel, TValue, TThis>(this FormControlForBase<TModel, TValue, TThis> component, object additionalViewData)
            where TThis : FormControlForBase<TModel, TValue, TThis>
        {
            TThis formControl = component.GetThis();
            formControl.AdditionalViewData = additionalViewData;
            return formControl;
        }

        // HiddenFor

        public static HiddenFor<TModel, TValue> HiddenFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> expression)
        {
            return new HiddenFor<TModel, TValue>(creator.GetHelper(), expression);
        }

        // FormControl (instance)

        public static FormControl<TModel> FormControl<TModel>(this IFormControlCreator<TModel> creator, string label = null, string labelFor = null)
        {
            FormControl<TModel> formControl = new FormControl<TModel>(creator.GetHelper());
            formControl.Label = new Label<TModel>(formControl.Helper, label).For(labelFor);
            return formControl;
        }

        public static FormControl<TModel> FormControl<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> labelExpression)
        {
            return new FormControl<TModel>(creator.GetHelper()).ControlLabel(labelExpression);
        }

        public static FormControl<TModel> AddStaticClass<TModel>(this FormControl<TModel> formControl, bool addStaticClass = true)
        {
            formControl.ToggleCssClass("form-control-static", addStaticClass);
            return formControl;
        }

        // Help

        public static HelpBlock<TModel> HelpBlock<TModel>(this IFormControlCreator<TModel> creator, string text = null)
        {
            return new HelpBlock<TModel>(creator.GetHelper()).Text(text);
        }

        // FormControl

        public static TThis ControlLabel<TModel, TThis>(this Component<TModel, TThis> component, string label, Action<Label<TModel>> labelAction = null)
            where TThis : FormControl<TModel, TThis>
        {
            TThis control = component.GetThis();
            if (label != null)
            {
                Label<TModel> controlLabel = new Label<TModel>(control.Helper, label).For(control.GetName());
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

        public static TThis ControlLabel<TModel, TValue, TThis>(this Component<TModel, TThis> component, Expression<Func<TModel, TValue>> expression, Action<Label<TModel>> labelAction = null)
            where TThis : FormControl<TModel, TThis>
        {
            TThis control = component.GetThis();
            Label<TModel> controlLabel = GetLabel(component.Helper, expression).For(control.GetName());
            control.Label = controlLabel;
            if (labelAction != null)
            {
                labelAction(controlLabel);
            }
            return control;
        }

        public static TThis Help<TModel, TThis>(this Component<TModel, TThis> component, string help)
            where TThis : FormControl<TModel, TThis>
        {
            TThis control = component.GetThis();
            control.Help = help;
            return control;
        }

        public static TThis EnsureFormGroup<TModel, TThis>(this Component<TModel, TThis> component, bool ensureFormGroup = true)
            where TThis : FormControl<TModel, TThis>
        {
            TThis control = component.GetThis();
            control.EnsureFormGroup = ensureFormGroup;
            return control;
        }

        public static TThis InputLg<TModel, TThis>(this Component<TModel, TThis> component, bool lg = true)
            where TThis : FormControl<TModel, TThis>
        {
            TThis control = component.GetThis();
            control.ToggleCssClass("input-lg", lg, "input-sm");
            return control;
        }

        public static TThis InputSm<TModel, TThis>(this Component<TModel, TThis> component, bool sm = true)
            where TThis : FormControl<TModel, TThis>
        {
            TThis control = component.GetThis();
            control.ToggleCssClass("input-sm", sm, "input-lg");
            return control;
        }

        // IFormValidation

        public static TThis HasSuccess<TModel, TThis>(this Component<TModel, TThis> component, bool hasSuccess = true)
            where TThis : Tag<TModel, TThis>, IFormValidation
        {
            TThis tag = component.GetThis();
            tag.ToggleCssClass("has-success", hasSuccess, "has-warning", "has-error");
            return tag;
        }

        public static TThis HasWarning<TModel, TThis>(this Component<TModel, TThis> component, bool hasSuccess = true)
            where TThis : Tag<TModel, TThis>, IFormValidation
        {
            TThis tag = component.GetThis();
            tag.ToggleCssClass("has-warning", hasSuccess, "has-success", "has-error");
            return tag;
        }

        public static TThis HasError<TModel, TThis>(this Component<TModel, TThis> component, bool hasError = true)
            where TThis : Tag<TModel, TThis>, IFormValidation
        {
            TThis tag = component.GetThis();
            tag.ToggleCssClass("has-error", hasError, "has-warning", "has-success");
            return tag;
        }
    }
}
