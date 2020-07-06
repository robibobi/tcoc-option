using System;

namespace Tcoc.OptionType
{
    public static class OptionExtensions
    {
        public static void Match<T>(
            this Option<T> option,
            Action<T> some,
            Action none)
        {
            option.AssertNotNull(nameof(option));
            some.AssertNotNull(nameof(some));
            none.AssertNotNull(nameof(none));

            if (option is Some<T> someValue)
            {
                some(someValue.Value);
            }
            else
            {
                none();
            }
        }

        public static Option<B> Map<A, B>(
            this Option<A> optionA,
            Func<A, B> mapper)
        {
            optionA.AssertNotNull(nameof(optionA));
            mapper.AssertNotNull(nameof(mapper));

            if(optionA is Some<A> someA)
            {
                return Option.Some(mapper(someA.Value));
            } else
            {
                return Option.None<B>();
            }
        }


        public static Option<B> Bind<A, B>(
            this Option<A> optionA,
            Func<A, Option<B>> func)
        {
            optionA.AssertNotNull(nameof(optionA));
            func.AssertNotNull(nameof(func));

            if(optionA is Some<A> someA)
            {
                return func(someA.Value);
            } else
            {
                return Option.None<B>();
            }
        }

        public static T ValueOr<T>(
            this Option<T> option,
             T fallbackValue)
        {
            option.AssertNotNull(nameof(option));

            if(option is Some<T> some)
            {
                return some.Value;
            } else {
                return fallbackValue;
            }
        }

        public static Some<T> AsSome<T>(this Option<T> option)
        {
            option.AssertNotNull(nameof(option));

            if(option is Some<T> some)
                return some;
            throw new ArgumentException("Cannot convert None<> to Some<>.");
        }
    }
}
