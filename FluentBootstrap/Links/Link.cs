using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Links
{
    public class Link<TModel> : Tag<TModel>, ILink, IHasTextAttribute
    {
        internal Link(BootstrapHelper<TModel> helper, params string[] cssClasses)
            : base(helper, "a", cssClasses)
        {
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
