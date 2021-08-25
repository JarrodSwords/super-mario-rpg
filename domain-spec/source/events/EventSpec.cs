using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class EventSpec
    {
        #region Protected Interface

        protected abstract IEvent Create();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCreating_IsInitialized()
        {
            var e = Create();
            var id = e.Id;

            id.Should().NotBeEmpty();
            e.Type.Should().Be(e.GetType().Name);
        }

        #endregion

        public class FooedSpec : EventSpec
        {
            #region Protected Interface

            protected override Event Create() => new Fooed();

            #endregion
        }

        public record Fooed : Event
        {
        }
    }
}
