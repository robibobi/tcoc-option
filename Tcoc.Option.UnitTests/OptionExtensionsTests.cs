using System;
using Shouldly;
using Xunit;

namespace Tcoc.OptionType.UnitTests
{
    public class OptionExtensionsTests
    {
        [Fact]
        public void Map_OptionIsSome_FunctionIsAppliedToValue()
        {
            var option = Option.Some(5);

            var result = option.Map(nr => nr * 2);

            result.ShouldBeOfType<Some<int>>();
            (result as Some<int>).Value.ShouldBe(10);
        }

        [Fact]
        public void Map_OptionIsNone_NoneIsReturned()
        {
            var option = Option.None<int>();

            var result = option.Map(nr => nr * 2);

            result.ShouldBeOfType<None<int>>();
        }

        [Fact]
        public void Map_OptionIsNull_ThrowsArgumentNullException()
        {
            Option<int> option = null;
            Action throwingAction = () => option.Map(a => a);

            throwingAction.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Map_MapperIsNull_ThrowsArgumentNullException()
        {
            Func<int, int> mapper = null;
            Action throwingAction = () => Option.Some(432).Map(mapper);

            throwingAction.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void Bind_SomeValue_FunctionThatReturnsAnotherOption_FunctionIsAppliedToValue()
        {
            var intOption = Option.Some(42);

            Option<string> func(int value) => value == 42 ?
                Option.Some("This is the meaning of life.") :
                Option.None<string>();

            var stringOption = intOption.Bind(func);

            stringOption.ShouldBeOfType<Some<string>>();
            (stringOption as Some<string>).Value.ShouldBe("This is the meaning of life.");
        }


        [Fact]
        public void Bind_OptionIsNone_FunctionIsNotApplied_ButOptionTypeIsMappedToString()
        {
            var intOption = Option.None<int>();

            Option<string> func(int value) =>
                throw new ShouldAssertException("func should not be called.");

            var stringOption = intOption.Bind(func);

            stringOption.ShouldBeOfType<None<string>>();
        }

        [Fact]
        public void Bind_OptionIsNull_ThrowsNullArgException()
        {
            Option<int> option = null;
            Action throwingAction = () => option.Bind(f => Option.None<string>());

            throwingAction.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Bind_FuncIsNull_ThrowsNullArgException()
        {
            Func<int, Option<int>> func = null;
            Action throwingAction = () => Option.Some(42).Bind(func);

            throwingAction.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Match_OptionIsSome_SomeDelegateIsExecutedWithCorrectValue()
        {
            int result = -1;
            var option = Option.Some(42);

            option.Match(
                some: value => result = value,
                none: () => { });

            result.ShouldBe(42);
        }


        [Fact]
        public void Match_OptionIsNone_NoneDelegateIsExecuted()
        {
            int result = -1;
            var option = Option.None<int>();

            option.Match(
                some: value => { },
                none: () => result = 2);

            result.ShouldBe(2);
        }


        [Fact]
        public void Match_OptionIsNull_ThrowsArgumentNullException()
        {
            Option<int> option = null;

            Should.Throw<ArgumentNullException>(() =>
                 option.Match(some: _ => { }, none: () => { }));
        }

        [Fact]
        public void Match_SomeDelegateIsNull_ThrowsArgumentNullException()
        {
            Should.Throw<ArgumentNullException>(() =>
                 Option.Some(42).Match(null, none: () => { }));
        }

        [Fact]
        public void Match_NoneDelegateIsNull_ThrowsArgumentNullException()
        {
            Should.Throw<ArgumentNullException>(() =>
                 Option.Some(42).Match(some: _ => { }, none: null));
        }

        [Fact]
        public void ValueOr_OptionIsSome_ReturnsValueInOption()
        {
            var option = Option.Some(42);
            option.ValueOr(-1).ShouldBe(42);
        }

        [Fact]
        public void ValueOr_OptionIsNone_ReturnsFallbackValue()
        {
            var option = Option.None<int>();
            option.ValueOr(-1).ShouldBe(-1);
        }

        [Fact]
        public void ValueOr_OptionIsNull_ThrowsArgumentNullException()
        {
            Option<int> option = null;
            Should.Throw<ArgumentNullException>(() => option.ValueOr(5));
        }

        [Fact]
        public void AsSome_OptionIsSome_ReturnsOptionAsSome()
        {
            var option = Option.Some(42);
            var result = option.AsSome();

            result.Value.ShouldBe(42);
        }

        [Fact]
        public void AsSome_OptionIsNone_ThrowsArgumentException()
        {
            Should.Throw<ArgumentException>(() => Option.None<int>().AsSome());
        }

        [Fact]
        public void AsSome_OptionIsNull_ThrowsArgumentNullException()
        {
            Option<int> option = null;
            Should.Throw<ArgumentNullException>(() => option.AsSome());
        }
    }
}