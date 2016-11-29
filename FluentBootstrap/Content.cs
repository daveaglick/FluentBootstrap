using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    public class Content : Component
    {
        private readonly object _content;

        internal Content(BootstrapHelper helper, object content)
            : base(helper)
        {
            _content = content;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);
            IHtmlString htmlString = _content as IHtmlString;
            writer.Write(htmlString != null ? htmlString.ToHtmlString() : HttpUtility.HtmlEncode(_content));
        }
    }
}
