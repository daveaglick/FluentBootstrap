using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public interface IOutputContext
    {
        // Returns the current TextWriter for output
        TextWriter GetWriter();

        // Returns a stack that should persist for the entire page/view
        Stack<IComponent> GetComponentStack();

        // Returns a stack that should persist for the entire page/view
        Stack<IComponent> GetOutputStack();
    }
}
