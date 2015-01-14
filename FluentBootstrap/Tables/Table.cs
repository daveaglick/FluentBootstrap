using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tables
{
    public interface ITableCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableWrapper<TConfig> : TagWrapper<TConfig>,
        ITableSectionCreator<TConfig>,
        ITableRowCreator<TConfig>,
        ITableCellCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITable : ITag
    {
    }

    public class Table<TConfig> : Tag<TConfig, Table<TConfig>, TableWrapper<TConfig>>, ITable
        where TConfig : BootstrapConfig
    {
        internal bool Responsive { get; set; }
        private Element<TConfig> _responsiveDiv;

        internal Table(BootstrapHelper helper)
            : base(helper, "table", Css.Table)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Responsive)
            {
                _responsiveDiv = new Element<TConfig>(Helper, "div").AddCss(Css.TableResponsive);
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
