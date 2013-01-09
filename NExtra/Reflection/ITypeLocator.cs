using System.Collections.Generic;

namespace NExtra.Reflection
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// find all types that implement an interface or inherit
    /// a certain base class.
    /// </summary>
    /// <remarks>
    /// Author:     Niklas Melinder [niklas@melinder.se]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ITypeLocator<out TType>
    {
        /// <summary>
        /// Finds all types implementing or inheriting TType.
        /// </summary>
        /// <returns>The interface or type to find.</returns>
        IEnumerable<TType> FindAll();
    }
}
