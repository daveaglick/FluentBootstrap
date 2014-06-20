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
    public interface IEditorFor : IFormControlFor
    {
    }

    public class EditorFor<TModel, TValue> : FormControlFor<TModel, TValue, EditorFor<TModel, TValue>>, IEditorFor
    {
        internal EditorFor(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            : base(helper, expression)
        {
        }

        protected override void WriteTemplate(TextWriter writer)
        {
            writer.Write(HtmlHelper.EditorFor(Expression, TemplateName, AdditionalViewData));
        }
    }
}
