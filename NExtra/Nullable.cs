namespace NExtra
{
	/// <summary>
	/// This class can be used to make non-nullable reference types
	/// behave like nullable reference types, such as int? and bool?
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	/// <typeparam name="T">The type that is handled by the class.</typeparam>
	public class Nullable<T> where T : class
	{
        /// <summary>
        /// Create a class instance with no initial value.
        /// </summary>
        public Nullable()
        {
        }

        /// <summary>
        /// Create a class instance with an initial value.
        /// </summary>
        public Nullable(T value)
        {
            Value = value;
        }


		/// <summary>
		/// The object value, if any.
		/// </summary>
		public T Value { get; set; }

		/// <summary>
		/// Whether or not the Value property has a value.
		/// </summary>
		public bool HasValue
		{
			get { return Value != null; }
		}
	}
}
