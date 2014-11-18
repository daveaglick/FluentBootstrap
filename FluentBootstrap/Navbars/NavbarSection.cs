using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarSectionCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarSectionWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarSection : ITag
    {
    }

    public abstract class NavbarSection<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, INavbarSection
        where THelper : BootstrapHelper<THelper>
        where TThis : NavbarSection<THelper, TThis, TWrapper>
        where TWrapper : NavbarSectionWrapper<THelper>, new()
    {
        protected NavbarSection(IComponentCreator<THelper> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Exit any existing navbar sections
            Pop<INavbarSection>(writer);

            base.OnStart(writer);
        }
    }
}
