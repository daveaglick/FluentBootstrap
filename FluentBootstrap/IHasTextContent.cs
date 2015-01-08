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
        public static ComponentBuilder<THelper, TTag> SetText<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, string text)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasTextContent
        {
            builder.Component.TextContent = text;
            return builder;
        }
    }
}
