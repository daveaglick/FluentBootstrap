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
    }
}
