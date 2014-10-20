using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    [Flags]
    public enum Visibility
    {
        [Description(Css.VisibleXsBlock)]
        VisibleXsBlock = 1,
        [Description(Css.VisibleXsInline)]
        VisibleXsInline = 1 << 1,
        [Description(Css.VisibleXsInlineBlock)]
        VisibleXsInlineBlock = 1 << 2,
        [Description(Css.VisibleSmBlock)]
        VisibleSmBlock = 1 << 3,
        [Description(Css.VisibleSmInline)]
        VisibleSmInline = 1 << 4,
        [Description(Css.VisibleSmInlineBlock)]
        VisibleSmInlineBlock = 1 << 5,
        [Description(Css.VisibleMdBlock)]
        VisibleMdBlock = 1 << 6,
        [Description(Css.VisibleMdInline)]
        VisibleMdInline = 1 << 7,
        [Description(Css.VisibleMdInlineBlock)]
        VisibleMdInlineBlock = 1 << 8,
        [Description(Css.VisibleLgBlock)]
        VisibleLgBlock = 1 << 9,
        [Description(Css.VisibleLgInline)]
        VisibleLgInline = 1 << 10,
        [Description(Css.VisibleLgInlineBlock)]
        VisibleLgInlineBlock = 1 << 11,
        [Description(Css.HiddenXs)]
        HiddenXs = 1 << 12,
        [Description(Css.HiddenSm)]
        HiddenSm = 1 << 13,
        [Description(Css.HiddenMd)]
        HiddenMd = 1 << 14,
        [Description(Css.HiddenLg)]
        HiddenLg = 1 << 15,
        [Description(Css.VisiblePrintBlock)]
        VisiblePrintBlock = 1 << 16,
        [Description(Css.VisiblePrintInline)]
        VisiblePrintInline = 1 << 17,
        [Description(Css.VisiblePrintInlineBlock)]
        VisiblePrintInlineBlock = 1 << 18,
        [Description(Css.HiddenPrint)]
        HiddenPrint = 1 << 19,
        [Description(Css.Show)]
        Show = 1 << 20,
        [Description(Css.Hidden)]
        Hidden = 1 << 21,
        [Description(Css.Invisible)]
        Invisible = 1 << 22,
        [Description(Css.SrOnly)]
        SrOnly = 1 << 23,
        [Description(Css.SrOnlyFocusable)]
        SrOnlyFocusable = 1 << 24,
        [Description(Css.TextHide)]
        TextHide = 1 << 25
    }
}
