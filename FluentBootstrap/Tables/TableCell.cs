using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tables
{
    public abstract class TableCell<TModel> : Tag<TModel>, ITableContext
    {
        internal TableCell(BootstrapHelper<TModel> helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            Pop<TableCell<TModel>>(writer);
            base.Prepare(writer);
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
