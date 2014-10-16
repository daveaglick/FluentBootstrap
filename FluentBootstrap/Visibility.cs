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
        VisibleXsBlock,
        [Description(Css.VisibleXsInline)]
        VisibleXsInline,
        [Description(Css.VisibleXsInlineBlock)]
        VisibleXsInlineBlock,
        [Description(Css.VisibleSmBlock)]
        VisibleSmBlock,
        [Description(Css.VisibleSmInline)]
        VisibleSmInline,
        [Description(Css.VisibleSmInlineBlock)]
        VisibleSmInlineBlock,
        [Description(Css.VisibleMdBlock)]
        VisibleMdBlock,
        [Description(Css.VisibleMdInline)]
        VisibleMdInline,
        [Description(Css.VisibleMdInlineBlock)]
        VisibleMdInlineBlock,
        [Description(Css.VisibleLgBlock)]
        VisibleLgBlock,
        [Description(Css.VisibleLgInline)]
        VisibleLgInline,
        [Description(Css.VisibleLgInlineBlock)]
        VisibleLgInlineBlock,
        [Description(Css.HiddenXs)]
        HiddenXs,
        [Description(Css.HiddenSm)]
        HiddenSm,
        [Description(Css.HiddenMd)]
        HiddenMd,
        [Description(Css.HiddenLg)]
        HiddenLg,
        [Description(Css.VisiblePrintBlock)]
        VisiblePrintBlock,
        [Description(Css.VisiblePrintInline)]
        VisiblePrintInline,
        [Description(Css.VisiblePrintInlineBlock)]
        VisiblePrintInlineBlock,
        [Description(Css.HiddenPrint)]
        HiddenPrint,
        [Description(Css.Show)]
        Show,
        [Description(Css.Hidden)]
        Hidden,
        [Description(Css.Invisible)]
        Invisible,
        [Description(Css.SrOnly)]
        SrOnly,
        [Description(Css.SrOnlyFocusable)]
        SrOnlyFocusable,
        [Description(Css.TextHide)]
        TextHide
    }
}
