using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Spec
{
    public class IdSpec : ValueObjectSpec
    {
        #region Core

        private static readonly Guid Id = Guid.NewGuid();

        #endregion

        #region Test Methods

        protected override ValueObject Create() => new Id(Id);
        protected override ValueObject CreateOther() => new Id();

        [Fact]
        public void WhenCreating_WithoutValue_ValueGenerated()
        {
            var id = new Id();
            Guid value = id;

            value.Should().NotBeEmpty();
        }

        #endregion
    }
}
