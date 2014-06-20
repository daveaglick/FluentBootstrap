using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class Bootstrap
    {
        // This key has to be provided in a non-generic class, otherwise we'll end up with as many stacks as generic parameters
        internal readonly static object ComponentStackKey = new object();

        public static int GridColumns = 12;
        public static bool PrettyPrint = true;

        // This keeps track of the nesting level for tags for pretty printing
        internal static int TagIndent = 0;
        internal static ITag LastToWrite = null;
        internal static bool JustWroteNewLine = false;
    }
}
