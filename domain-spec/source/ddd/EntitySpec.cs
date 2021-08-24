using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class EntitySpec
    {
        #region Protected Interface

        protected abstract Entity Create(Id id = default);

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCheckingEquality_WithDifferentId_HasIdentifierInequality()
        {
            var entity1 = Create();
            var entity2 = Create();

            entity2.Should().NotBe(entity1);
        }

        [Fact]
        public void WhenCheckingEquality_WithSameId_HasIdentifierEquality()
        {
            var id = new Id();
            var entity1 = Create(id);
            var entity2 = Create(id);

            entity2.Should().NotBeSameAs(entity1);
            entity2.Should().Be(entity1);
        }

        [Fact]
        public void WhenCheckingEquality_WithSameReference_HasReferentialEquality()
        {
            var entity1 = Create();
            var entity2 = entity1;

            entity2.Should().BeSameAs(entity2);
        }

        [Fact]
        public void WhenCreating_WithoutId_IdCreated()
        {
            var entity = Create();

            entity.Id.Should().NotBeNull();
        }

        #endregion

        public class FooSpec : EntitySpec
        {
            #region Protected Interface

            protected override Entity Create(Id id = default) => new Foo(id);

            #endregion
        }

        private class Foo : Entity
        {
            #region Creation

            public Foo(Id id) : base(id)
            {
            }

            #endregion
        }
    }
}
