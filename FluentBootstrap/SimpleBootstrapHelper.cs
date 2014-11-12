using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    // Instantiate this class to get a very simple BootstrapHelper that can be used for creating strings of Bootstrap HTML content
    public class SimpleBootstrapHelper : BootstrapHelper<SimpleBootstrapHelper>
    {
        public SimpleBootstrapHelper()
            : this(new StringWriter())
        {
        }

        public SimpleBootstrapHelper(TextWriter textWriter)
            : base(new SimpleOutputContext(textWriter))
        {
        }

        public override string ToString()
        {
            return OutputContext.ToString();
        }
    }
}
