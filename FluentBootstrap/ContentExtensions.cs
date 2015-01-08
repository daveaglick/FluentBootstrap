using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public static class ContentExtensions
    {
        public static ComponentBuilder<Content> Content<TComponent>(this IComponentCreator<TComponent> creator, string content)
            where TComponent : Component, ICanCreate<Content>
        {
            return new ComponentBuilder<Content>(creator.Helper, new Content(creator, content));
        }
    }
}
