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

        public static Pagination<THelper> Pagination<THelper>(this IPaginationCreator<THelper> creator)
        {
            return new Pagination<THelper>(creator);
        }

        public static Pagination<THelper> SetSize<THelper>(this Pagination<THelper> pagination, PaginationSize size)
        {
            pagination.ToggleCss(size);
            return pagination;
        }

        public static Pagination<THelper> AddPrevious<THelper>(this Pagination<THelper> pagination, string href = "#", bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&laquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<THelper> AddPrevious<THelper>(this Pagination<THelper> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&laquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<THelper> AddNext<THelper>(this Pagination<THelper> pagination, string href = "#", bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&raquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<THelper> AddNext<THelper>(this Pagination<THelper> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&raquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<THelper> AddPage<THelper>(this Pagination<THelper> pagination, string href = "#", bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum((++pagination.AutoPageNumber).ToString(), href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<THelper> AddPage<THelper>(this Pagination<THelper> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum((++pagination.AutoPageNumber).ToString(), actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        // PageNum

        public static PageNum<THelper> PageNum<THelper>(this IPageNumCreator<THelper> creator, string text, string href = "#")
        {
            return new PageNum<THelper>(creator).SetHref(href).SetText(text);
        }

        public static PageNum<THelper> PageNum<THelper>(this IPageNumCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new PageNum<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static PageNum<THelper> SetActive<THelper>(this PageNum<THelper> pageNum, bool active = true)
        {
            pageNum.Active = active;
            return pageNum;
        }

        public static PageNum<THelper> SetDisabled<THelper>(this PageNum<THelper> pageNum, bool disabled = true)
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }
    }
}
