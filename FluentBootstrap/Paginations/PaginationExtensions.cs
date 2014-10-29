using FluentBootstrap.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class PaginationExtensions
    {
        // Pagination

        public static Pagination<TModel> Pagination<TModel>(this IPaginationCreator<TModel> creator, params string[] hrefs)
        {
            return new Pagination<TModel>(creator);
        }

        public static Pagination<TModel> SetSize<TModel>(this Pagination<TModel> pagination, PaginationSize size)
        {
            pagination.ToggleCss(size);
            return pagination;
        }

        public static Pagination<TModel> AddPrevious<TModel>(this Pagination<TModel> pagination, string href = "#", bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&laquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<TModel> AddPrevious<TModel>(this Pagination<TModel> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&laquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<TModel> AddNext<TModel>(this Pagination<TModel> pagination, string href = "#", bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&raquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<TModel> AddNext<TModel>(this Pagination<TModel> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&raquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<TModel> AddPage<TModel>(this Pagination<TModel> pagination, string href = "#", bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum((++pagination.AutoPageNumber).ToString(), href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<TModel> AddPage<TModel>(this Pagination<TModel> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum((++pagination.AutoPageNumber).ToString(), actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        // PageNum

        public static PageNum<TModel> PageNum<TModel>(this IPageNumCreator<TModel> creator, string text, string href = "#")
        {
            return new PageNum<TModel>(creator).SetHref(href).SetText(text);
        }

        public static PageNum<TModel> PageNum<TModel>(this IPageNumCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new PageNum<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static PageNum<TModel> SetActive<TModel>(this PageNum<TModel> pageNum, bool active = true)
        {
            pageNum.Active = active;
            return pageNum;
        }

        public static PageNum<TModel> SetDisabled<TModel>(this PageNum<TModel> pageNum, bool disabled = true)
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }
    }
}
