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

        public static Form<TModel> Horizontal<TModel>(this Form<TModel> form, int? defaultLabelWidth = 2, bool horizontal = true)
        {
            form.ToggleCssClass("form-horizontal", horizontal, "form-inline");
            form.DefaultLabelWidth = defaultLabelWidth;
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

        // FieldSet

        public static FieldSet<TModel> FieldSet<TModel>(this IFieldSetCreator<TModel> creator)
        {
            return new FieldSet<TModel>(creator.GetHelper());
        }

        // FormGroup

        public static FormGroup<TModel> FormGroup<TModel>(this IFormGroupCreator<TModel> creator)
        {
            return new FormGroup<TModel>(creator.GetHelper());
        }

        // Label

        public static Label<TModel> Label<TModel>(this ILabelCreator<TModel> creator, string text)
        {
            return new Label<TModel>(creator.GetHelper(), text);
        }

        public static Label<TModel> LabelFor<TModel, TValue>(this ILabelCreator<TModel> creator, Expression<Func<TModel, TValue>> expression)
        {
            return GetLabelFor(creator.GetHelper(), expression);
        }

        private static Label<TModel> GetLabelFor<TModel, TValue>(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
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

        public static Label<TModel> For<TModel>(this Label<TModel> label, string @for)
        {
            label.MergeAttribute("for", @for);
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

        public static InputButton<TModel> InputButton<TModel>(this IFormControlCreator<TModel> creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, string label = null, object value = null)
        {
            return new InputButton<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> FormButton<TModel>(this IFormControlCreator<TModel> creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> Submit<TModel>(this IFormControlCreator<TModel> creator, ButtonStyle buttonStyle = ButtonStyle.Primary, string text = "Submit", string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), ButtonType.Submit, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> Reset<TModel>(this IFormControlCreator<TModel> creator, ButtonStyle buttonStyle = ButtonStyle.Default, string text = "Reset", string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), ButtonType.Reset, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        // DisplayFor

        public static DisplayFor<TModel, TValue> DisplayFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> expression, 
            bool addHidden = true, bool addDescription = true, bool addValidationMessage = true, string templateName = null, object additionalViewData = null)
        {
            DisplayFor<TModel, TValue> displayFor = new DisplayFor<TModel, TValue>(creator.GetHelper(), expression)
                .AddHidden(addHidden).AddDescription(addDescription).AddValidationMessage(addValidationMessage).TemplateName(templateName).AdditionalViewData(additionalViewData);
            displayFor.Label = GetLabelFor(creator.GetHelper(), expression);
            return displayFor;
        }

        public static DisplayFor<TModel, TValue> AddHidden<TModel, TValue>(this DisplayFor<TModel, TValue> displayFor, bool addHidden = true)
        {
            displayFor.AddHidden = addHidden;
            return displayFor;
        }

        public static DisplayFor<TModel, TValue> AddDescription<TModel, TValue>(this DisplayFor<TModel, TValue> displayFor, bool addDescription = true)
        {
            displayFor.AddDescription = addDescription;
            return displayFor;
        }

        public static DisplayFor<TModel, TValue> AddValidationMessage<TModel, TValue>(this DisplayFor<TModel, TValue> displayFor, bool addValidationMessage = true)
        {
            displayFor.AddValidationMessage = addValidationMessage;
            return displayFor;
        }

        public static DisplayFor<TModel, TValue> TemplateName<TModel, TValue>(this DisplayFor<TModel, TValue> displayFor, string templateName)
        {
            displayFor.TemplateName = templateName;
            return displayFor;
        }

        public static DisplayFor<TModel, TValue> AdditionalViewData<TModel, TValue>(this DisplayFor<TModel, TValue> displayFor, object additionalViewData)
        {
            displayFor.AdditionalViewData = additionalViewData;
            return displayFor;
        }

        // HiddenFor

        public static HiddenFor<TModel, TValue> HiddenFor<TModel, TValue>(this IFormControlCreator<TModel> creator, Expression<Func<TModel, TValue>> expression)
        {
            return new HiddenFor<TModel, TValue>(creator.GetHelper(), expression);
        }

        // FormControl

        public static TThis ControlLabel<TModel, TThis>(this Component<TModel, TThis> component, string label, Action<Label<TModel>> labelAction = null)
            where TThis : FormControl<TModel, TThis>
        {
            TThis control = component.GetThis();
            if(label != null)
            {
                Label<TModel> controlLabel = new Label<TModel>(control.Helper, label);
                control.Label = controlLabel;
                if (labelAction != null)
                {
                    labelAction(controlLabel);
                }
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
