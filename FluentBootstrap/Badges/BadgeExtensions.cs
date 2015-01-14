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
        public static ComponentBuilder<TConfig, Badge> Badge<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Badge>
        {
            return new ComponentBuilder<TConfig, Badge>(helper.Config, new Badge(helper)).SetText(text);
        }
    }
}
