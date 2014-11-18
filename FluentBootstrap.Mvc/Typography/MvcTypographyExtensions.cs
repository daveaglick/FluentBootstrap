using FluentBootstrap.Mvc;
using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public static class MvcTypographyExtensions
    {
        public static Typography.List<MvcBootstrapHelper<TModel>> ListFor<TModel, TValue>(this IListCreator<MvcBootstrapHelper<TModel>> creator, 
            Expression<Func<TModel, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
        {
            Typography.List<MvcBootstrapHelper<TModel>> list = creator.List(listType);
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(expression, list.Helper.HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    list.AddChild(x => x.ListItem(item(value)));
                }
            }
            return list;
        }

        public static Typography.List<MvcBootstrapHelper<TModel>> ListFor<THelper, TModel, TValue>(this IListCreator<MvcBootstrapHelper<TModel>> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
            where THelper : BootstrapHelper<THelper>
        {
            Typography.List<MvcBootstrapHelper<TModel>> list = new Typography.List<MvcBootstrapHelper<TModel>>(creator, listType);
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(expression, list.Helper.HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    list.AddChild(x => x.ListItem(item(value)));
                }
            }
            return list;
        }
    }
}
