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
    public interface IFormControlFor : IFormControl
    {
    }

    public abstract class FormControlFor<TModel, TValue, TThis> : FormControl<TModel, TThis>, IFormControlFor
        where TThis : FormControlFor<TModel, TValue, TThis>
    {
        protected Expression<Func<TModel, TValue>> Expression { get; private set; }
        internal bool AddDescription { get; set; }
        internal bool AddValidationMessage { get; set; }
        internal string TemplateName { get; set; }
        internal object AdditionalViewData { get; set; }

        internal FormControlFor(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            : base(helper, "div", "form-control-static")
        {
            Expression = expression;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            WriteTemplate(writer);

            // Add the validation message if requested
            if (AddValidationMessage)
            {
                writer.Write(HtmlHelper.ValidationMessageFor(Expression));
            }
        }

        protected abstract void WriteTemplate(TextWriter writer);

        protected override void OnFinish(TextWriter writer)
        {
            // Add the description text if requested
            if (AddDescription)
            {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(Expression, Helper.HtmlHelper.ViewData);
                if (!string.IsNullOrWhiteSpace(metadata.Description))
                {
                    new Tag<TModel>(Helper, "p", "help-block")
                        .AddChild(new Content<TModel>(Helper, metadata.Description))
                        .StartAndFinish(writer);
                }
            }

            base.OnFinish(writer);
        }
    }
}
