using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Form : Tag,
        ICanCreate<FormGroup>,
        ICanCreate<ControlLabel>,
        ICanCreate<FormControl>,
        ICanCreate<HelpBlock>
        //IFieldSetCreator<THelper>,
        //IInputGroupCreator<THelper>
    {        
        public Form(IComponentCreator creator, params string[] cssClasses)
            : base(creator, "form", cssClasses)
        {
            DefaultLabelWidth = creator.GetHelper().DefaultFormLabelWidth;
            MergeAttribute("role", "form");
        }

        public int DefaultLabelWidth { get; set; }    // This is only used for horizontal forms

        public bool Horizontal
        {
            get { return CssClasses.Contains(Css.FormHorizontal); }
        }
    }
}
