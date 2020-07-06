using System;
using Shouldly;
using Tcoc.OptionType;
using Xunit;

namespace Tcoc.OptionType.UnitTests
{
    public class SomeTests
    {
        [Fact]
        public void ToString_ReturnsTypeInfoAndValue()
        {
            var someValue = Option.Some(42);

            var result = someValue.ToString();

            result.ShouldBe("Some<Int32>: 42");
        }
    }
}