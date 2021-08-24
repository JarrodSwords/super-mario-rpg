using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public abstract class ValueObjectSpec
    {
        #region Protected Interface

        protected abstract ValueObject Create();
        protected abstract ValueObject CreateOther();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCheckingEquality_WithDifferentStructure_HasStructuralInequality()
        {
            var valueObject1 = Create();
            var valueObject2 = CreateOther();

            valueObject2.Should().NotBe(valueObject1);
        }

        [Fact]
        public void WhenCheckingEquality_WithSameReference_HasReferentialEquality()
        {
            var valueObject1 = Create();
            var valueObject2 = valueObject1;

            valueObject2.Should().BeSameAs(valueObject1);
        }

        [Fact]
        public void WhenCheckingEquality_WithSameStructure_HasStructuralEquality()
        {
            var valueObject1 = Create();
            var valueObject2 = Create();

            valueObject2.Should().NotBeSameAs(valueObject1);
            valueObject2.Should().Be(valueObject1);
        }

        #endregion

        public class FooSpec : ValueObjectSpec
        {
            #region Protected Interface

            protected override ValueObject Create() => new Foo(1);
            protected override ValueObject CreateOther() => new Foo(2);

            #endregion
        }

        private class Foo : ValueObject
        {
            #region Creation

            public Foo(int bar)
            {
                Bar = bar;
            }

            #endregion

            #region Public Interface

            public int Bar { get; }

            #endregion

            #region Equality

            public override IEnumerable<object> GetEqualityComponents()
            {
                yield return Bar;
            }

            #endregion
        }
    }
}
