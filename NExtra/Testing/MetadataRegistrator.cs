using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NExtra.Testing
{
	/// <summary>
	/// This class can be used when testing functionality that
	/// depends on MetadataTypes. Just run any of the Register
	/// methods when needed to register meta data types within
	/// one or several assemblies or for a certain type.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class MetadataRegistrator
	{
		private static readonly object registerLock = new object();
	    private static Dictionary<string, bool> registeredDictionary;


        /// <summary>
        /// Check whether or not a certain assembly is registered.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <returns>Whether or not the assembly is registered</returns>
        private static bool IsAssemblyRegistered(Assembly assembly)
        {
            if (registeredDictionary == null)
                registeredDictionary = new Dictionary<string, bool>();

            return registeredDictionary.ContainsKey(assembly.FullName);
        }


        /// <summary>
        /// Register all the MetadataType classes that are defined in
        /// the assemblies in AppDomain.CurrentDomain.GetAssemblies().
        /// </summary>
        public static void Register()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                Register(assembly);
        }

        /// <summary>
        /// Register all the MetadataType classes that are defined in
        /// a certain assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        public static void Register(Assembly assembly)
        {
            if (IsAssemblyRegistered(assembly))
                return;

            lock (registerLock)
            {
                if (IsAssemblyRegistered(assembly))
                    return;

                foreach (var type in assembly.GetTypes())
                    Register(type);

                registeredDictionary.Add(assembly.FullName, true);
            }
        }

        /// <summary>
        /// Register the MetadataType class for a certain type.
        /// </summary>
        /// <param name="type">The type of interest.</param>
        public static void Register(Type type)
        {
            foreach (MetadataTypeAttribute attrib in type.GetCustomAttributes(typeof(MetadataTypeAttribute), true))
                TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(type, attrib.MetadataClassType), type);
        }
	}


    /// <summary>
    /// 
    /// </summary>
    [Obsolete("Use MetadataRegistrator instead.")]
    public class MetadataTypeRegistrator : MetadataRegistrator {}
}
