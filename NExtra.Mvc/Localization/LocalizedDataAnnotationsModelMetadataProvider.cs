using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using NExtra.Localization.Abstractions;

namespace NExtra.Mvc.Localization
{
    ///<summary>
    /// This class can be used instead of the default metadata
    /// provider. It will auto-translate properties as well as
    /// error messages that are displayed witin a view.
    ///</summary>
    /// <remarks>
    /// If overrideMode is set to true, already defined values
    /// for DisplayName and ErrorMessage will be overridden by
    /// the provider. If overrideMode is set to false, however,
    /// already defined metadata will be preserved.
    /// 
    /// The dotReplacement will be used to convert the dots in
    /// the full name of a class or property. User.UserName is
    /// by default converted to Domain_User_UserName.
    /// 
    /// The default key format that is used for DisplayName is:
    ///     [Type.FullName]_[PropertyName]
    ///     e.g. MyCoolProject_Domain_User_UserName
    /// 
    /// For validation attributes, the default key format that
    /// is used to as ErrorMessage is:
    ///     [Type.FullName]_[PropertyName]_[AttributeName]
    ///     e.g. MyCoolProject_Domain_User_UserName_Required
    /// 
    /// Depending on which translator that is used, these keys
    /// can be translated in various ways. For instance, using
    /// the HierarchicalResourceManagerFacade 
    /// 
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class LocalizedDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        ///<summary>
        /// Create an instance of the class.
        ///</summary>
        ///<param name="translator">The ITranslator implementation to use when translating metadata.</param>
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
        /// Retrieve the language key for the display name for
        /// a property. This key will be used when translating
        /// the property displayname with the translator.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The resulting resource key.</returns>
        protected virtual string GetDisplayNameLanguageKey(Type type, string propertyName)
        {
            var fullPropertyName = String.Format("{0}.{1}", type.FullName, propertyName);
            return fullPropertyName.Replace(".", DotReplacement);
        }

        /// <summary>
        /// Retrieve the language key for an error message. This
        /// key will be used when translating a validation error
        /// message with the translator.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The resulting resource key.</returns>
        protected virtual string GetErrorMessageLanguageKey(Type type, string propertyName, string attributeName)
        {
            var fullErrorName = String.Format("{0}.{1}.{2}Error", type.FullName, propertyName, attributeName);
            return fullErrorName.Replace(".", DotReplacement);
        }

        /// <summary>
        /// Handle the display name of a metadata model.
        /// </summary>
        /// <param name="meta">The metadata model to affect.</param>
        /// <param name="type">The type to translate.</param>
        /// <param name="propertyName">The name of the property to translate.</param>
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
        /// <param name="type">The type to translate.</param>
        /// <param name="propertyName">The name of the property to translate.</param>
        /// <param name="attribute">The validation attribute to affect.</param>
        protected virtual void HandleErrorMessage(Type type, string propertyName, ValidationAttribute attribute)
        {
            var languageKey = GetErrorMessageLanguageKey(type, propertyName, attribute.GetType().Name);

            if (Translator.TranslationExists(languageKey) && OverrideMode)
                attribute.ErrorMessage = Translator.Translate(languageKey);

            if (string.IsNullOrEmpty(attribute.ErrorMessage))
                attribute.ErrorMessage = string.Format("[[{0}]]", languageKey);
        }





        //TODO: TEST----------------------------

        private void HandleValidationAttributes(Type type, string propertyName, IEnumerable<Attribute> attributes)
        {
            foreach (var validationAttribute in attributes.OfType<ValidationAttribute>())
            {
                HandleErrorMessage(type, propertyName, validationAttribute);
            }
        }

        /// <summary>
        /// Gets the metadata for the specifie property.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="containerType">The type of container.</param>
        /// <param name="modelAccessor">The model accessor.</param>
        /// <param name="modelType">The model type.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The resulting model metadata.</returns>
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var meta = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (string.IsNullOrEmpty(propertyName))
                return meta;

            HandleDisplayName(meta, containerType, propertyName);
            HandleValidationAttributes(containerType, propertyName, attributes);

            return meta;
        }
    }
}
