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
        public static Well<TConfig> Well<TConfig>(this IWellCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Well<TConfig>(creator);
        }

        public static Well<TConfig> SetSize<TConfig>(this Well<TConfig> well, WellSize size)
            where TConfig : BootstrapConfig
        {
            return well.ToggleCss(size);
        }
    }
}
