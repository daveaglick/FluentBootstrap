using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Misc
{
    public interface IJumbotronCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class JumbotronWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IJumbotron : ITag
    {
    }

    public class Jumbotron<THelper> : Tag<THelper, Jumbotron<THelper>, JumbotronWrapper<THelper>>, IJumbotron
        where THelper : BootstrapHelper<THelper>
    {
        internal Jumbotron(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Jumbotron)
        {
        }
    }
}
