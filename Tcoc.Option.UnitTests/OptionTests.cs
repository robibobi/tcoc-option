using System;
using Xunit;
using Shouldly;

namespace Tcoc.OptionType.UnitTests
{
    public class OptionTests
    {
        [Fact]
        public void Some_ValueIsNumber5_SomeInt()
        {
            var value = 5;

            var result = Option.Some(value);

            result.ShouldBeOfType<Some<int>>();
        }

        [Fact]
        public void Some_ValueIsNull_ThrowsArgumentNullException()
        {
            Should.Throw<ArgumentNullException>(
                () => Option.Some<object>(null));
        }

        [Fact]
        public void None_TypeString_ReturnsNone()
        {
            var result = Option.None<string>();

            result.ShouldBeOfType<None<string>>();
        }


        [Fact]
        public void From_ValueIsNull_ReturnsNone()
        {
            object value = null;

            var result = Option.From(value);

            result.ShouldBeOfType<None<object>>();
        }

        [Fact]
        public void From_ValueIsNotNull_ReturnsSome()
        {
            var result = Option.From("Hello");

            result.ShouldBeOfType<Some<string>>();
        }

        [Fact]
        public void FromNullable_ArgumentIsNull_ReturnsNone()
        {
            int? nullableValue = null;

            var result = Option.FromNullable(nullableValue);

            result.ShouldBeOfType<None<int>>();
        }

        [Fact]
        public void FromNullable_EmptyNullable_ReturnsNone()
        {
            int? nullableValue = new Nullable<int>();

            var result = Option.FromNullable(nullableValue);

            result.ShouldBeOfType<None<int>>();
        }

        [Fact]
        public void FromNullable_NullableHasValue_ReturnsSome()
        {
            int? nullableValue = 42;

            var result = Option.FromNullable(nullableValue);

            result.ShouldBeOfType<Some<int>>();
            result.AsSome().Value.ShouldBe(42);
        }

    }
}
