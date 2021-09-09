using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec.IMessageStoreSpec
{
    public abstract class GivenANewEntityStream
    {
        #region Core

        private readonly IMessageStore _messageStore;
        private readonly StreamId _streamId;

        protected GivenANewEntityStream(IMessageStore messageStore)
        {
            _messageStore = messageStore;

            var fooId = Guid.NewGuid();
            var fooCreated = new FooCreated(fooId);
            _streamId = new StreamId(fooId, false, "foo");

            _messageStore.Publish(_streamId, fooCreated);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenAnEventIsPublished_ThenAnEntityStreamIsCreated()
        {
            _messageStore.StreamExists(_streamId).Should().BeTrue();
        }

        #endregion
    }

    public class GivenAnInMemoryMessageStore : GivenANewEntityStream
    {
        #region Creation

        public GivenAnInMemoryMessageStore() : base(new InMemoryMessageStore())
        {
        }

        #endregion
    }

    internal record FooCreated(Guid FooId) : Event
    {
    }
}
