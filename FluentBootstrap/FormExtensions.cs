using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using FluentBootstrap.Forms;

namespace FluentBootstrap
{
    public static class FormExtensions
    {
        // Form

        public static Form<TModel> Form<TModel>(this Form<TModel>.ICreate creator, FormMethod method = FormMethod.Post)
        {
            return new Form<TModel>(creator.GetHelper()).Action(null).Method(method);
        }

        public static Form<TModel> Form<TModel>(this Form<TModel>.ICreate creator, string action, FormMethod method = FormMethod.Post)
        {
            return new Form<TModel>(creator.GetHelper()).Action(action).Method(method);
        }

        public static Form<TModel> Form<TCreator, TModel>(this Form<TModel>.ICreate creator, string actionName, string controllerName, FormMethod method = FormMethod.Post)
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

        public static FieldSet<TModel> FieldSet<TModel>(this FieldSet<TModel>.ICreate creator)
        {
            return new FieldSet<TModel>(creator.GetHelper());
        }

        // FormGroup

        public static FormGroup<TModel> FormGroup<TModel>(this FormGroup<TModel>.ICreate creator)
        {
            return new FormGroup<TModel>(creator.GetHelper());
        }

        // Label

        public static Label<TModel> Label<TCreator, TModel>(this Label<TModel>.ICreate creator, string label)
        {
            return new Label<TModel>(creator.GetHelper(), label);
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

        // Input

        public static Input<TModel> Input<TModel>(this Input<TModel>.ICreate creator, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input<TModel>(creator.GetHelper(), inputType).Name(name).ControlLabel(label).Value(value, format);
        }

        public static Input<TModel> Placeholder<TModel>(this Input<TModel> input, string placeholder)
        {
            input.MergeAttribute("placeholder", placeholder);
            return input;
        }

        // TextArea

        public static TextArea<TModel> TextArea<TCreator, TModel>(this TextArea<TModel>.ICreate creator, string name = null, string label = null, object value = null, string format = null, int? rows = null)
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

        public static CheckedControl<TModel> CheckBox<TModel>(this CheckedControl<TModel>.ICreate creator, string name = null, string label = null, string description = null, bool isChecked = false)
        {
            return new CheckedControl<TModel>(creator.GetHelper(), "checkbox").Name(name).ControlLabel(label).Description(description).IsChecked(isChecked);
        }

        public static CheckedControl<TModel> Radio<TCreator, TModel>(this TCreator creator, string name = null, string label = null, string description = null, object value = null, bool isChecked = false)
            where TCreator : CheckedControl<TModel>.ICreate
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

        public static Select<TModel> Select<TModel>(this Select<TModel>.ICreate creator, string name = null, string label = null, params object[] options)
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

        public static Static<TModel> Static<TModel>(this Static<TModel>.ICreate creator, string label = null, object value = null, string format = null)
        {
            return new Static<TModel>(creator.GetHelper()).ControlLabel(label).Value(value, format);
        }

        public static Static<TModel> Value<TModel>(this Static<TModel> @static, object value, string format = null)
        {
            @static.TextContent = value == null ? null : @static.HtmlHelper.FormatValue(value, format);
            return @static;
        }

        // Buttons

        public static InputButton<TModel> InputButton<TModel>(this InputButton<TModel>.ICreate creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, string label = null, object value = null)
        {
            return new InputButton<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> FormButton<TModel>(this FormButton<TModel>.ICreate creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> Submit<TModel>(this FormButton<TModel>.ICreate creator, ButtonStyle buttonStyle = ButtonStyle.Primary, string text = "Submit", string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), ButtonType.Submit, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        public static FormButton<TModel> Reset<TModel>(this FormButton<TModel>.ICreate creator, ButtonStyle buttonStyle = ButtonStyle.Default, string text = "Reset", string label = null, object value = null)
        {
            return new FormButton<TModel>(creator.GetHelper(), ButtonType.Reset, buttonStyle).Text(text).ControlLabel(label).Value(value);
        }

        // DisplayFor

        //public static DisplayFor<TModel> DisplayFor<TCreator, TModel>(this TCreator creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, string label = null, object value = null)
        //    where TCreator : InputButton.ICreate
        //{
        //    return new InputButton(creator.GetHelper(), buttonType, buttonStyle).Text(text).ControlLabel(label).Value(value);
        //}


        // FormControl
        
        public static TFormControl Name<TFormControl, TModel>(this TFormControl control, string name)
            where TFormControl : FormControl<TModel>
        {
            control.MergeAttribute("name", name == null ? null : control.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return control;
        }

        public static TFormControl ControlLabel<TFormControl, TModel>(this TFormControl control, string label, Action<Label<TModel>> labelAction = null)
            where TFormControl : FormControl<TModel>
        {
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

        public static TFormControl Help<TFormControl, TModel>(this TFormControl control, string help)
            where TFormControl : FormControl<TModel>
        {
            control.Help = help;
            return control;
        }

        public static TFormControl InputLg<TFormControl, TModel>(this TFormControl control, bool lg = true)
            where TFormControl : FormControl<TModel>
        {
            control.ToggleCssClass("input-lg", lg, "input-sm");
            return control;
        }

        public static TFormControl InputSm<TFormControl, TModel>(this TFormControl control, bool sm = true)
            where TFormControl : FormControl<TModel>
        {
            control.ToggleCssClass("input-sm", sm, "input-lg");
            return control;
        }

        // IFormValidation

        public static TComponent HasSuccess<TComponent, TModel>(this TComponent component, bool hasSuccess = true)
            where TComponent : Tag<TModel>, IFormValidation
        {
            component.ToggleCssClass("has-success", hasSuccess, "has-warning", "has-error");
            return component;
        }

        public static TComponent HasWarning<TComponent, TModel>(this TComponent component, bool hasSuccess = true)
            where TComponent : Tag<TModel>, IFormValidation
        {
            component.ToggleCssClass("has-warning", hasSuccess, "has-success", "has-error");
            return component;
        }

        public static TComponent HasError<TComponent, TModel>(this TComponent component, bool hasError = true)
            where TComponent : Tag<TModel>, IFormValidation
        {
            component.ToggleCssClass("has-error", hasError, "has-warning", "has-success");
            return component;
        }
    }
}
