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
    public interface IHiddenForCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class HiddenForWrapper<TModel> : ComponentWrapper<TModel>
    {
    }

    internal interface IHiddenFor : IComponent
    {
    }

    public class HiddenFor<TModel, TValue> : Component<TModel, HiddenFor<TModel, TValue>, HiddenForWrapper<TModel>>, IHiddenFor
    {
        private readonly Expression<Func<TModel, TValue>> _expression;

        internal HiddenFor(IComponentCreator<TModel> creator, Expression<Func<TModel, TValue>> expression)
            : base(creator)
        {
            _expression = expression;
        }

        protected override void OnStart(TextWriter writer)
        {
            writer.Write(HtmlHelper.HiddenFor(_expression));
        }
    }
}
