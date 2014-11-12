using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    internal class SimpleOutputContext : IOutputContext
    {
        private readonly Dictionary<object, object> _cache = new Dictionary<object, object>();
        private readonly TextWriter _textWriter;

        public SimpleOutputContext(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public TextWriter GetWriter()
        {
            return _textWriter;
        }

        public object GetItem(object key)
        {
            object value;
            return _cache.TryGetValue(key, out value) ? value : null;
        }

        public void AddItem(object key, object value)
        {
            _cache[key] = value;
        }

        public override string ToString()
        {
            return _textWriter.ToString();
        }
    }
}
