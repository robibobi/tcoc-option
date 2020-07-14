using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Tcoc.OptionType.Extensions;
using Xunit;

namespace Tcoc.OptionType.UnitTests.Extensions
{
    public class EnumerableExtensionTests
    {
        [Fact]
        public void NoneIfEmpty_EnumerableIsEmpty_ReturnsNone()
        {
            var enumerable = Enumerable.Empty<string>();

            var result = enumerable.NoneIfEmpty();

            result.ShouldBeOfType<None<IEnumerable<string>>>();
        }

        [Fact]
        public void NoneIfEmpty_EnumerableIsNotEmpty_ReturnsSomeEnumerable()
        {
            var enumerable = new[] { "42" };

            var result = enumerable.NoneIfEmpty();

            result.ShouldBeOfType<Some<IEnumerable<string>>>();
            result.AsSome().Value.First().ShouldBe("42");
        }

        [Fact]
        public void NoneIfEmpty_EnumerableIsNull_ThrowsNullArgumentException()
        {
            IEnumerable<string> enumerable = null;

            Should.Throw<ArgumentNullException>(
                () => enumerable.NoneIfEmpty());
        }

    }
}