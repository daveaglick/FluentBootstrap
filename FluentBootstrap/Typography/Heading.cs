using FluentBootstrap.Html;
using FluentBootstrap.Labels;
using FluentBootstrap.MediaObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IHeadingCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class HeadingWrapper<TModel> : TagWrapper<TModel>,
        ISmallCreator<TModel>,
        ILabelCreator<TModel>
    {
    }

    internal interface IHeading : ITag
    {
    }

    public abstract class Heading<TModel, TThis, TWrapper> : Tag<TModel, TThis, TWrapper>, IHeading, IHasTextContent
        where TThis : Heading<TModel, TThis, TWrapper>
        where TWrapper : HeadingWrapper<TModel>, new()
    {
        internal string SmallText { private get; set; }

        internal Heading(IComponentCreator<TModel> creator, string tagName)
            : base(creator, tagName)
        {
        }


        protected override void OnStart(TextWriter writer)
        {
            // Add the appropriate CSS class if in a media object
            if(GetComponent<IMediaBody>() != null)
            {
                this.AddCss(Css.MediaHeading);
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(SmallText))
            {
                new Small<TModel>(Helper).SetText(SmallText).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }

    public class Heading<TModel> : Heading<TModel, Heading<TModel>, HeadingWrapper<TModel>>
    {
        internal Heading(IComponentCreator<TModel> creator, string tagName)
            : base(creator, tagName)
        {
        }
    }
}
