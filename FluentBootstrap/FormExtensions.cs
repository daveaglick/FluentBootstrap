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

        public static Form Horizontal(this Form form, bool horizontal = true)
        {
            form.ToggleCssClass("form-horizontal", horizontal, "form-inline");
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

        // Inputs

        public static FormInput Text(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "text").Name(name).Value(value, format);
        }

        public static FormInput Text(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "text").Name(name).Value(value, format);
        }

        public static FormInput Password(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "password").Name(name).Value(value, format);
        }

        public static FormInput Password(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "password").Name(name).Value(value, format);
        }

        public static FormInput DateTime(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "datetime").Name(name).Value(value, format);
        }

        public static FormInput DateTime(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "datetime").Name(name).Value(value, format);
        }

        public static FormInput DateTimeLocal(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "datetime-local").Name(name).Value(value, format);
        }

        public static FormInput DateTimeLocal(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "datetime-local").Name(name).Value(value, format);
        }

        public static FormInput Date(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "date").Name(name).Value(value, format);
        }

        public static FormInput Date(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "date").Name(name).Value(value, format);
        }

        public static FormInput Month(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "month").Name(name).Value(value, format);
        }

        public static FormInput Month(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "month").Name(name).Value(value, format);
        }

        public static FormInput Time(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "time").Name(name).Value(value, format);
        }

        public static FormInput Time(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "time").Name(name).Value(value, format);
        }

        public static FormInput Week(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "week").Name(name).Value(value, format);
        }

        public static FormInput Week(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "week").Name(name).Value(value, format);
        }

        public static FormInput Number(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "number").Name(name).Value(value, format);
        }

        public static FormInput Number(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "number").Name(name).Value(value, format);
        }

        public static FormInput Email(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "email").Name(name).Value(value, format);
        }

        public static FormInput Email(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "email").Name(name).Value(value, format);
        }

        public static FormInput Url(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "url").Name(name).Value(value, format);
        }

        public static FormInput Url(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "url").Name(name).Value(value, format);
        }

        public static FormInput Search(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "search").Name(name).Value(value, format);
        }

        public static FormInput Search(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "search").Name(name).Value(value, format);
        }

        public static FormInput Tel(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "tel").Name(name).Value(value, format);
        }

        public static FormInput Tel(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "tel").Name(name).Value(value, format);
        }

        public static FormInput Color(this BootstrapHelper helper, string name = null, object value = null, string format = null)
        {
            return new FormInput(helper, "color").Name(name).Value(value, format);
        }

        public static FormInput Color(this ComponentWrapper<Form> form, string name = null, object value = null, string format = null)
        {
            return new FormInput(form.Component.Helper, "color").Name(name).Value(value, format);
        }

        // Input attributes

        public static TComponent Name<TComponent>(this TComponent component, string name)
            where TComponent : FormInput
        {
            component.MergeAttribute("name", name == null ? null : component.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return component;
        }

        public static TComponent Value<TComponent>(this TComponent component, object value, string format = null)
            where TComponent : FormInput
        {
            component.MergeAttribute("value", value == null ? null : component.HtmlHelper.FormatValue(value, format));
            return component;
        }
    }
}
