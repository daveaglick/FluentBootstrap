using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Icons
{
    public interface IIconSpanCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class IconSpanWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IIconSpan : ITag
    {
    }

    public class IconSpan<THelper> : Tag<THelper, IconSpan<THelper>, IconSpanWrapper<THelper>>, IIconSpan
    {
        internal IconSpan(IComponentCreator<THelper> creator, Icon icon)
            : base(creator, "span", Css.Glyphicon, icon.GetDescription())
        {
        }
    }
}
