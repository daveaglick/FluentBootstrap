using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface ISelectCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class SelectWrapper<THelper> : FormControlWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ISelect : IFormControl
    {
    }

    public class Select<THelper> : FormControl<THelper, Select<THelper>, SelectWrapper<THelper>>, ISelect, IHasNameAttribute
        where THelper : BootstrapHelper<THelper>
    {
        internal List<string> Options { get; private set; }

        internal Select(IComponentCreator<THelper> creator)
            : base(creator, "select", Css.FormControl)
        {
            Options = new List<string>();
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Add options as child tags
            foreach (string option in Options)
            {
                Element<THelper> element = new Element<THelper>(Helper, "option");
                element.AddChild(new Content<THelper>(Helper, option));
                this.AddChild(element);
            }

            base.OnStart(writer);
        }
    }
}
