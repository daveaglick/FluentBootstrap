using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using FluentBootstrap.Breadcrumbs;
using FluentBootstrap.Buttons;
using FluentBootstrap.Dropdowns;
using FluentBootstrap.Images;
using FluentBootstrap.Internals;
using FluentBootstrap.Links;
using FluentBootstrap.ListGroups;
using FluentBootstrap.MediaObjects;
using FluentBootstrap.Mvc;
using FluentBootstrap.Navbars;
using FluentBootstrap.Navs;
using FluentBootstrap.Pagers;
using FluentBootstrap.Paginations;
using FluentBootstrap.Thumbnails;

namespace FluentBootstrap
{
    public static class MvcExtensions
    {
        // Tag

        public static ComponentBuilder<TConfig, TTag> AddHtml<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, Func<dynamic, HelperResult> content)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.GetComponent().AddChild(builder.GetHelper().Content(content(null).ToHtmlString()).GetComponent());
            return builder;
        }

        // Link

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Link> Link<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Link>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Link>(helper.GetConfig(), helper.Link(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> SetAction<TTag, TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> builder, string actionName, string controllerName, object routeValues = null)
            where TTag : Tag, IHasLinkExtensions
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            builder.SetHref(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                builder.GetConfig().HtmlHelper.RouteCollection, builder.GetConfig().HtmlHelper.ViewContext.RequestContext, true));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> SetRoute<TTag, TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> builder, string routeName, object routeValues = null)
            where TTag : Tag, IHasLinkExtensions
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            builder.SetHref(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                builder.GetConfig().HtmlHelper.RouteCollection, builder.GetConfig().HtmlHelper.ViewContext.RequestContext, false));
            return builder;
        }

        // Breadcrumb

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Crumb> Crumb<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Crumb>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Crumb>(helper.GetConfig(), helper.Crumb(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }

        // Button

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, LinkButton> LinkButton<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<LinkButton>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, LinkButton>(helper.GetConfig(), helper.LinkButton(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        // Dropdown

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, DropdownLink> DropdownLink<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<DropdownLink>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, DropdownLink>(helper.GetConfig(), helper.DropdownLink(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }

        // ListGroup

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, ListGroupItem> ListGroupItem<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<ListGroupItem>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, ListGroupItem>(helper.GetConfig(), helper.ListGroupItem(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        // MediaObject

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, MediaObject> MediaObject<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
            where TComponent : Component, ICanCreate<MediaObject>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, MediaObject>(helper.GetConfig(), helper.MediaObject(src, null, alt).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        // Navbar

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Navbar> Navbar<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string brand, string actionName, string controllerName, object routeValues = null, bool fluid = true)
            where TComponent : Component, ICanCreate<Navbar>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Navbar>(helper.GetConfig(), helper.Navbar(fluid).GetComponent())
                .AddChild(x => x.Brand(brand, actionName, controllerName, routeValues));
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Brand> Brand<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Brand>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Brand>(helper.GetConfig(), helper.Brand(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, NavbarLink> NavbarLink<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<NavbarLink>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, NavbarLink>(helper.GetConfig(), helper.NavbarLink(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }

        // Nav

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pill> Pill<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Pill>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Pill>(helper.GetConfig(), helper.Pill(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Tab> Tab<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Tab>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Tab>(helper.GetConfig(), helper.Tab(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddPrevious<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return builder;
        }

        // Pager

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddNext<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddPage<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, actionName, controllerName, routeValues).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Page> Page<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Page>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Page>(helper.GetConfig(), helper.Page(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        // Pagination

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPrevious<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum("&laquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddNext<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum("&raquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPage<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum((++builder.GetComponent().AutoPageNumber).ToString(), actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, PageNum> PageNum<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<PageNum>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, PageNum>(helper.GetConfig(), helper.PageNum(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        // Typography

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Typography.List> ListFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper,
            Expression<Func<TModel, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
            where TComponent : Component, ICanCreate<Typography.List>
        {
            ComponentBuilder<MvcBootstrapConfig<TModel>, Typography.List> builder =
                new ComponentBuilder<MvcBootstrapConfig<TModel>, Typography.List>(helper.GetConfig(), helper.List(listType).GetComponent());
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(expression, builder.GetConfig().HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    builder.AddChild(x => x.ListItem(item(value)));
                }
            }
            return builder;
        }
    }
}
