using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarSectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarSectionWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface INavbarSection : ITag
    {
    }

    public abstract class NavbarSection<TModel, TThis, TWrapper> : Tag<TModel, TThis, TWrapper>, INavbarSection
        where TThis : NavbarSection<TModel, TThis, TWrapper>
        where TWrapper : NavbarSectionWrapper<TModel>, new()
    {
        protected NavbarSection(IComponentCreator<TModel> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
        }

        protected override void OnPrepare(TextWriter writer)
        {
            base.OnPrepare(writer);

            // Exit any existing navbar sections
            Pop<INavbarSection>(writer);
        }
    }
}
