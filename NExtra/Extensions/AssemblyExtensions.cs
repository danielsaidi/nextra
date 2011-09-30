using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.Reflection.Assembly.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class AssemblyExtensions
	{
	    /// <summary>
		/// Get the company name of a certain assembly.
		/// </summary>
		/// <param name="assembly">Assembly instance.</param>
		/// <returns>The company name of the assembly.</returns>
		public static string GetCompanyName(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
		}

		/// <summary>
		/// Get the copyright holder of a certain assembly.
		/// </summary>
		/// <param name="assembly">Assembly instance.</param>
		/// <returns>The copyright holder of the assembly.</returns>
		public static string GetCopyrightHolder(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
		}

		/// <summary>
		/// Get the description of a certain assembly.
		/// </summary>
		/// <param name="assembly">Assembly instance.</param>
        /// <returns>The description of the assembly.</returns>
		public static string GetDescription(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
		}

        /// <summary>
        /// Get all namespaces that are defined within a certain assembly.
        /// </summary>
        /// <param name="assembly">Assembly instance.</param>
        /// <returns>All namespaces that are defined within the assembly.</returns>
        public static IList<string> GetNamespaces(this Assembly assembly)
        {
            var types = assembly.GetTypes();
            var result = new List<string>();

            foreach (var type in types.Where(type => !result.Contains(type.Namespace)))
                result.Add(type.Namespace);

            return result.OrderBy(ns => ns).ToList();
        }

	    /// <summary>
        /// Get all types that belong to a certain namespace.
        /// </summary>
        /// <param name="assembly">Assembly instance.</param>
        /// <param name="namespace">The name of the namespace</param>
        /// <returns>All types that belong to the namespace.</returns>
        public static IList<Type> GetNamespaceTypes(this Assembly assembly, string @namespace)
        {
            return (from type in assembly.GetTypes() where type.Namespace == @namespace select type).ToList();
        }

	    /// <summary>
		/// Get the product name of a certain assembly.
		/// </summary>
		/// <param name="assembly">Assembly instance.</param>
        /// <returns>The product name of the assembly.</returns>
		public static string GetProductName(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
		}

		/// <summary>
		/// Get the title of a certain assembly.
		/// </summary>
		/// <param name="assembly">Assembly instance.</param>
        /// <returns>The title of the assembly.</returns>
		public static string GetTitle(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
			return attributes.Length == 0 ? Path.GetFileNameWithoutExtension(assembly.CodeBase) : ((AssemblyTitleAttribute)attributes[0]).Title;
		}

        /// <summary>
        /// Get all types within a certain assembly that inherit a certain base type.
        /// </summary>
        /// <param name="assembly">Assembly of interest.</param>
        /// <param name="baseType">The base type.</param>
        /// <returns>All types within the assembly that inherit the base type.</returns>
        public static IEnumerable<Type> GetTypesThatInherit(this Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(type => type.IsSubclassOf(baseType));
        }

        /// <summary>
        /// Get all types within certain assemblies that inherit a certain base type.
        /// </summary>
        /// <param name="assemblies">Assemblies of interest.</param>
        /// <param name="baseType">The base type.</param>
        /// <returns>All types within the assemblies that inherit the base type.</returns>
        public static IEnumerable<Type> GetTypesThatInherit(this IEnumerable<Assembly> assemblies, Type baseType)
        {
            var result = new List<Type>();

            foreach (var assembly in assemblies)
                result.AddRange(assembly.GetTypesThatInherit(baseType));

            return result;
        }

        /// <summary>
        /// Get all types within a certain assembly that implement a certain interface.
        /// </summary>
        /// <param name="assembly">Assembly of interest.</param>
        /// <param name="interface">The interface of interest.</param>
        /// <returns>All types within the assembly that implement the interface.</returns>
        public static IEnumerable<Type> GetTypesThatImplement(this Assembly assembly, Type @interface)
        {
            return assembly.GetTypes().Where(type => @interface.IsAssignableFrom(type) && @interface.FullName != type.FullName);
        }

        /// <summary>
        /// Get all types within certain assemblies that implement a certain interface.
        /// </summary>
        /// <param name="assemblies">Assemblies of interest.</param>
        /// <param name="interface">The interface of interest.</param>
        /// <returns>All types within the assemblies that implement the interface.</returns>
        public static IEnumerable<Type> GetTypesThatImplement(this IEnumerable<Assembly> assemblies, Type @interface)
        {
            var result = new List<Type>();

            foreach (var assembly in assemblies)
                result.AddRange(assembly.GetTypesThatImplement(@interface));

            return result;
        }

	    /// <summary>
		/// Get the version of a certain assembly.
		/// </summary>
		/// <param name="assembly">Assembly instance.</param>
        /// <returns>The version of the assembly.</returns>
		public static Version GetVersion(this Assembly assembly)
		{
			return assembly.GetName().Version;
		}
	}
}
