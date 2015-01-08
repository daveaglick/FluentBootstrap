using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public interface IHasValueAttribute
    {
    }

    public static class ValueAttributeExtensions
    {
        public static ComponentBuilder<TTag> SetValue<TTag>(this ComponentBuilder<TTag> builder, object value, string format = null)
            where TTag : Tag, IHasValueAttribute
        {
            builder.Component.MergeAttribute("value", value == null ? null : builder.Helper.FormatValue(value, format));
            return builder;
        }
    }
}
