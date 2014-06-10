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

        public static Label SrOnly(this Label label, bool srOnly = true)
        {
            label.ToggleCssClass("sr-only", srOnly);
            return label;
        }

        // Inputs

        public static Input FormText(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "text").Name(name).Label(label).Value(value, format);
        }

        public static Input Text(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "text").Name(name).Label(label).Value(value, format);
        }

        public static Input FormPassword(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "password").Name(name).Label(label).Value(value, format);
        }

        public static Input Password(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "password").Name(name).Label(label).Value(value, format);
        }

        public static Input FormDateTime(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "datetime").Name(name).Label(label).Value(value, format);
        }

        public static Input DateTime(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "datetime").Name(name).Label(label).Value(value, format);
        }

        public static Input FormDateTimeLocal(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "datetime-local").Name(name).Label(label).Value(value, format);
        }

        public static Input DateTimeLocal(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "datetime-local").Name(name).Label(label).Value(value, format);
        }

        public static Input FormDate(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "date").Name(name).Label(label).Value(value, format);
        }

        public static Input Date(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "date").Name(name).Label(label).Value(value, format);
        }

        public static Input FormMonth(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "month").Name(name).Label(label).Value(value, format);
        }

        public static Input Month(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "month").Name(name).Label(label).Value(value, format);
        }

        public static Input FormTime(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "time").Name(name).Label(label).Value(value, format);
        }

        public static Input Time(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "time").Name(name).Label(label).Value(value, format);
        }

        public static Input FormWeek(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "week").Name(name).Label(label).Value(value, format);
        }

        public static Input Week(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "week").Name(name).Label(label).Value(value, format);
        }

        public static Input FormNumber(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "number").Name(name).Label(label).Value(value, format);
        }

        public static Input Number(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "number").Name(name).Label(label).Value(value, format);
        }

        public static Input FormEmail(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "email").Name(name).Label(label).Value(value, format);
        }

        public static Input Email(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "email").Name(name).Label(label).Value(value, format);
        }

        public static Input FormUrl(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "url").Name(name).Label(label).Value(value, format);
        }

        public static Input Url(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "url").Name(name).Label(label).Value(value, format);
        }

        public static Input FormSearch(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "search").Name(name).Label(label).Value(value, format);
        }

        public static Input Search(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "search").Name(name).Label(label).Value(value, format);
        }

        public static Input FormTel(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "tel").Name(name).Label(label).Value(value, format);
        }

        public static Input Tel(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "tel").Name(name).Label(label).Value(value, format);
        }

        public static Input FormColor(this BootstrapHelper helper, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(helper, "color").Name(name).Label(label).Value(value, format);
        }

        public static Input Color(this ComponentWrapper<Form> form, string name = null, string label = null, object value = null, string format = null)
        {
            return new Input(form.Component.Helper, "color").Name(name).Label(label).Value(value, format);
        }

        // Input attributes

        public static Input Name(this Input input, string name)
        {
            input.MergeAttribute("name", name == null ? null : input.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return input;
        }

        public static Input Label(this Input input, string label, Action<Label> labelAction = null)
        {
            if(label != null)
            {
                input.Label = new Label(input.Helper, label);
                if (labelAction != null)
                {
                    labelAction(input.Label);
                }
            }
            return input;
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

        public static Input SuppressFormGroup(this Input input, bool suppress = true)
        {
            input.SuppressFormGroup = suppress;
            return input;
        }
    }
}
