using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class MessageStoreSpec
    {
        #region Core

        private readonly Name _componentName = "foo";
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
            var streamId = new StreamId(_componentName, fooId);

            var stream = _messageStore
                .Publish(streamId, fooCreated)
                .Publish(streamId, fooRenamed)
                .GetStream(streamId);

            stream.Events.Should().ContainInOrder(fooCreated, fooRenamed);
        }

        [Fact]
        public void WhenPublishingAnEvent_WithoutAPreExistingStream_ThenACategoryStreamIsCreated()
        {
            var fooId = Guid.NewGuid();
            var entityStreamId = new StreamId(_componentName, fooId);
            var categoryStreamId = new StreamId(_componentName);

            _messageStore.Publish(entityStreamId, new FooCreated(fooId));

            _messageStore.StreamExists(categoryStreamId).Should().BeTrue();
        }

        [Fact]
        public void WhenPublishingAnEvent_WithoutAPreExistingStream_ThenAnEntityStreamIsCreated()
        {
            var fooId = Guid.NewGuid();
            var streamId = new StreamId(_componentName, fooId);

            _messageStore.Publish(streamId, new FooCreated(fooId));

            _messageStore.StreamExists(streamId).Should().BeTrue();
        }

        #endregion

        private record FooCreated(Guid FooId) : Event;

        private record FooRenamed(Guid FooId) : Event;
    }
}
