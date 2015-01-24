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
            TestHelper.AssertHtml<ASP._Views_Tests_ProgressBars_cshtml>("test-basic",
@"<div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""34"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""790"" aria-valuemin=""500"" aria-valuemax=""1000"" class=""progress-bar"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void PercentProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ProgressBars_cshtml>("test-percent",
@"<div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""34"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar"" style=""width: 34%;"">34%</div>
  </div>");
        }

        [Test]
        public void LabelProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ProgressBars_cshtml>("test-label",
@"<div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""78"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar"" style=""width: 78%;"">
    <span class=""sr-only"">78% Complete</span>Working On It
   </div>
  </div>");
        }

        [Test]
        public void ProgressBarStatesProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ProgressBars_cshtml>("test-states",
@"<div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""34"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""69"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-success"" style=""width: 69%;"">
    <span class=""sr-only"">69% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""58"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-info"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""600"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-warning"" style=""width: 100%;"">
    <span class=""sr-only"">100% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-danger"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void StripedProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ProgressBars_cshtml>("test-striped",
@"<div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""34"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-striped"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""69"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-success progress-bar-striped"" style=""width: 69%;"">
    <span class=""sr-only"">69% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""58"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-info progress-bar-striped"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""600"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-warning progress-bar-striped"" style=""width: 100%;"">
    <span class=""sr-only"">100% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-danger progress-bar-striped"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void AnimatedProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ProgressBars_cshtml>("test-animated",
@"<div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""34"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-striped active"" style=""width: 34%;"">
    <span class=""sr-only"">34% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""69"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-success progress-bar-striped active"" style=""width: 69%;"">
    <span class=""sr-only"">69% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""58"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-info progress-bar-striped active"" style=""width: 57%;"">
    <span class=""sr-only"">57% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""600"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-warning progress-bar-striped active"" style=""width: 100%;"">
    <span class=""sr-only"">100% Complete</span>
   </div>
  </div>
  <div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-danger"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
  </div>");
        }

        [Test]
        public void StackedProgressBarProducesCorrectHtml()
        {
            TestHelper.AssertHtml<ASP._Views_Tests_ProgressBars_cshtml>("test-stacked",
@"<div class=""progress"">
   <div role=""progressbar"" aria-valuenow=""35"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-success"" style=""width: 35%;"">
    <span class=""sr-only"">35% Complete</span>
   </div>
   <div role=""progressbar"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-warning progress-bar-striped"" style=""width: 20%;"">
    <span class=""sr-only"">20% Complete</span>
   </div>
   <div role=""progressbar"" aria-valuenow=""10"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar progress-bar-danger"" style=""width: 10%;"">
    <span class=""sr-only"">10% Complete</span>
   </div>
  </div>");
        }
    }
}
