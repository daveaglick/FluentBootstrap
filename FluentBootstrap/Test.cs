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
            using(var alert = helper.Alert(AlertState.Danger).Begin())
            {
            }
        }
    }
}
