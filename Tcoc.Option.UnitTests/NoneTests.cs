using Shouldly;
using Xunit;

namespace Tcoc.OptionType.UnitTests
{
    public class NoneTests
    {
        class NestedClass {}

        [Fact]
        public void ToString_ReturnsShortTypeInformation()
        {
            var none = Option.None<string>();

            var result = none.ToString();

            result.ShouldBe("None<String>");
        }

        [Fact]
        public void ToString_NoneWithNestedTyp_ReturnsShortTypeInformation()
        {
            var none = Option.None<NestedClass>();

            var result = none.ToString();

            result.ShouldBe("None<NestedClass>");
        }

        
    }
}