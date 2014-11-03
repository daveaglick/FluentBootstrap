using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class ProgressBarsFixture
    {
        [Test]
        public void BasicProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ProgressBars>("test-basic",
@"<div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""34"" class=""progress-bar"" role=""progressbar"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""1000"" aria-valuemin=""500"" aria-valuenow=""790"" class=""progress-bar"" role=""progressbar"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void PercentProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ProgressBars>("test-percent",
@"<div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""34"" class=""progress-bar"" role=""progressbar"" style=""width: 34%;"">34%</div>
  </div>");
        }

        [Test]
        public void LabelProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ProgressBars>("test-label",
@"<div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""78"" class=""progress-bar"" role=""progressbar"" style=""width: 78%;"">
    <span class=""sr-only"">78% Complete</span>Working On It
   </div>
  </div>");
        }

        [Test]
        public void ProgressBarStatesProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ProgressBars>("test-states",
@"<div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""34"" class=""progress-bar"" role=""progressbar"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""69"" class=""progress-bar-success progress-bar"" role=""progressbar"" style=""width: 69%;"">
    <span class=""sr-only"">69% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""58"" class=""progress-bar-info progress-bar"" role=""progressbar"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""600"" class=""progress-bar-warning progress-bar"" role=""progressbar"" style=""width: 100%;"">
    <span class=""sr-only"">100% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""20"" class=""progress-bar-danger progress-bar"" role=""progressbar"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void StripedProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ProgressBars>("test-striped",
@"<div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""34"" class=""progress-bar-striped progress-bar"" role=""progressbar"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""69"" class=""progress-bar-striped progress-bar-success progress-bar"" role=""progressbar"" style=""width: 69%;"">
    <span class=""sr-only"">69% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""58"" class=""progress-bar-striped progress-bar-info progress-bar"" role=""progressbar"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""600"" class=""progress-bar-striped progress-bar-warning progress-bar"" role=""progressbar"" style=""width: 100%;"">
    <span class=""sr-only"">100% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""20"" class=""progress-bar-striped progress-bar-danger progress-bar"" role=""progressbar"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void AnimatedProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ProgressBars>("test-animated",
@"<div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""34"" class=""active progress-bar-striped progress-bar"" role=""progressbar"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""69"" class=""active progress-bar-striped progress-bar-success progress-bar"" role=""progressbar"" style=""width: 69%;"">
    <span class=""sr-only"">69% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""58"" class=""active progress-bar-striped progress-bar-info progress-bar"" role=""progressbar"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""600"" class=""active progress-bar-striped progress-bar-warning progress-bar"" role=""progressbar"" style=""width: 100%;"">
    <span class=""sr-only"">100% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""20"" class=""progress-bar-danger progress-bar"" role=""progressbar"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void StackedProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.ProgressBars>("test-stacked",
@"<div class=""progress"">
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""35"" class=""progress-bar-success progress-bar"" role=""progressbar"" style=""width: 35%;"">
    <span class=""sr-only"">35% Complete</span>
   </div>
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""20"" class=""progress-bar-striped progress-bar-warning progress-bar"" role=""progressbar"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
   <div aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""10"" class=""progress-bar-danger progress-bar"" role=""progressbar"" style=""width: 10%;"">
    <span class=""sr-only"">10% Complete</span>
   </div>
  </div>");
        }
    }
}
