using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Select : FormControl, IHasNameAttribute
    {
        public List<string> Options { get; private set; }

        internal Select(IComponentCreator creator)
            : base(creator, "select", Css.FormControl)
        {
            Options = new List<string>();
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Add options as child tags
            foreach (string option in Options)
            {
                AddChild(Config.Element("option").AddChild(Config.Content(option)));
            }

            base.OnStart(writer);
        }
    }
}
