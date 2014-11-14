using System.Collections;
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
using FluentBootstrap.Forms;

namespace FluentBootstrap.Mvc.Forms
{   
    public interface IFormControlForCreator<TModel, THelper> : IComponentCreator<THelper>
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
    }

    public class FormControlForWrapper<TModel, THelper> : FormControlForBaseWrapper<TModel, THelper>
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
    }

    internal interface IFormControlFor : IFormControlForBase
    {
    }

    public class FormControlFor<TModel, THelper, TValue> : FormControlForBase<TModel, THelper, TValue, FormControlFor<TModel, THelper, TValue>, FormControlForWrapper<TModel, THelper>>, IFormControlFor
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
        public FormControlFor(IComponentCreator<THelper> creator, bool editor, Expression<Func<TModel, TValue>> expression)
            : base(creator, editor, expression)
        {
        }
    }
}
