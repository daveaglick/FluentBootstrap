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
        public static ComponentBuilder<TConfig, TTag> SetTitle<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, object title, string format = null)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasTitleAttribute
        {
            builder.Component.MergeAttribute("title", title == null ? null : builder.Config.FormatValue(title, format));
            return builder;
        }
    }
}
