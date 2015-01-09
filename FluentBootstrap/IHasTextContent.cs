using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public interface IHasTextContent
    {
    }

    public static class TextContentExtensions
    {
        public static ComponentBuilder<TConfig, TTag> SetText<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, string text)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasTextContent
        {
            builder.Component.TextContent = text;
            return builder;
        }
    }
}
