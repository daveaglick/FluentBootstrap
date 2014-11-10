using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ProgressBars
{
    public interface IProgressBarCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ProgressBarWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IProgressBar : ITag
    {
    }

    public class ProgressBar<TModel> : Tag<TModel, ProgressBar<TModel>, ProgressBarWrapper<TModel>>, IProgressBar, IHasTextContent
    {
        private Progress<TModel> _progress;
        internal int Value { get; set; }
        internal int Min { get; set; }
        internal int Max { get; set; }
        internal bool ShowPercent { get; set; }
        internal bool Animated { get; set; }

        internal ProgressBar(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.ProgressBar)
        {
            this.MergeAttribute("role", "progressbar");
            Value = 50;
            Min = 0;
            Max = 100;
        }

        protected override void OnStart(TextWriter writer)
        {
            // Set the min, max, and value including progress bar width style
            int percent = (int)(((double)(Value - Min) / (double)(Max - Min)) * 100.0);
            percent = Math.Max(0, percent);
            percent = Math.Min(100, percent);
            this.MergeAttribute("aria-valuenow", Value.ToString());
            this.MergeAttribute("aria-valuemin", Min.ToString());
            this.MergeAttribute("aria-valuemax", Max.ToString());
            if (percent != 0)
            {
                this.MergeStyle("width", percent + "%");
            }

            // Make sure we're stripped if also animated
            if(Animated)
            {
                ToggleCss(Css.ProgressBarStriped, true);
                ToggleCss(Css.Active, true);
            }

            if (this.GetComponent<IProgress>(true) == null)
            {
                _progress = Helper.Progress();
                _progress.Start(writer);
            }

            base.OnStart(writer);

            if(ShowPercent)
            {
                new Content<TModel>(Helper, percent + "%").StartAndFinish(writer);
            }
            else
            {
                Helper.Element("span").AddCss(Css.SrOnly).SetText(percent + "% Complete").StartAndFinish(writer);
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            if (_progress != null)
            {
                _progress.Finish(writer);
            }
        }
    }
}
