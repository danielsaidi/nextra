using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using NExtra.Localization;

namespace NExtra.Mvc.Localization
{
    ///<summary>
    /// This class can be used instead of the default metadata
    /// provider. It will auto-translate properties as well as
    /// error messages for a model that is displayed in a view.
    ///</summary>
    /// <remarks>
    /// With this class, you do not have to decorate an entity
    /// with DisplayName or provide an ErrorMessage text for a
    /// validation attribute. The class uses a convention that
    /// it automatically applies to entities.
    /// 
    /// So, just provide translations that use this convention
    /// and your entities will (almost) translate themselves. 
    /// 
    /// The default key format that is used for DisplayName is:
    ///     [Type.FullName]_[PropertyName]
    ///     e.g. MyCoolProject_Domain_User_UserName
    /// 
    /// The default key format that's used for ErrorMessage is:
    ///     [Type.FullName]_[PropertyName]_[AttributeName]
    ///     e.g. MyCoolProject_Domain_User_UserName_RequiredError
    /// 
    /// Depending on which translator that is used, these keys
    /// can be translated in various ways. It depends on which
    /// ITranslator implementation you are using.
    /// 
    /// If overrideMode is set to true, already defined values
    /// for DisplayName and ErrorMessage will be overridden.
    /// 
    /// The dotReplacement will be used to convert the dots in
    /// the full name of a class or property. User.UserName is
    /// by default converted to Domain_User_UserName.
    /// 
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class LocalizedDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        ///<summary>
        /// Create an instance of the class.
        ///</summary>
        ///<param name="translator">The ITranslator to use when translating metadata.</param>
        ///<param name="overrideMode">Whether or not to override already defined metadata.</param>
        ///<param name="dotReplacement">The separator to use instead of dots.</param>
        public LocalizedDataAnnotationsModelMetadataProvider(ITranslator translator, bool overrideMode, string dotReplacement = "_")
        {
            OverrideMode = overrideMode;
            DotReplacement = dotReplacement;
            Translator = translator;
        }


        /// <summary>
        /// The separator to use instead of dots.
        /// </summary>
        public string DotReplacement { get; private set; }

        /// <summary>
        /// Whether or not the provider will override already defined metadata.
        /// </summary>
        public bool OverrideMode { get; private set; }

        /// <summary>
        /// The ITranslator implementation to use when translating metadata.
        /// </summary>
        public ITranslator Translator { get; private set; }

        /// <summary>
        /// Create metadata for the specifie property.
        /// </summary>
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var meta = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (string.IsNullOrEmpty(propertyName))
                return meta;

            HandleDisplayName(meta, containerType, propertyName);
            HandleValidationAttributes(containerType, propertyName, attributes);

            return meta;
        }


        /// <summary>
        /// Retrieve the language key for the display name for
        /// a property. This key will be used when translating
        /// the property display name with the translator.
        /// </summary>
        public virtual string GetDisplayNameLanguageKey(Type type, string propertyName)
        {
            var fullPropertyName = String.Format("{0}.{1}", type.FullName, propertyName);
            return fullPropertyName.Replace(".", DotReplacement);
        }

        /// <summary>
        /// Retrieve the language key for an error message. This
        /// key will be used when translating a validation error
        /// message with the translator.
        /// </summary>
        public virtual string GetErrorMessageLanguageKey(Type type, string propertyName, string validationAttributeName)
        {
            var fullErrorName = String.Format("{0}.{1}.{2}Error", type.FullName, propertyName, validationAttributeName);
            return fullErrorName.Replace(".", DotReplacement);
        }

        /// <summary>
        /// Handle the display name of a metadata model.
        /// </summary>
        protected virtual void HandleDisplayName(ModelMetadata meta, Type type, string propertyName)
        {
            var languageKey = GetDisplayNameLanguageKey(type, propertyName);

            if (Translator.TranslationExists(languageKey) && OverrideMode)
                meta.DisplayName = Translator.Translate(languageKey);
            
            if (string.IsNullOrEmpty(meta.DisplayName))
                meta.DisplayName = string.Format("[[{0}]]", languageKey);
        }

        /// <summary>
        /// Handle the error message of a validation attribute.
        /// </summary>
        protected virtual void HandleErrorMessage(Type type, string propertyName, ValidationAttribute attribute)
        {
            var languageKey = GetErrorMessageLanguageKey(type, propertyName, attribute.GetType().Name);

            if (Translator.TranslationExists(languageKey) && OverrideMode)
                attribute.ErrorMessage = Translator.Translate(languageKey);

            if (string.IsNullOrEmpty(attribute.ErrorMessage))
                attribute.ErrorMessage = string.Format("[[{0}]]", languageKey);
        }

        /// <summary>
        /// Handle the error messages of multiple validation attribute.
        /// </summary>
        private void HandleValidationAttributes(Type type, string propertyName, IEnumerable<Attribute> attributes)
        {
            foreach (var validationAttribute in attributes.OfType<ValidationAttribute>())
            {
                HandleErrorMessage(type, propertyName, validationAttribute);
            }
        }
    }
}
