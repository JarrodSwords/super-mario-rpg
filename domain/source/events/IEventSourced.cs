using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public interface IEventSourced
    {
        IReadOnlyList<IEvent> GetPendingEvents();
    }
}
