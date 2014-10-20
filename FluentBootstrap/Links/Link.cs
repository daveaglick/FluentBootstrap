using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Links
{
    public interface ILinkCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class LinkWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface ILink : ITag
    {
    }

    public class Link<TModel> : Tag<TModel, Link<TModel>, LinkWrapper<TModel>>, ILink, IHasIconExtensions, IHasLinkExtensions, IHasTextAttribute
    {
        internal Link(IComponentCreator<TModel> creator, params string[] cssClasses)
            : base(creator, "a", cssClasses)
        {
        }
    }
}
