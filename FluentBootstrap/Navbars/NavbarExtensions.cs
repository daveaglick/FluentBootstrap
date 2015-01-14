using FluentBootstrap.Navbars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class NavbarExtensions
    {
        // Navbar

        public static ComponentBuilder<TConfig, Navbar> Navbar<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, bool fluid = true)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Navbar>
        {
            return new ComponentBuilder<TConfig, Navbar>(helper.Config, new Navbar(helper))
                .SetFluid(fluid);
        }

        public static ComponentBuilder<TConfig, Navbar> Navbar<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string brand, string href = "/", bool fluid = true)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Navbar>
        {
            return new ComponentBuilder<TConfig, Navbar>(helper.Config, new Navbar(helper))
                .SetFluid(fluid)
                .AddChild(x => x.Brand(brand, href));
        }

        public static ComponentBuilder<TConfig, Navbar> SetFluid<TConfig>(this ComponentBuilder<TConfig, Navbar> builder, bool fluid = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Fluid = fluid;
            return builder;
        }

        public static ComponentBuilder<TConfig, Navbar> SetPosition<TConfig>(this ComponentBuilder<TConfig, Navbar> builder, NavbarPosition position)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(position);
            return builder;
        }

        public static ComponentBuilder<TConfig, Navbar> SetInverse<TConfig>(this ComponentBuilder<TConfig, Navbar> builder, bool inverse = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.NavbarInverse, inverse);
            return builder;
        }

        // NavbarHeader

        public static ComponentBuilder<TConfig, NavbarHeader> NavbarHeader<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarHeader>
        {
            return new ComponentBuilder<TConfig, NavbarHeader>(helper.Config, new NavbarHeader(helper));
        }

        // NavbarToggle

        public static ComponentBuilder<TConfig, NavbarToggle> NavbarToggle<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarToggle>
        {
            return new ComponentBuilder<TConfig, NavbarToggle>(helper.Config, new NavbarToggle(helper));
        }

        public static ComponentBuilder<TConfig, NavbarToggle> SetDataTarget<TConfig>(this ComponentBuilder<TConfig, NavbarToggle> builder, string dataTarget)
            where TConfig : BootstrapConfig
        {
            builder.Component.DataTarget = dataTarget;
            return builder;
        }

        public static ComponentBuilder<TConfig, NavbarToggle> SetHamburger<TConfig>(this ComponentBuilder<TConfig, NavbarToggle> builder, bool hamburger = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Hamburger = hamburger;
            return builder;
        }

        // Brand

        public static ComponentBuilder<TConfig, Brand> Brand<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Brand>
        {
            return new ComponentBuilder<TConfig, Brand>(helper.Config, new Brand(helper))
                .SetHref(href)
                .SetText(text);
        }

        // NavbarCollapse

        public static ComponentBuilder<TConfig, NavbarCollapse> NavbarCollapse<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarCollapse>
        {
            return new ComponentBuilder<TConfig, NavbarCollapse>(helper.Config, new NavbarCollapse(helper));
        }

        // NavbarNav

        public static ComponentBuilder<TConfig, NavbarNav> NavbarNav<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarNav>
        {
            return new ComponentBuilder<TConfig, NavbarNav>(helper.Config, new NavbarNav(helper));
        }

        // NavbarForm

        public static ComponentBuilder<TConfig, NavbarForm> NavbarForm<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarForm>
        {
            return new ComponentBuilder<TConfig, NavbarForm>(helper.Config, new NavbarForm(helper));
        }

        // NavbarButton

        public static ComponentBuilder<TConfig, NavbarButton> NavbarButton<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null, object value = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarButton>
        {
            return new ComponentBuilder<TConfig, NavbarButton>(helper.Config, new NavbarButton(helper))
                .SetText(text)
                .SetValue(value);
        }

        // NavbarText

        public static ComponentBuilder<TConfig, NavbarText> NavbarText<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarText>
        {
            return new ComponentBuilder<TConfig, NavbarText>(helper.Config, new NavbarText(helper))
                .SetText(text);
        }        
        
        // NavbarLink

        public static ComponentBuilder<TConfig, NavbarLink> NavbarLink<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<NavbarLink>
        {
            return new ComponentBuilder<TConfig, NavbarLink>(helper.Config, new NavbarLink(helper))
                .SetHref(href)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, NavbarLink> SetActive<TConfig>(this ComponentBuilder<TConfig, NavbarLink> builder, bool active = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Active = active;
            return builder;
        }

        public static ComponentBuilder<TConfig, NavbarLink> SetDisabled<TConfig>(this ComponentBuilder<TConfig, NavbarLink> builder, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Disabled = disabled;
            return builder;
        }

        // INavbarComponent

        public static ComponentBuilder<TConfig, TTag> SetLeft<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, bool left = true)
            where TConfig : BootstrapConfig
            where TTag : Tag, INavbarComponent
        {
            builder.Component.ToggleCss(Css.NavbarLeft, left, Css.NavbarRight);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetRight<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, bool right = true)
            where TConfig : BootstrapConfig
            where TTag : Tag, INavbarComponent
        {
            builder.Component.ToggleCss(Css.NavbarRight, right, Css.NavbarLeft);
            return builder;
        }
    }
}
