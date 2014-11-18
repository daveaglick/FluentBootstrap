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
        public static Well<THelper> Well<THelper>(this IWellCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Well<THelper>(creator);
        }

        public static Well<THelper> SetSize<THelper>(this Well<THelper> well, WellSize size)
            where THelper : BootstrapHelper<THelper>
        {
            return well.ToggleCss(size);
        }
    }
}
