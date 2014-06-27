using System.IO;

namespace FluentBootstrap.Tables
{
    internal interface ITableRow : ITag
    {
    }

    public interface ITableRowCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableRow<TModel> : Tag<TModel, TableRow<TModel>>, ITableRow, IHasTableContextExtensions,
        ITableCellCreator<TModel>
    {
        internal TableRow(BootstrapHelper<TModel> helper)
            : base(helper, "tr")
        {
        }

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);

            Pop<ITableRow>(writer);

            // Make sure we're in a section, but only if we're also in a table
            if (GetComponent<ITable>() != null && GetComponent<ITableSection>() == null)
            {
                new TableBody<TModel>(Helper).Start(writer, true);
            }
        }
    }
}