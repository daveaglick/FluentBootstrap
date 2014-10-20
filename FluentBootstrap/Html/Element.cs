using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    public interface IElementCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ElementWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IElement : ITag
    {
    }

    public class Element<TModel> : Tag<TModel, Element<TModel>, ElementWrapper<TModel>>, IElement, IHasTextAttribute
    {
        internal Element(IComponentCreator<TModel> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
        }
    }
}
