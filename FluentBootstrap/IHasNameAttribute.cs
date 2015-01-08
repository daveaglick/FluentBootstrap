using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public interface IHasNameAttribute
    {
    }

    public static class NameAttributeExtensions
    {
        public static ComponentBuilder<TTag> SetName<TTag>(this ComponentBuilder<TTag> builder, string name)
            where TTag : Tag, IHasNameAttribute
        {
            builder.Component.MergeAttribute("name", name == null ? null : builder.Helper.GetFullHtmlFieldName(name));
            return builder;
        }
    }
}
