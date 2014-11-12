using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap.Internals
{
    // This isolates methods relating to the internals of FluentBootstrap in a different namespace
    // so they can be easily included in extension libraries, but don't interfere with normal usage
    public static class InternalsExtensions
    {
        public static TThis GetThis<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return (TThis)component;
        }

        public static THelper GetHelper<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.Helper;
        }
    }
}
