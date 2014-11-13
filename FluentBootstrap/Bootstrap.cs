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
        // TODO: Consider moving these into BootstrapHelper (or some other location - maybe even get the values from web.config with reasonable defaults)
        public static int GridColumns = 12;
        public static bool PrettyPrint = true;
        public static int DefaultFormLabelWidth = 4;

        // This keeps track of the nesting level for tags for pretty printing
        // TODO: They need to not be static, otherwise we'll get messed up with multiple concurrent requests
        internal static int TagIndent = 0;
        internal static ITag LastToWrite = null;
    }
}
