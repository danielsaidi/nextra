using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NExtra.Localization;
using NExtra.Mvc.Localization;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Mvc.Tests.Localization
{
    [TestFixture]
    public class LocalizedDataAnnotationsModelMetadataProviderBehavior
    {
        private ITranslator _translator;
        private ProviderWrapper _provider;


        [SetUp]
        public void SetUp()
        {
            _translator = Substitute.For<ITranslator>();
            _translator.Translate(GetPropertyResourceKey()).Returns("bar");
            _translator.Translate(GetValidationAttributeResourceKey()).Returns("bar");
            _translator.TranslationExists(GetPropertyResourceKey()).Returns(true);
            _translator.TranslationExists(Arg.Is<string>(x => x != GetPropertyResourceKey())).Returns(false);
            _translator.TranslationExists(GetValidationAttributeResourceKey()).Returns(true);
            _translator.TranslationExists(Arg.Is<string>(x => x != GetValidationAttributeResourceKey())).Returns(false);

            _provider = new ProviderWrapper(_translator, true, "_");
        }

        private ModelMetadata CreateModelMetadata()
        {
            return new ModelMetadata(_provider, typeof (MetadataTestClass), null, typeof (MetadataTestClass), "Name");
        }

        private static ValidationAttributeTestClass CreateValidationAttribute()
        {
            return new ValidationAttributeTestClass();
        }

        private static string GetPropertyResourceKey()
        {
            return GetTypeResourceKey() + "_foo";
        }

        private static string GetTypeResourceKey()
        {
            return typeof(MetadataTestClass).FullName.Replace(".", "_");
        }

        private static string GetValidationAttributeResourceKey()
        {
            return GetPropertyResourceKey() + "_ValidationAttributeTestClassError";
        }

        private void SetupNonOverrideProvider()
        {
            _provider = new ProviderWrapper(_translator, false, "-");
        }


        [Test]
        public void Constructor_ShouldInitializeObject()
        {
            Assert.That(_provider.DotReplacement, Is.EqualTo("_"));
            Assert.That(_provider.OverrideMode, Is.EqualTo(true));
            Assert.That(_provider.Translator, Is.EqualTo(_translator));
        }


        [Test]
        public void GetDisplayNameLanguageKey_ShouldApplyDefaultDotReplacement()
        {
            var result = _provider.GetDisplayNameLanguageKey(typeof(MetadataTestClass), "Name");

            Assert.That(result, Is.EqualTo("NExtra_Mvc_Tests_Localization_LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass_Name"));
        }

        [Test]
        public void GetDisplayNameLanguageKey_ShouldApplyCustomDotReplacement()
        {
            _provider = new ProviderWrapper(_translator, true, "-");

            var result = _provider.GetDisplayNameLanguageKey(typeof(MetadataTestClass), "Name");

            Assert.That(result, Is.EqualTo("NExtra-Mvc-Tests-Localization-LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass-Name"));
        }

        [Test]
        public void GetErrorMessageLanguageKey_ShouldApplyDefaultDotReplacement()
        {
            var result = _provider.GetErrorMessageLanguageKey(typeof(MetadataTestClass), "Name", "Required");

            Assert.That(result, Is.EqualTo("NExtra_Mvc_Tests_Localization_LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass_Name_RequiredError"));
        }

        [Test]
        public void GetErrorMessageLanguageKey_ShouldApplyCustomDotReplacement()
        {
            _provider = new ProviderWrapper(_translator, true, "-");

            var result = _provider.GetErrorMessageLanguageKey(typeof(MetadataTestClass), "Name", "Required");

            Assert.That(result, Is.EqualTo("NExtra-Mvc-Tests-Localization-LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass-Name-RequiredError"));
        }

        [Test]
        public void HandleDisplayName_ShouldAlwaysCallTranslationExists()
        {
            var meta = CreateModelMetadata();

            _provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            _translator.Received().TranslationExists(GetTypeResourceKey() + "_foo");
        }

        [Test]
        public void HandleDisplayName_ShouldNotHandleDisplayNameForNoTranslationAndNoOverride()
        {
            SetupNonOverrideProvider();
            var meta = CreateModelMetadata();
            meta.DisplayName = "unhandled";

            _provider.TestHandleDisplayName(typeof(MetadataTestClass), "bar", meta);

            _translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(meta.DisplayName, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleDisplayName_ShouldNotHandleDisplayNameForTranslationButNoOverride()
        {
            SetupNonOverrideProvider();
            var meta = CreateModelMetadata();
            meta.DisplayName = "unhandled";

            _provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            _translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(meta.DisplayName, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleDisplayName_ShouldNotHandleDisplayNameForOverrideButNoTranslation()
        {
            var meta = CreateModelMetadata();
            
            _provider.TestHandleDisplayName(typeof(MetadataTestClass), "bar", meta);

            _translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(meta.DisplayName, Is.EqualTo("[[" + GetPropertyResourceKey().Replace("foo", "bar") + "]]"));
        }

        [Test]
        public void HandleDisplayName_ShouldHandleDisplayNameForTranslationAndOverride()
        {
            var meta = CreateModelMetadata();
            meta.DisplayName = "unhandled";

            _translator.TranslationExists(GetPropertyResourceKey()).Returns(true);

            _provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            _translator.Received().Translate(GetPropertyResourceKey());
            Assert.That(meta.DisplayName, Is.EqualTo("bar"));
        }

        [Test]
        public void HandleDisplayName_ShouldSetMissingDataFormatForNoDisplayNameAndNoHandling()
        {
            SetupNonOverrideProvider();
            var meta = CreateModelMetadata();

            _provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            Assert.That(meta.DisplayName, Is.EqualTo("[[" + GetPropertyResourceKey().Replace("_", "-") + "]]"));
        }

        [Test]
        public void HandleErrorMessage_ShouldAlwaysCallTranslationExists()
        {
            var attribute = CreateValidationAttribute();

            _provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

            _translator.Received().TranslationExists(GetPropertyResourceKey() + "_ValidationAttributeTestClassError");
        }

        [Test]
        public void HandleErrorMessage_ShouldNotHandleErrorMessageForNoTranslationAndNoOverride()
        {
            SetupNonOverrideProvider();

            var attribute = CreateValidationAttribute();
            attribute.ErrorMessage = "unhandled";

            _provider.TestHandleErrorMessage(typeof(MetadataTestClass), "bar", attribute);

            _translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleErrorMessage_ShouldNotHandleErrorMessageForTranslationButNoOverride()
        {
            SetupNonOverrideProvider();

            var attribute = CreateValidationAttribute();
            attribute.ErrorMessage = "unhandled";

            _provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

            _translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleErrorMessage_ShouldNotHandleErrorMessageForOverrideButNoTranslation()
        {
            var attribute = CreateValidationAttribute();

            _provider.TestHandleErrorMessage(typeof(MetadataTestClass), "bar", attribute);

            _translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("[[" + GetPropertyResourceKey().Replace("foo", "bar_ValidationAttributeTestClassError") + "]]"));
        }

        [Test]
        public void HandleErrorMessage_ShouldHandleErrorMessageForTranslationAndOverride()
        {
            var attribute = CreateValidationAttribute();
            attribute.ErrorMessage = "unhandled";

            _provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

            _translator.Received().Translate(GetValidationAttributeResourceKey());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("bar"));
        }

        [Test]
        public void HandleErrorMessage_ShouldSetMissingDataFormatForNoErrorMessageAndNoHandling()
        {
            SetupNonOverrideProvider();
            var attribute = CreateValidationAttribute();

            _provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

            Assert.That(attribute.ErrorMessage, Is.EqualTo("[[" + GetValidationAttributeResourceKey().Replace("_", "-") + "]]"));
        }



        private class MetadataTestClass {}

        private class ProviderWrapper : LocalizedDataAnnotationsModelMetadataProvider
        {
            public ProviderWrapper(ITranslator translator, bool overrideMode, string dotReplacement) : base(translator, overrideMode, dotReplacement) 
            {
            }

            public void TestHandleDisplayName(Type type, string propertyName, ModelMetadata meta)
            {
                base.HandleDisplayName(meta, type, propertyName);
            }

            public void TestHandleErrorMessage(Type type, string propertyName, ValidationAttribute attribute)
            {
                base.HandleErrorMessage(type, propertyName, attribute);
            }
        }

        private class ValidationAttributeTestClass : ValidationAttribute {}
    }
}