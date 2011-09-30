using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NExtra.Extensions;

namespace NExtra.Demo.Models
{
    public class AssemblyRepository
    {
        private static List<Assembly> demoAssemblies;


        /// <summary>
        /// Get all assemblies that are of interest to this web-based demo.
        /// </summary>
        /// <returns></returns>
        public List<Assembly> DemoAssemblies
        {
            get
            {
                if (demoAssemblies != null)
                    return demoAssemblies;

                demoAssemblies = new List<Assembly>
                {
                    Assembly.Load("NExtra"),
                    Assembly.Load("NExtra.Web"),
                    Assembly.Load("NExtra.Mvc")
                };

                return demoAssemblies;   
            }
        }

        /// <summary>
        /// Get all types that are of interest to this web-based demo.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<Type>> DemoTypes
        {
            get
            {
                var result = new Dictionary<string, IEnumerable<Type>>();

                foreach (var @assembly in DemoAssemblies)
                {
                    var tmpAssembly = @assembly;
                    var assemblyName = tmpAssembly.GetName().Name + ".";
                    var ignoreNameSpaces = Properties.Settings.Default.IgnoreNamespaceList.Cast<string>();

                    var allTypes = @assembly.GetNamespaces().SelectMany(@namespace => tmpAssembly.GetNamespaceTypes(@namespace));
                    var relevantTypes = allTypes.Where(type => ignoreNameSpaces.Where(ns => type.FullName.Contains(ns)).Count() == 0).ToList();
                    relevantTypes = relevantTypes.Where(type => type.IsPublic).ToList();

                    var rootTypes = relevantTypes.Where(x => !x.FullName.Replace(assemblyName, "").Contains(".")).OrderBy(x => x.FullName).ToList();
                    var subTypes = relevantTypes.Where(x => x.FullName.Replace(assemblyName, "").Contains(".")).OrderBy(x => x.FullName).ToList();
                    rootTypes.AddRange(subTypes);

                    var filteredTypes = rootTypes.Where(x => !x.FullName.Contains("<") && !x.FullName.Contains(".Abstractions."));
                    result.Add(@assembly.GetName().Name, filteredTypes);
                }

                return result;
            }
        }
    }
}