using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IBlockquoteCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class BlockquoteWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IBlockquote : ITag
    {
    }

    public class Blockquote<THelper> : Tag<THelper, Blockquote<THelper>, BlockquoteWrapper<THelper>>, IBlockquote
        where THelper : BootstrapHelper<THelper>
    {
        internal Blockquote(IComponentCreator<THelper> creator)
            : base(creator, "blockquote")
        {
        }

        internal string Quote { get; set; }
        internal string Footer { get; set; }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (!string.IsNullOrWhiteSpace(Quote))
            {
                new Element<THelper>(Helper, "p").SetText(Quote).StartAndFinish(writer);
            }

            if (!string.IsNullOrWhiteSpace(Footer))
            {
                new Element<THelper>(Helper, "footer").SetText(Footer).StartAndFinish(writer);
            }
        }
    }
}
