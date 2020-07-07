using System;

namespace Tcoc.OptionType
{
    public static class LinqSyntax
    {
        public static Option<B> Select<A, B>(
            this Option<A> option,
            Func<A, B> selector)
        {
            return option.Map(selector);
        }

        public static Option<B> SelectMany<A, B>(
            this Option<A> option,
            Func<A, Option<B>> selector)
        {
            return option.Bind(selector);
        }


        public static Option<C> SelectMany<A, B, C>(
            this Option<A> option,
            Func<A, Option<B>> selector,
            Func<A, B, C> resultSelector)
        {
            return option
                .Bind(a => selector(a)
                    .Map(b => resultSelector(a, b)));
        }
    }
}