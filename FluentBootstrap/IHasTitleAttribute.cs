using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public interface IHasTitleAttribute
    {
    }

    public static class TitleAttributeExtensions
    {
        public static ComponentBuilder<TTag> SetTitle<TTag>(this ComponentBuilder<TTag> builder, object title, string format = null)
            where TTag : Tag, IHasTitleAttribute
        {
            builder.Component.MergeAttribute("title", title == null ? null : builder.Helper.FormatValue(title, format));
            return builder;
        }
    }
}
