using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public class Content : Component
    {
        private readonly string _content;

        public Content(IComponentCreator creator, string content)
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
