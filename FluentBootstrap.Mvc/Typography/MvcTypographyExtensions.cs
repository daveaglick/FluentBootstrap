using FluentBootstrap.Internals;
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
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Typography.List> ListFor<TComponent, TModel, TValue>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, 
            Expression<Func<TModel, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
            where TComponent : Component, ICanCreate<Typography.List>
        {
            ComponentBuilder<MvcBootstrapConfig<TModel>, Typography.List> builder =
                new ComponentBuilder<MvcBootstrapConfig<TModel>, Typography.List>(helper.GetConfig(), helper.List(listType).GetComponent());
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(expression, builder.GetConfig().HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    builder.AddChild(x => x.ListItem(item(value)));
                }
            }
            return builder;
        }
    }
}
