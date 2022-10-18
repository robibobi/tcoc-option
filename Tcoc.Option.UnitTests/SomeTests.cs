using Shouldly;
using Xunit;

namespace Tcoc.OptionType.UnitTests
{
    public class SomeTests
    {
        class NestedType 
        {
            public override string ToString() => "Test";
        }

        [Fact]
        public void ToString_ReturnsTypeInfoAndValue()
        {
            var someValue = Option.Some(42);

            var result = someValue.ToString();

            result.ShouldBe("Some<Int32>: 42");
        }

        [Fact]
        public void ToStringOnNestedType_ReturnsOnlyClassNameAndValue()
        {
            var someValue = Option.Some(new NestedType());

            var result = someValue.ToString();

            result.ShouldBe("Some<NestedType>: Test");
        }

        [Fact]
        public void ValuePropertyIsSetToValueInCtor()
        {
            var someValue = Option.Some("xyz");

            someValue.AsSome().Value.ShouldBe("xyz");
        }
    }
}