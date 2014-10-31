using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Misc
{
    public interface IJumbotronCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class JumbotronWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IJumbotron : ITag
    {
    }

    public class Jumbotron<TModel> : Tag<TModel, Jumbotron<TModel>, JumbotronWrapper<TModel>>, IJumbotron
    {
        internal Jumbotron(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Jumbotron)
        {
        }
    }
}
