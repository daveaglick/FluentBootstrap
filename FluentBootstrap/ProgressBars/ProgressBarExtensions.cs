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
        public static ProgressBars.Progress<THelper> Progress<THelper>(this IProgressCreator<THelper> creator)
        {
            return new ProgressBars.Progress<THelper>(creator);
        }

        public static ProgressBar<THelper> ProgressBar<THelper>(this IProgressBarCreator<THelper> creator, int value, int min = 0, int max = 100)
        {
            return new ProgressBar<THelper>(creator).SetValue(value).SetMin(min).SetMax(max);
        }

        public static ProgressBar<THelper> SetMin<THelper>(this ProgressBar<THelper> progressBar, int min)
        {
            progressBar.Min = min;
            return progressBar;
        }

        public static ProgressBar<THelper> SetMax<THelper>(this ProgressBar<THelper> progressBar, int max)
        {
            progressBar.Max = max;
            return progressBar;
        }

        public static ProgressBar<THelper> SetValue<THelper>(this ProgressBar<THelper> progressBar, int value)
        {
            progressBar.Value = value;
            return progressBar;
        }

        public static ProgressBar<THelper> SetPercent<THelper>(this ProgressBar<THelper> progressBar, int percent)
        {
            progressBar.Min = 0;
            progressBar.Max = 100;
            progressBar.Value = percent;
            return progressBar;
        }

        public static ProgressBar<THelper> ShowPercent<THelper>(this ProgressBar<THelper> progressBar, bool showPercent = true)
        {
            progressBar.ShowPercent = showPercent;
            return progressBar;
        }

        public static ProgressBar<THelper> SetState<THelper>(this ProgressBar<THelper> progressBar, ProgressBarState state)
        {
            return progressBar.ToggleCss(state);
        }

        public static ProgressBar<THelper> SetStriped<THelper>(this ProgressBar<THelper> progressBar, bool striped = true)
        {
            return progressBar.ToggleCss(Css.ProgressBarStriped, striped);
        }

        public static ProgressBar<THelper> SetAnimated<THelper>(this ProgressBar<THelper> progressBar, bool animated = true)
        {
            progressBar.Animated = animated;
            return progressBar;
        }
    }
}
