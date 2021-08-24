using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class EntitySpec
    {
        #region Protected Interface

        protected abstract Entity Create();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCheckingEquality_WithSameReference_HasReferentialEquality()
        {
            var entity1 = Create();
            var entity2 = entity1;

            entity2.Should().BeSameAs(entity2);
        }

        #endregion

        public class FooSpec : EntitySpec
        {
            #region Protected Interface

            protected override Entity Create() => new Foo();

            #endregion
        }

        private class Foo : Entity
        {
        }
    }
}
