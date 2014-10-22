using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface ISelectCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class SelectWrapper<TModel> : FormControlWrapper<TModel>
    {
    }

    internal interface ISelect : IFormControl
    {
    }

    public class Select<TModel> : FormControl<TModel, Select<TModel>, SelectWrapper<TModel>>, ISelect, IHasNameAttribute
    {
        internal List<string> Options { get; private set; }

        internal Select(IComponentCreator<TModel> creator)
            : base(creator, "select", Css.FormControl)
        {
            Options = new List<string>();
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Add options as child tags
            foreach (string option in Options)
            {
                Element<TModel> element = new Element<TModel>(Helper, "option");
                element.AddChild(new Content<TModel>(Helper, option));
                this.AddChild(element);
            }

            base.OnStart(writer);
        }
    }
}
