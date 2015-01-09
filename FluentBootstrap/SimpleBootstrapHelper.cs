using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    // Instantiate this class to get a very simple BootstrapHelper that can be used for creating strings of Bootstrap HTML content
    public class SimpleBootstrapHelper : BootstrapHelper<SimpleBootstrapConfig, CanCreate>
    {
        public SimpleBootstrapHelper() : base(new SimpleBootstrapConfig())
        {
        }
    }
}
