using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    // Implement this interface directly from a component to indicate it can create a different component
    public interface ICanCreate<in TComponent>
        where TComponent : Component
    {
    } 

    // This is a dummy component used to allow BootstrapHelper to create anything
    public abstract class CanCreate : Component,
        ICanCreate<Component>
    {
        private CanCreate(BootstrapHelper helper)
            : base(helper)
        {
        }
    }
}
