using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public interface IContentCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ContentWrapper<THelper> : ComponentWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IContent : IComponent
    {
    }

    public class Content<THelper> : Component<THelper, Content<THelper>, ContentWrapper<THelper>>, IContent
        where THelper : BootstrapHelper<THelper>
    {
        private readonly string _content;

        public Content(IComponentCreator<THelper> creator, string content)
            : base(creator)
        {
            _content = content;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);
            writer.Write(_content);
        }
    }
}
