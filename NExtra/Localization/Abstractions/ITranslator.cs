using System.Globalization;

namespace NExtra.Localization.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to translate language keys, e.g. from a resource
    /// or XML file.
    /// </summary>
    public interface ITranslator
    {
        /// <summary>
        /// Translate a certain language key for the current culture.
        /// </summary>
        /// <param name="key">The language key to translate.</param>
        /// <returns>The translated result.</returns>
        string Translate(string key);

        ///<summary>
        /// Translate a certain language key for a certain culture info.
        ///</summary>
        /// <param name="key">The language key to translate.</param>
        ///<param name="cultureInfo">The culture to use.</param>
        /// <returns>The translated result.</returns>
        string Translate(string key, CultureInfo cultureInfo);

        /// <summary>
        /// Check whether or not a translation exists for
        /// a certain language key and the current culture.
        /// </summary>
        /// <param name="key">The language key of interest.</param>
        /// <returns>Whether or not a translation exists.</returns>
        bool TranslationExists(string key);

        /// <summary>
        /// Check whether or not a translation exists for
        /// a certain language key and the current culture.
        /// </summary>
        /// <param name="key">The language key of interest.</param>
        ///<param name="cultureInfo">The culture of interest.</param>
        /// <returns>Whether or not a translation exists.</returns>
        bool TranslationExists(string key, CultureInfo cultureInfo);
    }
}
