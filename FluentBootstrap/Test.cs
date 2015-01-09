using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class Test
    {
        public static void Testing()
        {
            SimpleBootstrapHelper helper = new SimpleBootstrapHelper();
            using(var row = helper.GridRow().Begin())
            {
                row.GridColumn(4);
            }
        }
    }
}
