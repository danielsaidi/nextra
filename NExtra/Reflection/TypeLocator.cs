using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NExtra.Extensions;

namespace NExtra.Reflection
{
    /// <summary>
    /// This class can be used to find all types within a
    /// single assembly or several ones that implement an
    /// interface or inherits a base class.
    /// </summary>
    /// <remarks>
    /// Author:     Niklas Melinder [niklas@melinder.se]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class TypeLocator<TType> : ITypeLocator<TType>
    {
        private readonly Assembly[] _assemblies;


        /// <summary>
        /// Creates an instance of TypeLocator from an array of assemblies.
        /// </summary>
        /// <param name="assemblies">An array of assemblies to look in.</param>
        public TypeLocator(params Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }


        /// <summary>
        /// Finds all types implementing TType in provided array of assemblies.
        /// </summary>
        /// <returns>The interface type to find.</returns>
        public IEnumerable<TType> FindAll()
        {
            var implementations = new List<TType>();

            foreach (var assembly in _assemblies)
            {
                var types = assembly.GetTypesThatImplement(typeof(TType));
                implementations.AddRange(types.Select(routine => (TType)Activator.CreateInstance(routine)));
            }

            return implementations;
        }
    }
}
