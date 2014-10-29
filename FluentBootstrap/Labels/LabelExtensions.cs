using FluentBootstrap.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class LabelExtensions
    {
        public static Label<TModel> Label<TModel>(this ILabelCreator<TModel> creator, string text)
        {
            return new Label<TModel>(creator).SetText(text);
        }

        public static Label<TModel> SetState<TModel>(this Label<TModel> label, LabelState state)
        {
            label.ToggleCss(state);
            return label;
        }
    }
}
