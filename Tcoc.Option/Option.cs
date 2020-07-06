namespace Tcoc.OptionType
{
    public interface Option<in T>
    {
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value)
        {
            return new Some<T>(value);
        }

        public static Option<T> None<T>()
        {
            return new None<T>();
        }

        public static Option<T> From<T>(T value) where T : class
        {
            if (value == null)
                return None<T>();
            else
                return Some(value);
        }
    }
   
}
