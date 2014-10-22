using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Tables
{
    public interface ITableCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableWrapper<TModel> : TagWrapper<TModel>,
        ITableSectionCreator<TModel>,
        ITableRowCreator<TModel>,
        ITableCellCreator<TModel>
    {
    }

    internal interface ITable : ITag
    {
    }

    public class Table<TModel> : Tag<TModel, Table<TModel>, TableWrapper<TModel>>, ITable
    {
        internal bool Responsive { get; set; }
        private Element<TModel> _responsiveDiv;

        internal Table(IComponentCreator<TModel> creator)
            : base(creator, "table", Css.Table)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Responsive)
            {
                _responsiveDiv = new Element<TModel>(Helper, "div", Css.TableResponsive);
                _responsiveDiv.Start(writer);
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            if (_responsiveDiv != null)
            {
                _responsiveDiv.Finish(writer);
            }
        }
    }
}
