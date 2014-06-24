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
    public interface IHiddenFor : IFormControl
    {
    }

    public class HiddenFor<TModel, TValue> : Component<TModel, HiddenFor<TModel, TValue>>, IHiddenFor
    {
        private readonly Expression<Func<TModel, TValue>> _expression;

        internal HiddenFor(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            : base(helper)
        {
            _expression = expression;
        }

        protected override void OnStart(TextWriter writer)
        {
            writer.Write(HtmlHelper.HiddenFor(_expression));
        }
    }
}
