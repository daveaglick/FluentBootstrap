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
    public interface IFormControlForCreator<TModel> : IComponentCreator<MvcBootstrapHelper<TModel>>
    {
    }

    public class FormControlForWrapper<TModel> : FormControlForBaseWrapper<TModel>
    {
    }

    internal interface IFormControlFor : IFormControlForBase
    {
    }

    public class FormControlFor<TModel, TValue> : FormControlForBase<TModel, TValue, FormControlFor<TModel, TValue>, FormControlForWrapper<TModel>>, IFormControlFor
    {
        public FormControlFor(IComponentCreator<MvcBootstrapHelper<TModel>> creator, bool editor, Expression<Func<TModel, TValue>> expression)
            : base(creator, editor, expression)
        {
        }
    }
}
