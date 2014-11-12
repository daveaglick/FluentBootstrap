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
    public interface ITableCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class TableWrapper<THelper> : TagWrapper<THelper>,
        ITableSectionCreator<THelper>,
        ITableRowCreator<THelper>,
        ITableCellCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ITable : ITag
    {
    }

    public class Table<THelper> : Tag<THelper, Table<THelper>, TableWrapper<THelper>>, ITable
        where THelper : BootstrapHelper<THelper>
    {
        internal bool Responsive { get; set; }
        private Element<THelper> _responsiveDiv;

        internal Table(IComponentCreator<THelper> creator)
            : base(creator, "table", Css.Table)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Responsive)
            {
                _responsiveDiv = new Element<THelper>(Helper, "div", Css.TableResponsive);
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
