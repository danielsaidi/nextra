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
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	public static class Assembly_Extensions
	{
	    /// <summary>
		/// Get the company name of a certain assembly.
		/// </summary>
		public static string GetCompanyName(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
		}

		/// <summary>
		/// Get the copyright holder of a certain assembly.
		/// </summary>
		public static string GetCopyrightHolder(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
		}

		/// <summary>
		/// Get the description of a certain assembly.
		/// </summary>
		public static string GetDescription(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
		}

        /// <summary>
        /// Get all namespaces that are defined within a certain assembly.
        /// </summary>
        public static IEnumerable<string> GetNamespaces(this Assembly assembly)
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
        public static IEnumerable<Type> GetNamespaceTypes(this Assembly assembly, string @namespace)
        {
            return (from type in assembly.GetTypes() where type.Namespace == @namespace select type).ToList();
        }

	    /// <summary>
		/// Get the product name of a certain assembly.
		/// </summary>
		public static string GetProductName(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
			return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
		}

		/// <summary>
		/// Get the title of a certain assembly.
		/// </summary>
		public static string GetTitle(this Assembly assembly)
		{
			var attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
			return attributes.Length == 0 ? Path.GetFileNameWithoutExtension(assembly.CodeBase) : ((AssemblyTitleAttribute)attributes[0]).Title;
		}

	    /// <summary>
		/// Get the version of a certain assembly.
		/// </summary>
		public static Version GetVersion(this Assembly assembly)
		{
			return assembly.GetName().Version;
		}
	}
}
