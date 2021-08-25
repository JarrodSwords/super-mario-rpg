using System;
using System.Linq;
using FluentAssertions;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.Spec
{
    internal class SystemUnderTest
    {
        private IEventSourced _systemUnderTest;

        #region Public Interface

        public SystemUnderTest Assert<T>(params Action<T>[] conditions)
        {
            var pendingEvents = _systemUnderTest.GetPendingEvents().ToList();
            pendingEvents.Should().ContainSingle(x => x.GetType() == typeof(T));

            var @event = pendingEvents.First(x => x.GetType() == typeof(T));
            foreach (var condition in conditions)
                condition.Invoke((T) @event);

            return this;
        }

        public SystemUnderTest Set(IEventSourced aggregate)
        {
            _systemUnderTest = aggregate;
            return this;
        }

        #endregion
    }
}
