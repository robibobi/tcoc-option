namespace Tcoc.OptionType
{
    public class Some<T> : Option<T>
    {
        public T Value { get; }

        internal Some(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Some<{typeof(T).Name}>: {Value}";
        }
    }
}
