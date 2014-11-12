using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FluentBootstrap.Internals
{
    // This isolates methods relating to the internals of FluentBootstrap in a different namespace
    // so they can be easily included in extension libraries, but don't interfere with normal usage
    public static class InternalsExtensions
    {
        public static TThis GetThis<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component)
            where THelper : BootstrapHelper<THelper>
            where TThis : Component<THelper, TThis, TWrapper>
            where TWrapper : ComponentWrapper<THelper>, new()
        {
            return (TThis)component;
        }

        public static THelper GetHelper<THelper>(this Component<THelper> component)
            where THelper : BootstrapHelper<THelper>
        {
            return component.Helper;
        }

        public static TWrapper GetWrapper<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component)
            where THelper : BootstrapHelper<THelper>
            where TThis : Component<THelper, TThis, TWrapper>
            where TWrapper : ComponentWrapper<THelper>, new()
        {
            return component.GetWrapper();
        }

        public static void AddChild<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, Component child)
            where THelper : BootstrapHelper<THelper>
            where TThis : Component<THelper, TThis, TWrapper>
            where TWrapper : ComponentWrapper<THelper>, new()
        {
            component.AddChild(child);
        }

        public static string GetAttribute<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string key)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetAttribute(key);
        }
    }
}
