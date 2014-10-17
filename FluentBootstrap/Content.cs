using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    internal interface IContent : IComponent
    {
    }

    public class Content<TModel> : Component<TModel, Content<TModel>, ComponentWrapper<TModel>>, IContent
    {
        private readonly string _content;

        public Content(IComponentCreator<TModel> creator, string content)
            : base(creator)
        {
            _content = content;
        }

        protected override void OnStart(TextWriter writer)
        {
            writer.Write(_content);
        }
    }
}
