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
        public static ComponentBuilder<TTag> SetDisabled<TTag>(this ComponentBuilder<TTag> builder, bool disabled = true)
            where TTag : Tag, IHasDisabledAttribute
        {
            builder.Component.MergeAttribute("disabled", disabled ? "disabled" : null);
            return builder;
        }
    }
}
