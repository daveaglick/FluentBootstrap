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
    public class HiddenFor<TModel, TValue> : Component
    {
        private readonly Expression<Func<TModel, TValue>> _expression;

        internal HiddenFor(IComponentCreator creator, Expression<Func<TModel, TValue>> expression)
            : base(creator)
        {
            _expression = expression;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);
            writer.Write(this.GetHelper<TModel>().HtmlHelper.HiddenFor(_expression));
        }
    }
}
