using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Icons
{
    public interface IIconSpanCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class IconSpanWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IIconSpan : ITag
    {
    }

    public class IconSpan<THelper> : Tag<THelper, IconSpan<THelper>, IconSpanWrapper<THelper>>, IIconSpan
        where THelper : BootstrapHelper<THelper>
    {
        internal IconSpan(IComponentCreator<THelper> creator, Icon icon)
            : base(creator, "span", Css.Glyphicon, icon.GetDescription())
        {
        }
    }
}
