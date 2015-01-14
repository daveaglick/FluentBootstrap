using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ProgressBars
{
    public class ProgressBar : Tag, IHasTextContent
    {
        private Progress _progress;

        public int Value { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public bool ShowPercent { get; set; }
        public bool Animated { get; set; }

        internal ProgressBar(BootstrapHelper helper)
            : base(helper, "div", Css.ProgressBar)
        {
            MergeAttribute("role", "progressbar");
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
            MergeAttribute("aria-valuenow", Value.ToString());
            MergeAttribute("aria-valuemin", Min.ToString());
            MergeAttribute("aria-valuemax", Max.ToString());
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

            if (GetComponent<Progress>(true) == null)
            {
                _progress = GetHelper().Progress().Component;
                _progress.Start(writer);
            }

            base.OnStart(writer);

            if(ShowPercent)
            {
                GetHelper().Content(percent + "%").Component.StartAndFinish(writer);
            }
            else
            {
                GetHelper().Element("span").AddCss(Css.SrOnly).SetText(percent + "% Complete").Component.StartAndFinish(writer);
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
