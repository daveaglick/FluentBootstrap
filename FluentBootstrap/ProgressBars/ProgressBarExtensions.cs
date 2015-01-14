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
        public static ProgressBars.Progress<TConfig> Progress<TConfig>(this IProgressCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new ProgressBars.Progress<TConfig>(creator);
        }

        public static ProgressBar<TConfig> ProgressBar<TConfig>(this IProgressBarCreator<TConfig> creator, int value, int min = 0, int max = 100)
            where TConfig : BootstrapConfig
        {
            return new ProgressBar<TConfig>(creator).SetValue(value).SetMin(min).SetMax(max);
        }

        public static ProgressBar<TConfig> SetMin<TConfig>(this ProgressBar<TConfig> progressBar, int min)
            where TConfig : BootstrapConfig
        {
            progressBar.Min = min;
            return progressBar;
        }

        public static ProgressBar<TConfig> SetMax<TConfig>(this ProgressBar<TConfig> progressBar, int max)
            where TConfig : BootstrapConfig
        {
            progressBar.Max = max;
            return progressBar;
        }

        public static ProgressBar<TConfig> SetValue<TConfig>(this ProgressBar<TConfig> progressBar, int value)
            where TConfig : BootstrapConfig
        {
            progressBar.Value = value;
            return progressBar;
        }

        public static ProgressBar<TConfig> SetPercent<TConfig>(this ProgressBar<TConfig> progressBar, int percent)
            where TConfig : BootstrapConfig
        {
            progressBar.Min = 0;
            progressBar.Max = 100;
            progressBar.Value = percent;
            return progressBar;
        }

        public static ProgressBar<TConfig> ShowPercent<TConfig>(this ProgressBar<TConfig> progressBar, bool showPercent = true)
            where TConfig : BootstrapConfig
        {
            progressBar.ShowPercent = showPercent;
            return progressBar;
        }

        public static ProgressBar<TConfig> SetState<TConfig>(this ProgressBar<TConfig> progressBar, ProgressBarState state)
            where TConfig : BootstrapConfig
        {
            return progressBar.ToggleCss(state);
        }

        public static ProgressBar<TConfig> SetStriped<TConfig>(this ProgressBar<TConfig> progressBar, bool striped = true)
            where TConfig : BootstrapConfig
        {
            return progressBar.ToggleCss(Css.ProgressBarStriped, striped);
        }

        public static ProgressBar<TConfig> SetAnimated<TConfig>(this ProgressBar<TConfig> progressBar, bool animated = true)
            where TConfig : BootstrapConfig
        {
            progressBar.Animated = animated;
            return progressBar;
        }
    }
}
