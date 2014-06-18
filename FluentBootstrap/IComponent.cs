using System.IO;

namespace FluentBootstrap
{
    internal interface IComponent
    {
        void Start(TextWriter writer, bool @implicit);

        void Finish(TextWriter writer);

        bool Implicit { get; }
    }
}