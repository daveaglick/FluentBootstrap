using FluentBootstrap.Wells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class WellExtensions
    {
        public static Well<TModel> Well<TModel>(this IWellCreator<TModel> creator)
        {
            return new Well<TModel>(creator);
        }

        public static Well<TModel> SetSize<TModel>(this Well<TModel> well, WellSize size)
        {
            return well.ToggleCss(size);
        }
    }
}
