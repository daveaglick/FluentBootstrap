using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public interface ICaptionCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class CaptionWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ICaption : ITag
    {
    }

    public class Caption<THelper> : Tag<THelper, Caption<THelper>, CaptionWrapper<THelper>>, ICaption
        where THelper : BootstrapHelper<THelper>
    {
        internal Caption(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Caption)
        {
        }
    }
}
