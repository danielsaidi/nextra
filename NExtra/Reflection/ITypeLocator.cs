using System.Collections.Generic;

namespace NExtra.Reflection
{
    /// <summary>
    /// Interface that can be implemented by classes
    /// that are used to find all types that implement
    /// a specific interface. 
    /// </summary>
    /// <typeparam name="TType">The interface type to find.</typeparam>
    public interface ITypeLocator<out TType>
    {
        IEnumerable<TType> FindAll();
    }
}
