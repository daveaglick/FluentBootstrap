using System.Collections;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FluentBootstrap.Html;

namespace FluentBootstrap.Forms
{   
    public interface IFormControlForCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class FormControlForWrapper<THelper> : FormControlForBaseWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IFormControlFor : IFormControlForBase
    {
    }

    public class FormControlFor<THelper, TValue> : FormControlForBase<THelper, TValue, FormControlFor<THelper, TValue>, FormControlForWrapper<THelper>>, IFormControlFor
        where THelper : BootstrapHelper<THelper>
    {
        public FormControlFor(IComponentCreator<THelper> creator, bool editor, Expression<Func<THelper, TValue>> expression)
            : base(creator, editor, expression)
        {
        }
    }
}
