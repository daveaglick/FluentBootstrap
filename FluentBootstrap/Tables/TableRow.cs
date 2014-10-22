using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableRowCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableRowWrapper<TModel> : TagWrapper<TModel>,
        ITableCellCreator<TModel>
    {
    }

    internal interface ITableRow : ITag
    {
    }

    public class TableRow<TModel> : Tag<TModel, TableRow<TModel>, TableRowWrapper<TModel>>, ITableRow, IHasTableStateExtensions
    {
        internal bool HeadRow { get; set; }

        internal TableRow(IComponentCreator<TModel> creator)
            : base(creator, "tr")
        {
        }

        protected override void OnPrepare(TextWriter writer)
        {
            base.OnPrepare(writer);

            Pop<ITableRow>(writer);

            // Make sure we're in a section, but only if we're also in a table
            if (GetComponent<ITable>() != null && GetComponent<ITableSection>() == null)
            {
                if (HeadRow)
                {
                    new TableHeadSection<TModel>(Helper).Start(writer);
                }
                else
                {
                    new TableBodySection<TModel>(Helper).Start(writer);
                }
            }
        }
    }
}