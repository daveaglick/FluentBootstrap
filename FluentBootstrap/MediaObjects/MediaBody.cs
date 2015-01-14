using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public class MediaBody : Tag, IHasTextContent
    {
        public string Heading { get; set; }

        internal MediaBody(BootstrapHelper helper)
            : base(helper, "div", Css.MediaBody)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if(!string.IsNullOrWhiteSpace(Heading))
            {
                GetHelper().Heading4(Heading).Component.StartAndFinish(writer);
            }
        }
    }
}
