using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class IconExtensions
    {
        public static IconSpan<TModel> Icon<TModel>(this ITagCreator<TModel> creator, Icon icon)
        {
            return new IconSpan<TModel>(creator.GetHelper(), icon);
        }
    }
}
