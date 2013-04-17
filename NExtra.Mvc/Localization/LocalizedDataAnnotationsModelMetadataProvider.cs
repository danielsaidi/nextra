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
    /// provider specified in Global.asax. It is automatically 
    /// translates property display values and all model error
    /// messages, using a resource file.
    ///</summary>
    /// <remarks>
    /// With this class, you do not have to decorate an entity
    /// with DisplayName or provide an ErrorMessage text for a
    /// validation attribute. The class uses a convention that
    /// it automatically applies.
    /// 
    /// So, just provide translations that use this convention
    /// and your entities will translate themselves.
    /// 
    /// The default key format that is used for DisplayName is:
    ///     [Type.FullName]_[PropertyName]
    ///     e.g. MyCoolProject_User_UserName
    /// 
    /// The default key format that's used for ErrorMessage is:
    ///     [Type.FullName]_[PropertyName]_[AttributeName]
    ///     e.g. MyCoolProject_User_UserName_RequiredError
    /// 
    /// Depending on which ITranslator implementation that the
    /// class is given, these keys are translated in different
    /// ways. If you look in NExtra.Localization, you have two
    /// translators there that you can use.
    /// 
    /// If overrideMode is set to true, already defined values
    /// for DisplayName and ErrorMessage are overridden. If it
    /// is set to false, the original values will be kept.
    /// 
    /// The dotReplacement will be used to convert the dots in
    /// the full name of a class or property. User.UserName is
    /// by default converted to User_UserName.
    /// 
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class LocalizedDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
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

        public bool OverrideMode { get; private set; }

        public ITranslator Translator { get; private set; }


        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var meta = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (string.IsNullOrEmpty(propertyName))
                return meta;

            HandleDisplayName(meta, containerType, propertyName);
            HandleValidationAttributes(containerType, propertyName, attributes);

            return meta;
        }

        public virtual string GetDisplayNameLanguageKey(Type type, string propertyName)
        {
            var fullPropertyName = String.Format("{0}.{1}", type.FullName, propertyName);
            return fullPropertyName.Replace(".", DotReplacement);
        }

        public virtual string GetErrorMessageLanguageKey(Type type, string propertyName, string validationAttributeName)
        {
            var fullErrorName = String.Format("{0}.{1}.{2}Error", type.FullName, propertyName, validationAttributeName);
            return fullErrorName.Replace(".", DotReplacement);
        }

        protected virtual void HandleDisplayName(ModelMetadata meta, Type type, string propertyName)
        {
            var languageKey = GetDisplayNameLanguageKey(type, propertyName);

            if (Translator.TranslationExists(languageKey) && OverrideMode)
                meta.DisplayName = Translator.Translate(languageKey);
            
            if (string.IsNullOrEmpty(meta.DisplayName))
                meta.DisplayName = string.Format("[[{0}]]", languageKey);
        }

        protected virtual void HandleErrorMessage(Type type, string propertyName, ValidationAttribute attribute)
        {
            var languageKey = GetErrorMessageLanguageKey(type, propertyName, attribute.GetType().Name);

            if (Translator.TranslationExists(languageKey) && OverrideMode)
                attribute.ErrorMessage = Translator.Translate(languageKey);

            if (string.IsNullOrEmpty(attribute.ErrorMessage))
                attribute.ErrorMessage = string.Format("[[{0}]]", languageKey);
        }

        private void HandleValidationAttributes(Type type, string propertyName, IEnumerable<Attribute> attributes)
        {
            foreach (var validationAttribute in attributes.OfType<ValidationAttribute>())
            {
                HandleErrorMessage(type, propertyName, validationAttribute);
            }
        }
    }
}
