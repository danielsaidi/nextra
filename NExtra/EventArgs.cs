using System;

namespace NExtra
{
    /// <summary>
    /// This is a typed version of System.EventArgs that
    /// embeds an object within a raised event.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T obj)
        {
            Object = obj;
        }

        public T Object { get; private set; }
    }
}
