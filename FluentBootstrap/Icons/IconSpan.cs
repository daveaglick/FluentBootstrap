using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Icons
{
    internal interface IIconSpan : ITag
    {
    }

    public class IconSpan<TModel> : Tag<TModel, IconSpan<TModel>>, IIconSpan
    {
        internal IconSpan(BootstrapHelper<TModel> helper, Icon icon)
            : base(helper, "span", Css.Glyphicon, icon.GetDescription())
        {
        }
    }
}
