using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Icons
{
    public interface IIconSpanCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class IconSpanWrapper<TModel> : TagWrapper<TModel>
    {
    }
    internal interface IIconSpan : ITag
    {
    }

    public class IconSpan<TModel> : Tag<TModel, IconSpan<TModel>, IconSpanWrapper<TModel>>, IIconSpan
    {
        internal IconSpan(IComponentCreator<TModel> creator, Icon icon)
            : base(creator, "span", Css.Glyphicon, icon.GetDescription())
        {
        }
    }
}
