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

        public static Form Form(this BootstrapHelper helper, FormMethod method = FormMethod.Post)
        {
            return new Form(helper).Action(null).Method(method);
        }

        public static Form Form(this BootstrapHelper helper, string action, FormMethod method = FormMethod.Post)
        {
            return new Form(helper).Action(action).Method(method);
        }

        public static Form Form(this BootstrapHelper helper, string actionName, string controllerName, FormMethod method = FormMethod.Post)
        {
            return new Form(helper).Action(actionName, controllerName).Method(method);
        }

        public static Form Inline(this Form form, bool inline = true)
        {
            form.ToggleCssClass("form-inline", inline, "form-horizontal");
            return form;
        }

        public static Form Horizontal(this Form form, int? defaultLabelWidth = 2, bool horizontal = true)
        {
            form.ToggleCssClass("form-horizontal", horizontal, "form-inline");
            form.DefaultLabelWidth = defaultLabelWidth;
            return form;
        }

        // Use action = null to reset form action to current request url
        public static Form Action(this Form form, string action)
        {
            form.MergeAttribute("action", action == null ? form.ViewContext.HttpContext.Request.RawUrl : action);
            return form;
        }

        public static Form Action(this Form form, string actionName, string controllerName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if(routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            form.MergeAttribute("action", UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary, 
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, true));
            return form;
        }

        public static Form Route(this Form form, string routeName, object routeValues = null)
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            form.MergeAttribute("action", UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                form.HtmlHelper.RouteCollection, form.ViewContext.RequestContext, false));
            return form;
        }

        public static Form Method(this Form form, FormMethod method)
        {
            form.MergeAttribute("method", HtmlHelper.GetFormMethodString(method));
            return form;
        }

        // Form Group

        public static FormGroup FormGroup(this BootstrapHelper helper)
        {
            return new FormGroup(helper);
        }

        public static FormGroup FormGroup(this ComponentWrapper<Form> form)
        {
            return new FormGroup(form.Component.Helper);
        }

        // Label

        public static Label FormLabel(this BootstrapHelper helper, string label)
        {
            return new Label(helper, label);
        }

        public static Label Label(this ComponentWrapper<Form> form, string label)
        {
            return new Label(form.Component.Helper, label);
        }

        public static Label Label(this ComponentWrapper<FormGroup> formGroup, string label)
        {
            return new Label(formGroup.Component.Helper, label);
        }

        public static Label For(this Label label, string @for)
        {
            label.MergeAttribute("for", @for);
            return label;
        }

        public static Label ScreenReaderOnly(this Label label, bool screenReaderOnly = true)
        {
            label.ToggleCssClass("sr-only", screenReaderOnly);
            return label;
        }

        // Input

        public static Input FormInput(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input(helper, inputType.GetDescription()).Name(name).Label(label).Value(value, format);
        }

        public static Input Input(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input(form.Component.Helper, inputType.GetDescription()).Name(name).Label(label).Value(value, format);
        }

        public static Input Input(this ComponentWrapper<FormGroup> formGroup, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
        {
            return new Input(formGroup.Component.Helper, inputType.GetDescription()).Name(name).Label(label).Value(value, format);
        }

        public static Input Value(this Input input, object value, string format = null)
        {
            input.MergeAttribute("value", value == null ? null : input.HtmlHelper.FormatValue(value, format));
            return input;
        }

        public static Input Placeholder(this Input input, string placeholder)
        {
            input.MergeAttribute("placeholder", placeholder);
            return input;
        }

        // TextArea

        public static TextArea FormTextArea(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null, int? rows = null)
        {
            return new TextArea(helper).Name(name).Label(label).Value(value, format).Rows(rows);
        }

        public static TextArea TextArea(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null, int? rows = null)
        {
            return new TextArea(form.Component.Helper).Name(name).Label(label).Value(value, format).Rows(rows);
        }

        public static TextArea TextArea(this ComponentWrapper<FormGroup> formGroup, string name = null, string label = null, object value = null, string format = null, int? rows = null)
        {
            return new TextArea(formGroup.Component.Helper).Name(name).Label(label).Value(value, format).Rows(rows);
        }

        public static TextArea Rows(this TextArea textArea, int? rows)
        {
            textArea.MergeAttribute("rows", rows == null ? null : rows.Value.ToString());
            return textArea;
        }

        public static TextArea Value(this TextArea textArea, object value, string format = null)
        {
            textArea.Value = value == null ? null : textArea.HtmlHelper.FormatValue(value, format);
            return textArea;
        }

        public static TextArea Placeholder(this TextArea textArea, string placeholder)
        {
            textArea.MergeAttribute("placeholder", placeholder);
            return textArea;
        }

        // CheckBox

        public static CheckBox FormCheckBox(this BootstrapHelper helper, string name = null, string label = null, string description = null, bool isChecked = false)
        {
            return new CheckBox(helper).Name(name).Label(label).Description(description).IsChecked(isChecked);
        }

        public static CheckBox CheckBox(this ComponentWrapper<Form> form, string name = null, string label = null, string description = null, bool isChecked = false)
        {
            return new CheckBox(form.Component.Helper).Name(name).Label(label).Description(description).IsChecked(isChecked);
        }

        public static CheckBox CheckBox(this ComponentWrapper<FormGroup> formGroup, string name = null, string label = null, string description = null, bool isChecked = false)
        {
            return new CheckBox(formGroup.Component.Helper).Name(name).Label(label).Description(description).IsChecked(isChecked);
        }

        public static CheckBox Description(this CheckBox checkBox, string description)
        {
            checkBox.Description = description;
            return checkBox;
        }

        public static CheckBox Inline(this CheckBox checkBox, bool inline = true)
        {
            checkBox.Inline = inline;
            return checkBox;
        }

        public static CheckBox IsChecked(this CheckBox checkBox, bool isChecked = true)
        {
            checkBox.MergeAttribute("checked", isChecked ? "checked" : null);
            return checkBox;
        }

        public static CheckBox Value(this CheckBox checkBox, string value)
        {
            checkBox.MergeAttribute("value", value);
            return checkBox;
        }

        // FormControl
        
        public static TFormControl Name<TFormControl>(this TFormControl control, string name)
            where TFormControl : FormControl
        {
            control.MergeAttribute("name", name == null ? null : control.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return control;
        }

        public static TFormControl Label<TFormControl>(this TFormControl control, string label, Action<Label> labelAction = null)
            where TFormControl : FormControl
        {
            if(label != null)
            {
                control.Label = new Label(control.Helper, label);
                if (labelAction != null)
                {
                    labelAction(control.Label);
                }
            }
            return control;
        }
    }
}
