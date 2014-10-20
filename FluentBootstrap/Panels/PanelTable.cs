using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelTableCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PanelTableWrapper<TModel> : PanelSectionWrapper<TModel>
    {
    }
    internal interface IPanelTable : IPanelSection
    {
    }

    public class PanelTable<TModel> : PanelSection<TModel, PanelTable<TModel>, PanelTableWrapper<TModel>>, IPanelTable
    {
        internal PanelTable(IComponentCreator<TModel> creator)
            : base(creator, Css.Table)
        {
        }
    }
}
