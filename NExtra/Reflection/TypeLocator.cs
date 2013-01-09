using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NExtra.Extensions;

namespace NExtra.Reflection
{
    /// <summary>
    /// This class can be used to find all types in one or
    /// several assemblies, that inherit a certain type or
    /// implement a certain interface.
    /// </summary>
    /// <remarks>
    /// Author:     Niklas Melinder [niklas@melinder.se]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class TypeLocator<TType> : ITypeLocator<TType>
    {
        private readonly Assembly[] _assemblies;


        /// <summary>
        /// Create an instance of the class, using a list of assemblies.
        /// </summary>
        public TypeLocator(params Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }


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
