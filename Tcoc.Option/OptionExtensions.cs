using System;

namespace Tcoc.OptionType
{
    public static class OptionExtensions
    {
        public static Option<B> Map<A, B>(
            this Option<A> oA,
            Func<A, B> f)
        {
            if(oA is Some<A> someA)
            {
                return Option.Some(f(someA.Value));
            } else
            {
                return Option.None<B>();
            }
        }


        public static Option<B> Bind<A, B>(
            this Option<A> optionA,
            Func<A, Option<B>> f)
        {
            if(optionA is Some<A> someA)
            {
                return f(someA.Value);
            } else
            {
                return Option.None<B>();
            }
        }
    }
}
