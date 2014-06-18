using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public class Content<TModel> : Component<TModel>
    {
        private readonly string _content;

        public Content(BootstrapHelper<TModel> helper, string content)
            : base(helper)
        {
            _content = content;
        }

        protected override void OnStart(TextWriter writer)
        {
            writer.Write(_content);
        }
    }
}
