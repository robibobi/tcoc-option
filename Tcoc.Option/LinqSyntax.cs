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
          this Option<A> optionA,
           Func<A, Option<B>> collectionSelector,
           Func<A, B, C> resultSelector)
        {
            return optionA
                .SelectMany(a => collectionSelector(a)
                    .Select(b => resultSelector(a, b)));
        }
    }
}