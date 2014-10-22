using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class Bootstrap
    {
        // These keys have to be provided in a non-generic class, otherwise we'll end up with as many values as generic parameters
        internal readonly static object ComponentStackKey = new object();
        internal readonly static object OutputStackKey = new object();


        // Global settings
        public static int GridColumns = 12;
        public static bool PrettyPrint = true;
        public static int DefaultFormLabelWidth = 4;

        // This keeps track of the nesting level for tags for pretty printing
        internal static int TagIndent = 0;
        internal static ITag LastToWrite = null;
    }
}
