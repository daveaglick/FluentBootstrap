using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using FluentBootstrap.Mvc;
using FluentBootstrap.Mvc.Internals;
using FluentBootstrap.Breadcrumbs;
using FluentBootstrap.Buttons;
using FluentBootstrap.Dropdowns;
using FluentBootstrap.Internals;
using FluentBootstrap.Links;
using FluentBootstrap.ListGroups;
using FluentBootstrap.MediaObjects;
using FluentBootstrap.Navbars;
using FluentBootstrap.Navs;
using FluentBootstrap.Pagers;
using FluentBootstrap.Paginations;
using FluentBootstrap.Thumbnails;
using FluentBootstrap.Forms;
using FluentBootstrap.Images;

namespace FluentBootstrap
{
    public static class T4MVCExtensions
    {
        // Link

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Link> Link<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<Link>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Link>(helper.GetConfig(), helper.Link(text, (string)null).GetComponent())
                .SetLinkAction(result)
                .SetText(text);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> SetLinkAction<TTag, TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> builder, ActionResult result)
            where TTag : Tag, IHasLinkExtensions
        {
            if (result != null)
            {
                IT4MVCActionResult callInfo = result.GetT4MVCResult();
                builder.SetHref(UrlHelper.GenerateUrl(null, callInfo.Action, callInfo.Controller, callInfo.Protocol, null, null, result.GetRouteValueDictionary(),
                    builder.GetConfig().GetHtmlHelper().RouteCollection, builder.GetConfig().GetHtmlHelper().ViewContext.RequestContext, true));
            }
            return builder;
        }

        // Breadcrumb

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Crumb> Crumb<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<Crumb>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Crumb>(helper.GetConfig(), helper.Crumb(text, (string)null).GetComponent())
                .SetLinkAction(result)
                .SetText(text);
        }

        // Button

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, LinkButton> LinkButton<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<LinkButton>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, LinkButton>(helper.GetConfig(), helper.LinkButton(text, (string)null).GetComponent())
                .SetLinkAction(result);
        }

        // Dropdown

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, DropdownLink> DropdownLink<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<DropdownLink>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, DropdownLink>(helper.GetConfig(), helper.DropdownLink(text, (string)null).GetComponent())
                .SetLinkAction(result)
                .SetText(text);
        }

        // ListGroup

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, ListGroupItem> ListGroupItem<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<ListGroupItem>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, ListGroupItem>(helper.GetConfig(), helper.ListGroupItem(text, (string)null).GetComponent())
                .SetLinkAction(result);
        }

        // MediaObject

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, MediaObject> MediaObject<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string src, ActionResult result, string alt = null)
            where TComponent : Component, ICanCreate<MediaObject>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, MediaObject>(helper.GetConfig(), helper.MediaObject(src, (string)null, alt).GetComponent())
                .SetLinkAction(result);
        }

        // Navbar

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Navbar> Navbar<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string brand, ActionResult result, bool fluid = true)
            where TComponent : Component, ICanCreate<Navbar>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Navbar>(helper.GetConfig(), helper.Navbar(fluid).GetComponent())
                .AddChild(x => x.Brand(brand, result));
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Brand> Brand<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<Brand>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Brand>(helper.GetConfig(), helper.Brand(text, (string)null).GetComponent())
                .SetLinkAction(result)
                .SetText(text);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, NavbarLink> NavbarLink<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<NavbarLink>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, NavbarLink>(helper.GetConfig(), helper.NavbarLink(text, (string)null).GetComponent())
                .SetLinkAction(result)
                .SetText(text);
        }

        // Nav

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pill> Pill<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<Pill>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Pill>(helper.GetConfig(), helper.Pill(text, (string)null).GetComponent())
                .SetLinkAction(result);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Tab> Tab<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<Tab>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Tab>(helper.GetConfig(), helper.Tab(text, (string)null).GetComponent())
                .SetLinkAction(result);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddPrevious<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, ActionResult result, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, result).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return builder;
        }

        // Pager

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddNext<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, ActionResult result, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, result).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddPage<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, ActionResult result, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, result).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Page> Page<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<Page>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Page>(helper.GetConfig(), helper.Page(text, (string)null).GetComponent())
                .SetLinkAction(result);
        }

        // Pagination

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> Pagination<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, IEnumerable<ActionResult> results, int? activePageNumber = null, int? firstPageNumber = null)
            where TComponent : Component, ICanCreate<Pagination>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination>(helper.GetConfig(), helper.Pagination().GetComponent())
                .AddPages(results, activePageNumber, firstPageNumber);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> Pagination<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, IEnumerable<KeyValuePair<string, ActionResult>> textAndResults, int? activePageNumber = null, int? firstPageNumber = null)
            where TComponent : Component, ICanCreate<Pagination>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination>(helper.GetConfig(), helper.Pagination().GetComponent())
                .AddPages(textAndResults, activePageNumber, firstPageNumber);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPrevious<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, ActionResult result, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum("&laquo;", result).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddNext<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, ActionResult result, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum("&raquo;", result).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPage<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, ActionResult result, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum((++builder.GetComponent().AutoPageNumber).ToString(), result).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPages<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, IEnumerable<ActionResult> results, int? activePageNumber = null, int? firstPageNumber = null)
        {
            return builder.AddPages(results.Select(x => new KeyValuePair<string, ActionResult>(null, x)), activePageNumber, firstPageNumber);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPages<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, IEnumerable<KeyValuePair<string, ActionResult>> textAndResults, int? activePageNumber = null, int? firstPageNumber = null)
        {
            if (firstPageNumber.HasValue)
            {
                builder.GetComponent().AutoPageNumber = firstPageNumber.Value - 1;
            }
            foreach (KeyValuePair<string, ActionResult> textAndResult in textAndResults)
            {
                KeyValuePair<string, ActionResult> localTextAndResult = textAndResult;  // avoid access in closure
                builder.GetComponent().AutoPageNumber++;
                builder.AddChild(x => x.PageNum(localTextAndResult.Key ?? builder.GetComponent().AutoPageNumber.ToString(), localTextAndResult.Value)
                    .SetActive(builder.GetComponent().AutoPageNumber == activePageNumber)
                    .SetDisabled(localTextAndResult.Value == null));
            }
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, PageNum> PageNum<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, ActionResult result)
            where TComponent : Component, ICanCreate<PageNum>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, PageNum>(helper.GetConfig(), helper.PageNum(text, (string)null).GetComponent())
                .SetLinkAction(result);
        }

        // Form

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Form> Form<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, ActionResult result, FormMethod method = FormMethod.Post)
            where TComponent : Component, ICanCreate<Form>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Form>(helper.GetConfig(), helper.Form().GetComponent())
                .SetAction(result)
                .SetFormMethod(method);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> SetAction<TModel, TForm>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TForm> builder, ActionResult result)
            where TForm : Form
        {
            IT4MVCActionResult callInfo = result.GetT4MVCResult();
            builder.SetAction(UrlHelper.GenerateUrl(null, callInfo.Action, callInfo.Controller, callInfo.Protocol, null, null, result.GetRouteValueDictionary(),
                builder.GetConfig().GetHtmlHelper().RouteCollection, builder.GetConfig().GetHtmlHelper().ViewContext.RequestContext, true));
            return builder;
        }
    }
}
