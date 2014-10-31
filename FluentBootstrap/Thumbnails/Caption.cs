using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public interface ICaptionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class CaptionWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface ICaption : ITag
    {
    }

    public class Caption<TModel> : Tag<TModel, Caption<TModel>, CaptionWrapper<TModel>>, ICaption
    {
        internal Caption(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Caption)
        {
        }
    }
}
