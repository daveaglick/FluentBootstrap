using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public class Content : Component
    {
        private readonly string _content;

        public Content(BootstrapHelper helper, string content)
            : base(helper)
        {
            _content = content;
        }

        protected override string OnStart()
        {
            return _content;
        }
    }
}
