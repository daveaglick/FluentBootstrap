using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class Bootstrap
    {
        // Global settings
        // TODO: Get these from web.config (or other .config) within BootstrapHelper and provide ability to override and defaults if not in config
        public static int GridColumns = 12;
        public static bool PrettyPrint = true;
        public static int DefaultFormLabelWidth = 4;
    }
}
