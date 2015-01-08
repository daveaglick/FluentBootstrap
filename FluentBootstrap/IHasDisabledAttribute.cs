using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public interface IHasDisabledAttribute
    {
    }

    public static class DisabledAttributeExtensions
    {
        public static ComponentBuilder<THelper, TTag> SetDisabled<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, bool disabled = true)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasDisabledAttribute
        {
            builder.Component.MergeAttribute("disabled", disabled ? "disabled" : null);
            return builder;
        }
    }
}
