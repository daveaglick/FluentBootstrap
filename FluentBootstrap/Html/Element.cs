using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    public interface IElementCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class ElementWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IElement : ITag
    {
    }

    public class Element<THelper> : Tag<THelper, Element<THelper>, ElementWrapper<THelper>>, IElement, IHasTextContent
    {
        internal Element(IComponentCreator<THelper> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
        }
    }
}
