using FluentBootstrap.ProgressBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ProgressBarExtensions
    {
        public static ProgressBars.Progress<TModel> Progress<TModel>(this IProgressCreator<TModel> creator)
        {
            return new ProgressBars.Progress<TModel>(creator);
        }

        public static ProgressBar<TModel> ProgressBar<TModel>(this IProgressBarCreator<TModel> creator, int value, int min = 0, int max = 100)
        {
            return new ProgressBar<TModel>(creator).SetValue(value).SetMin(min).SetMax(max);
        }

        public static ProgressBar<TModel> SetMin<TModel>(this ProgressBar<TModel> progressBar, int min)
        {
            progressBar.Min = min;
            return progressBar;
        }

        public static ProgressBar<TModel> SetMax<TModel>(this ProgressBar<TModel> progressBar, int max)
        {
            progressBar.Max = max;
            return progressBar;
        }

        public static ProgressBar<TModel> SetValue<TModel>(this ProgressBar<TModel> progressBar, int value)
        {
            progressBar.Value = value;
            return progressBar;
        }

        public static ProgressBar<TModel> SetPercent<TModel>(this ProgressBar<TModel> progressBar, int percent)
        {
            progressBar.Min = 0;
            progressBar.Max = 100;
            progressBar.Value = percent;
            return progressBar;
        }

        public static ProgressBar<TModel> ShowPercent<TModel>(this ProgressBar<TModel> progressBar, bool showPercent = true)
        {
            progressBar.ShowPercent = showPercent;
            return progressBar;
        }

        public static ProgressBar<TModel> SetState<TModel>(this ProgressBar<TModel> progressBar, ProgressBarState state)
        {
            return progressBar.ToggleCss(state);
        }

        public static ProgressBar<TModel> SetStriped<TModel>(this ProgressBar<TModel> progressBar, bool striped = true)
        {
            return progressBar.ToggleCss(Css.ProgressBarStriped, striped);
        }

        public static ProgressBar<TModel> SetAnimated<TModel>(this ProgressBar<TModel> progressBar, bool animated = true)
        {
            progressBar.Animated = animated;
            return progressBar;
        }
    }
}
