using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class MessageStoreSpec
    {
        #region Core

        private readonly IMessageStore _messageStore;

        protected MessageStoreSpec(IMessageStore messageStore)
        {
            _messageStore = messageStore;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenPublishingAnEvent_WithAPreExistingStream_ThenTheEventIsAppendedToTheStream()
        {
            var fooId = Guid.NewGuid();
            var fooCreated = new FooCreated(fooId);
            var fooRenamed = new FooRenamed(fooId);
            var streamId = new StreamId(fooId, false, "foo");

            var stream = _messageStore
                .Publish(streamId, fooCreated)
                .Publish(streamId, fooRenamed)
                .GetStream(streamId);

            stream.Events.Should().ContainInOrder(fooCreated, fooRenamed);
        }

        [Fact]
        public void WhenPublishingAnEvent_WithoutAPreExistingStream_ThenAnEntityStreamIsCreated()
        {
            var fooId = Guid.NewGuid();
            var fooCreated = new FooCreated(fooId);
            var streamId = new StreamId(fooId, false, "foo");

            _messageStore.Publish(streamId, fooCreated);

            _messageStore.StreamExists(streamId).Should().BeTrue();
        }

        #endregion

        private record FooCreated(Guid FooId) : Event;

        private record FooRenamed(Guid FooId) : Event;
    }
}
