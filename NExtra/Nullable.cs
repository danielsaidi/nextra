namespace NExtra
{
	/// <summary>
	/// This class can be used to make non-nullable types
	/// behave like nullable structs, like int? and bool?
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	/// <typeparam name="T">The type that is handled by the class.</typeparam>
	public class Nullable<T> where T : class
	{
        public Nullable()
        {
        }

        public Nullable(T value)
        {
            Value = value;
        }


		public T Value { get; set; }

		public bool HasValue
		{
			get { return Value != null; }
		}
	}
}
