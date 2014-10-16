using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IBlockquote : ITag
    {
    }

    public class Blockquote<TModel> : Tag<TModel, Blockquote<TModel>>, IBlockquote
    {
        internal Blockquote(BootstrapHelper<TModel> helper, params string[] cssClasses)
            : base(helper, "blockquote", cssClasses)
        {
        }

        internal string Quote { get; set; }
        internal string Footer { get; set; }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (!string.IsNullOrWhiteSpace(Quote))
            {
                new Element<TModel>(Helper, "p").SetText(Quote).StartAndFinish(writer);
            }

            if (!string.IsNullOrWhiteSpace(Footer))
            {
                new Element<TModel>(Helper, "footer").SetText(Footer).StartAndFinish(writer);
            }
        }
    }
}
