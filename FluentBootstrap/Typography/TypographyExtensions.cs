using System.Web.Mvc;
using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class TypographyExtensions
    {
        // List

        public static Typography.List<TModel> List<TModel>(this IListCreator<TModel> creator, ListType listType = ListType.Unstyled)
        {
            return new Typography.List<TModel>(creator.GetHelper(), listType);
        }

        public static Typography.List<TModel> ListFor<TModel, TValue>(this IListCreator<TModel> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
        {
            Typography.List<TModel> list = new Typography.List<TModel>(creator.GetHelper(), listType);
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(expression, creator.GetHelper().HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    list.AddChild(x => x.ListItem(item(value)));
                }
            }
            return list;
        }

        // ListItem

        public static ListItem<TModel> ListItem<TModel>(this IListItemCreator<TModel> creator, object content = null)
        {
            return new ListItem<TModel>(creator.GetHelper()).AddContent(content);
        }

    }
}
