using System;

namespace NExtra
{
    /// <summary>
    /// This class is a generic version of the native System.EventArgs.
    /// It embeds an object that can be accessed within a raised event.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    /// <typeparam name="T">The type to embed.</typeparam>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="obj">The object to embed.</param>
        public EventArgs(T obj)
        {
            Object = obj;
        }

        /// <summary>
        /// The embedded object.
        /// </summary>
        public T Object { get; private set; }
    }
}
