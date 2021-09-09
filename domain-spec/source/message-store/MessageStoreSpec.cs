using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class MessageStoreSpec
    {
        #region Core

        private readonly IMessageStore _messageStore;
        private readonly StreamId _streamId;

        protected MessageStoreSpec(IMessageStore messageStore)
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

        private record FooCreated(Guid FooId) : Event;
    }
}
