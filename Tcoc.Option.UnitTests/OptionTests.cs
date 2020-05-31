using System;
using Xunit;
using Tcoc.OptionType;
using Shouldly;

namespace Tcoc.Option.UnitTests
{
    public class OptionTests
    {
        [Fact]
        public void Some_ValueIsNumber5_SomeInt()
        {
            var value = 5;

            var result = Tcoc.OptionType.Option.Some(value);

            result.ShouldBeOfType<Some<int>>();
        }

        [Fact]
        public void Some_ValueIsNumber5_SomeIntWithValue5()
        {
            var value = 5;

            var result = Tcoc.OptionType.Option.Some(value);

            (result as Some<int>).Value.ShouldBe(5);
        }
    }
}
