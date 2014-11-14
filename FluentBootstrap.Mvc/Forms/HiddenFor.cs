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
    public interface IHiddenForCreator<TModel> : IComponentCreator<MvcBootstrapHelper<TModel>>
    {
    }

    public class HiddenForWrapper<TModel> : ComponentWrapper<MvcBootstrapHelper<TModel>>
    {
    }

    internal interface IHiddenFor : IComponent
    {
    }

    public class HiddenFor<TModel, TValue> : Component<MvcBootstrapHelper<TModel>, HiddenFor<TModel, TValue>, HiddenForWrapper<TModel>>, IHiddenFor
    {
        private readonly Expression<Func<TModel, TValue>> _expression;

        internal HiddenFor(IComponentCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, TValue>> expression)
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
