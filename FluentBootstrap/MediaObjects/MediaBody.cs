using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaBodyCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class MediaBodyWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IMediaBody : ITag
    {
    }

    public class MediaBody<TModel> : Tag<TModel, MediaBody<TModel>, MediaBodyWrapper<TModel>>, IMediaBody, IHasTextContent
    {
        internal string Heading { private get; set; }

        internal MediaBody(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.MediaBody)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if(!string.IsNullOrWhiteSpace(Heading))
            {
                Helper.Heading4(Heading).StartAndFinish(writer);
            }
        }
    }
}
