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

        // Gets an item from a persistent cache for the entire page/view
        // Should return null if the key doesn't exist
        object GetItem(object key);

        // Adds an item to a persistent cache for the entire page/view
        // Should overwrite the previous value if the key already exists
        void AddItem(object key, object value);
    }
}
