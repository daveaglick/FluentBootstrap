using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Misc
{
    public interface IJumbotronCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class JumbotronWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IJumbotron : ITag
    {
    }

    public class Jumbotron<THelper> : Tag<THelper, Jumbotron<THelper>, JumbotronWrapper<THelper>>, IJumbotron
    {
        internal Jumbotron(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Jumbotron)
        {
        }
    }
}
