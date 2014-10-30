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
        public static Badge<TModel> Badge<TModel>(this IBadgeCreator<TModel> creator, string text)
        {
            return new Badge<TModel>(creator).SetText(text);
        }
    }
}
