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
        string Translate(string key);

        ///<summary>
        /// Translate a certain language key for a certain culture.
        ///</summary>
        string Translate(string key, CultureInfo cultureInfo);

        /// <summary>
        /// Check whether or not a translation exists for
        /// a certain language key and the current culture.
        /// </summary>
        bool TranslationExists(string key);

        /// <summary>
        /// Check whether or not a translation exists for
        /// a certain language key and culture.
        /// </summary>
        bool TranslationExists(string key, CultureInfo cultureInfo);
    }
}
