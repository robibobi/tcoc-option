using Shouldly;
using Xunit;

namespace Tcoc.OptionType.UnitTests
{
    public class LinqSytaxTests
    {
        [Fact]
        public void CanUseFromAndSelectWithOptionType()
        {
            var option =
                from intValue in Option.Some(41)
                select intValue + 1;

            option.AsSome().Value.ShouldBe(42);
        }

        [Fact]
        public void CanUseMultipleFromStatements()
        {
            var option =
                from value1 in Option.Some(12)
                from value2 in Option.Some(16)
                from value3 in Option.Some(14)
                select value1 + value2 + value3;

            option.AsSome().Value.ShouldBe(42);
        }

        [Fact]
        public void NoneInFromClauseResultsIntoNone()
        {
            var option =
                from value1 in Option.Some(12)
                from value2 in Option.None<int>()
                from value3 in Option.Some(14)
                select value1 + value2 + value3;

            option.ShouldBeOfType<None<int>>();
        }
    }
}