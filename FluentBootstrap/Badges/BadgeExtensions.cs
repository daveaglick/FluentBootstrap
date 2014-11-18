using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class BadgeExtensions
    {
        public static Badge<THelper> Badge<THelper>(this IBadgeCreator<THelper> creator, string text)
            where THelper : BootstrapHelper<THelper>
        {
            return new Badge<THelper>(creator).SetText(text);
        }
    }
}
