using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Forms
{
    public interface IDisplayFor : IFormControlFor
    {
    }

    public class DisplayFor<TModel, TValue> : FormControlFor<TModel, TValue, DisplayFor<TModel, TValue>>, IDisplayFor
    {        
        internal bool AddHidden { get; set; }

        internal DisplayFor(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            : base(helper, expression)
        {
        }

        protected override void WriteTemplate(TextWriter writer)
        {
            // Insert the hidden control if requested
            if (AddHidden)
            {
                new HiddenFor<TModel, TValue>(Helper, Expression).StartAndFinish(writer);
            }

            writer.Write(HtmlHelper.DisplayFor(Expression, TemplateName, AdditionalViewData));
        }
    }
}
