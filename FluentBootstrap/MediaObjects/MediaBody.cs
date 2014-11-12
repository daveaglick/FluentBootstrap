using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaBodyCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class MediaBodyWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IMediaBody : ITag
    {
    }

    public class MediaBody<THelper> : Tag<THelper, MediaBody<THelper>, MediaBodyWrapper<THelper>>, IMediaBody, IHasTextContent
    {
        internal string Heading { get; set; }

        internal MediaBody(IComponentCreator<THelper> creator)
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
