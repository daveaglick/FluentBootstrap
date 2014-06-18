using System.IO;

namespace FluentBootstrap.Tables
{
    public class TableRow<TModel> : Tag<TModel>, ITableContext,
        TableCell<TModel>.ICreate
    {
        internal TableRow(BootstrapHelper<TModel> helper)
            : base(helper, "tr")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            Pop<TableRow<TModel>>(writer);

            // Make sure we're in a section, but only if we're also in a table
            if (GetComponent<Table<TModel>>() != null && GetComponent<TableSection<TModel>>() == null)
            {
                new TableBody<TModel>(Helper).Start(writer, true);
            }
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}