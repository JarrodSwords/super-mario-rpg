using System;

namespace SuperMarioRpg.Domain
{
    public interface IEvent
    {
        Guid Id { get; }
        string Type { get; }
    }
}
