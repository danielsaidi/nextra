using System;

namespace NExtra
{
    /// <summary>
    /// This class is a generic version of the native System.EventArgs.
    /// It embeds an object that can be accessed within a raised event.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
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
