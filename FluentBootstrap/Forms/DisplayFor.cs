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
    public interface IDisplayFor : IFormControl
    {
    }

    public class DisplayFor<TModel, TValue> : FormControl<TModel, DisplayFor<TModel, TValue>>, IDisplayFor
    {
        private readonly Expression<Func<TModel, TValue>> _expression;
        
        internal bool AddHidden { get; set; }
        internal bool AddDescription { get; set; }
        internal bool AddValidationMessage { get; set; }
        internal string TemplateName { get; set; }
        internal object AdditionalViewData { get; set; }

        internal DisplayFor(BootstrapHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            : base(helper, "div", "form-control-static")
        {
            _expression = expression;
        }

        protected override void Prepare(TextWriter writer)
        {
            // Insert the hidden control if requested
            if (AddHidden)
            {
                new HiddenFor<TModel, TValue>(Helper, _expression).StartAndFinish(writer);
            }

            base.Prepare(writer);
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            writer.Write(HtmlHelper.DisplayFor(_expression, TemplateName, AdditionalViewData));

            if (AddValidationMessage)
            {
                writer.Write(HtmlHelper.ValidationMessageFor(_expression));
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the description text
            if (AddDescription)
            {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(_expression, Helper.HtmlHelper.ViewData);
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
