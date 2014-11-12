using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Forms
{
    public interface IHiddenForCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class HiddenForWrapper<THelper> : ComponentWrapper<THelper>
    {
    }

    internal interface IHiddenFor : IComponent
    {
    }

    public class HiddenFor<THelper, TValue> : Component<THelper, HiddenFor<THelper, TValue>, HiddenForWrapper<THelper>>, IHiddenFor
    {
        private readonly Expression<Func<THelper, TValue>> _expression;

        internal HiddenFor(IComponentCreator<THelper> creator, Expression<Func<THelper, TValue>> expression)
            : base(creator)
        {
            _expression = expression;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);
            writer.Write(HtmlHelper.HiddenFor(_expression));
        }
    }
}
