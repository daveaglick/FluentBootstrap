using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Images
{
    internal interface IImage : ITag
    {
    }

    public interface IImageCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Image<TModel> : Tag<TModel, Image<TModel>>, IImage
    {
        internal Image(BootstrapHelper<TModel> helper, params string[] cssClasses)
            : base(helper, "img", cssClasses)
        {
        }
    }
}
