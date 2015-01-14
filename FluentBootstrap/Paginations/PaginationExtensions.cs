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

        public static Pagination<TConfig> Pagination<TConfig>(this IPaginationCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Pagination<TConfig>(creator);
        }

        public static Pagination<TConfig> SetSize<TConfig>(this Pagination<TConfig> pagination, PaginationSize size)
            where TConfig : BootstrapConfig
        {
            pagination.ToggleCss(size);
            return pagination;
        }

        public static Pagination<TConfig> AddPrevious<TConfig>(this Pagination<TConfig> pagination, string href = "#", bool active = false, bool disabled = false)
            where TConfig : BootstrapConfig
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&laquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<TConfig> AddNext<TConfig>(this Pagination<TConfig> pagination, string href = "#", bool active = false, bool disabled = false)
            where TConfig : BootstrapConfig
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&raquo;", href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<TConfig> AddPage<TConfig>(this Pagination<TConfig> pagination, string href = "#", bool active = false, bool disabled = false)
            where TConfig : BootstrapConfig
        {
            pagination.AddChild(pagination.GetWrapper().PageNum((++pagination.AutoPageNumber).ToString(), href).SetActive(active).SetDisabled(disabled));
            return pagination;
        }
        
        // PageNum

        public static PageNum<TConfig> PageNum<TConfig>(this IPageNumCreator<TConfig> creator, string text, string href = "#")
            where TConfig : BootstrapConfig
        {
            return new PageNum<TConfig>(creator).SetHref(href).SetText(text);
        }

        public static PageNum<TConfig> SetActive<TConfig>(this PageNum<TConfig> pageNum, bool active = true)
            where TConfig : BootstrapConfig
        {
            pageNum.Active = active;
            return pageNum;
        }

        public static PageNum<TConfig> SetDisabled<TConfig>(this PageNum<TConfig> pageNum, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }
    }
}
