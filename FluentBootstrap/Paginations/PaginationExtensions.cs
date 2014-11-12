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
            where THelper : BootstrapHelper<THelper>
        {
            return new Pagination<THelper>(creator);
        }

        public static Pagination<THelper> SetSize<THelper>(this Pagination<THelper> pagination, PaginationSize size)
            where THelper : BootstrapHelper<THelper>
        {
            pagination.ToggleCss(size);
            return pagination;
        }

        public static Pagination<THelper> AddPrevious<THelper>(this Pagination<THelper> pagination, string href = "#", bool active = false, bool disabled = false)
            where THelper : BootstrapHelper<THelper>
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&laquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<THelper> AddNext<THelper>(this Pagination<THelper> pagination, string href = "#", bool active = false, bool disabled = false)
            where THelper : BootstrapHelper<THelper>
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&raquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<THelper> AddPage<THelper>(this Pagination<THelper> pagination, string href = "#", bool active = false, bool disabled = false)
            where THelper : BootstrapHelper<THelper>
        {
            pagination.AddChild(pagination.GetWrapper().PageNum((++pagination.AutoPageNumber).ToString(), href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }
        
        // PageNum

        public static PageNum<THelper> PageNum<THelper>(this IPageNumCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new PageNum<THelper>(creator).SetHref(href).SetText(text);
        }

        public static PageNum<THelper> SetActive<THelper>(this PageNum<THelper> pageNum, bool active = true)
            where THelper : BootstrapHelper<THelper>
        {
            pageNum.Active = active;
            return pageNum;
        }

        public static PageNum<THelper> SetDisabled<THelper>(this PageNum<THelper> pageNum, bool disabled = true)
            where THelper : BootstrapHelper<THelper>
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }
    }
}
