using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NExtra.Testing
{
	/// <summary>
	/// This class can be used to register metadata for a
	/// certain type, or for all all types in an assembly.
	/// By default, metadata is not registered within the
	/// test context, which may cause some things to be a
	/// bit hard to test.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	public static class MetadataRegistrator
	{
		private static readonly object registerLock = new object();
	    private static Dictionary<string, bool> registeredDictionary;


        /// <summary>
        /// Check whether or not a certain assembly is registered.
        /// </summary>
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
        public static void Register(Type type)
        {
            foreach (MetadataTypeAttribute attrib in type.GetCustomAttributes(typeof(MetadataTypeAttribute), true))
                TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(type, attrib.MetadataClassType), type);
        }
	}
}
