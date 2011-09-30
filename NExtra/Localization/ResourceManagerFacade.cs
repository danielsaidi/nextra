using System.Globalization;
using System.Resources;
using System.Threading;
using NExtra.Localization.Abstractions;

namespace NExtra.Localization
{
    ///<summary>
    /// This class can be used to translate language keys
    /// using a resource file. It requires an exact match
    /// to translate a language key.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class ResourceManagerFacade : ITranslator
    {
        private readonly ResourceManager resourceManager;


        /// <summary>
        /// Create an instance of the class using the
        /// ResourceManager manager of auto-generated,
        /// strongly-typed resource classes.
        /// </summary>
        /// <param name="resourceManager">The ResourceManager instance to use.</param>
        public ResourceManagerFacade(ResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }


        /// <summary>
        /// Translate a certain language key for the current culture.
        /// </summary>
        /// <param name="key">The language key to translate.</param>
        /// <returns>The translated result.</returns>
        public virtual string Translate(string key)
        {
            return Translate(key, Thread.CurrentThread.CurrentUICulture);
        }

        ///<summary>
        /// Translate a certain language key for a certain culture.
        ///</summary>
        /// <param name="key">The language key to translate.</param>
        ///<param name="cultureInfo">The culture to use.</param>
        /// <returns>The translated result.</returns>
        public virtual string Translate(string key, CultureInfo cultureInfo)
        {
            return resourceManager.GetString(key, cultureInfo);
        }
        
        /// <summary>
        /// Check whether or not a translation exists for
        /// a certain language key and the current culture.
        /// </summary>
        /// <param name="key">The language key of interest.</param>
        /// <returns>Whether or not a translation exists.</returns>
        public bool TranslationExists(string key)
        {
            return TranslationExists(key, Thread.CurrentThread.CurrentUICulture);
        }

        public bool TranslationExists(string key, CultureInfo cultureInfo)
        {
            return Translate(key, cultureInfo) != null;
        }
    }
}
