using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Mvc.Forms
{
    public interface IHiddenForCreator<TModel, THelper> : IComponentCreator<THelper>
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
    }

    public class HiddenForWrapper<TModel, THelper> : ComponentWrapper<THelper>
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
    }

    internal interface IHiddenFor : IComponent
    {
    }

    public class HiddenFor<TModel, THelper, TValue> : Component<THelper, HiddenFor<TModel, THelper, TValue>, HiddenForWrapper<TModel, THelper>>, IHiddenFor
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
        private readonly Expression<Func<TModel, TValue>> _expression;

        internal HiddenFor(IComponentCreator<THelper> creator, Expression<Func<TModel, TValue>> expression)
            : base(creator)
        {
            _expression = expression;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);
            writer.Write(Helper.HtmlHelper.HiddenFor(_expression));
        }
    }
}
