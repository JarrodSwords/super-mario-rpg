using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class ValueObjectSpec
    {
        #region Protected Interface

        protected abstract ValueObject Create();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCheckingEquality_WithSameReference_HasReferentialEquality()
        {
            var valueObject1 = Create();
            var valueObject2 = valueObject1;

            valueObject2.Should().BeSameAs(valueObject1);
        }

        #endregion

        public class FooSpec : ValueObjectSpec
        {
            #region Protected Interface

            protected override ValueObject Create() => new Foo();

            #endregion
        }

        private class Foo : ValueObject
        {
        }
    }
}
