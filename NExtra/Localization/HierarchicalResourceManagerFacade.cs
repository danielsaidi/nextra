using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace NExtra.Localization
{
    ///<summary>
    /// This class can be used to translate language keys
    /// using a resource file. Unlike its base class, the
    /// class will strip provided language keys, piece by
    /// piece until it finds a translation, if one exists.
    ///</summary>
    /// <remarks>
    /// For instance, if Domain_User_UserName is provided,
    /// the class will first attempt to translate it with
    /// no stripping. If no translation is found, it will
    /// attempt to translate User_UserName, then UserName.
    /// 
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class HierarchicalResourceManagerFacade : ResourceManagerFacade
    {
        private readonly string keySeparator = "_";


        /// <summary>
        /// Create an instance of the class using the
        /// ResourceManager manager of auto-generated,
        /// strongly-typed resource classes.
        /// </summary>
        /// <param name="resourceManager">The ResourceManager instance to use.</param>
        /// <param name="keySeparator">The separator to use when splitting up resource keys into sub keys.</param>
        public HierarchicalResourceManagerFacade(ResourceManager resourceManager, string keySeparator = "_")
            : base(resourceManager)
        {
            this.keySeparator = keySeparator;
        }


        /// <summary>
        /// Retrieve all translation keys for a certain key.
        /// For instance, "User_UserName" will result in an
        /// IEnumerable with "User" and "UserName".
        /// </summary>
        /// <param name="key">The original translation key.</param>
        /// <returns>The resulting translation keys.</returns>
        public IEnumerable<string> GetKeys(string key)
        {
            var result = new List<string>();

            while (true)
            {
                result.Add(key);

                if (key.IndexOf(keySeparator) < 0)
                    break;

                key = key.Substring(key.IndexOf(keySeparator) + 1);
            }

            return result;
        }

        /// <summary>
        /// Translate a certain language key for the current culture.
        /// </summary>
        /// <param name="key">The language key to translate.</param>
        /// <returns>The translated result.</returns>
        public override string Translate(string key)
        {
            return Translate(key, Thread.CurrentThread.CurrentUICulture);
        }

        ///<summary>
        /// Translate a certain language key for a certain culture.
        ///</summary>
        /// <param name="key">The language key to translate.</param>
        ///<param name="cultureInfo">The culture to use.</param>
        /// <returns>The translated result.</returns>
        public override string Translate(string key, CultureInfo cultureInfo)
        {
            var currentVerb = key;

            while (true)
            {
                var result = base.Translate(currentVerb, cultureInfo);
                if (result != null)
                    return result;

                if (currentVerb.IndexOf(keySeparator) < 0)
                    return null;

                currentVerb = currentVerb.Substring(currentVerb.IndexOf(keySeparator) + 1);
            }
        }
    }
}
