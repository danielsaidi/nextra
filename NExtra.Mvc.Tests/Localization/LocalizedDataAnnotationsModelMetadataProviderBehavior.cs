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
        private ITranslator translator;
        private ProviderWrapper provider;


        [SetUp]
        public void SetUp()
        {
            translator = Substitute.For<ITranslator>();
            translator.Translate(GetPropertyResourceKey()).Returns("bar");
            translator.Translate(GetValidationAttributeResourceKey()).Returns("bar");
            translator.TranslationExists(GetPropertyResourceKey()).Returns(true);
            translator.TranslationExists(Arg.Is<string>(x => x != GetPropertyResourceKey())).Returns(false);
            translator.TranslationExists(GetValidationAttributeResourceKey()).Returns(true);
            translator.TranslationExists(Arg.Is<string>(x => x != GetValidationAttributeResourceKey())).Returns(false);

            provider = new ProviderWrapper(translator, true, "_");
        }

        private ModelMetadata CreateModelMetadata()
        {
            return new ModelMetadata(provider, typeof (MetadataTestClass), null, typeof (MetadataTestClass), "Name");
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
            provider = new ProviderWrapper(translator, false, "-");
        }


        [Test]
        public void Constructor_ShouldInitializeObject()
        {
            Assert.That(provider.DotReplacement, Is.EqualTo("_"));
            Assert.That(provider.OverrideMode, Is.EqualTo(true));
            Assert.That(provider.Translator, Is.EqualTo(translator));
        }


        [Test]
        public void GetDisplayNameLanguageKey_ShouldApplyDefaultDotReplacement()
        {
            var result = provider.GetDisplayNameLanguageKey(typeof(MetadataTestClass), "Name");

            Assert.That(result, Is.EqualTo("NExtra_Mvc_Tests_Localization_LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass_Name"));
        }

        [Test]
        public void GetDisplayNameLanguageKey_ShouldApplyCustomDotReplacement()
        {
            provider = new ProviderWrapper(translator, true, "-");

            var result = provider.GetDisplayNameLanguageKey(typeof(MetadataTestClass), "Name");

            Assert.That(result, Is.EqualTo("NExtra-Mvc-Tests-Localization-LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass-Name"));
        }

        [Test]
        public void GetErrorMessageLanguageKey_ShouldApplyDefaultDotReplacement()
        {
            var result = provider.GetErrorMessageLanguageKey(typeof(MetadataTestClass), "Name", "Required");

            Assert.That(result, Is.EqualTo("NExtra_Mvc_Tests_Localization_LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass_Name_RequiredError"));
        }

        [Test]
        public void GetErrorMessageLanguageKey_ShouldApplyCustomDotReplacement()
        {
            provider = new ProviderWrapper(translator, true, "-");

            var result = provider.GetErrorMessageLanguageKey(typeof(MetadataTestClass), "Name", "Required");

            Assert.That(result, Is.EqualTo("NExtra-Mvc-Tests-Localization-LocalizedDataAnnotationsModelMetadataProviderBehavior+MetadataTestClass-Name-RequiredError"));
        }

        [Test]
        public void HandleDisplayName_ShouldAlwaysCallTranslationExists()
        {
            var meta = CreateModelMetadata();

            provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            translator.Received().TranslationExists(GetTypeResourceKey() + "_foo");
        }

        [Test]
        public void HandleDisplayName_ShouldNotHandleDisplayNameForNoTranslationAndNoOverride()
        {
            SetupNonOverrideProvider();
            var meta = CreateModelMetadata();
            meta.DisplayName = "unhandled";

            provider.TestHandleDisplayName(typeof(MetadataTestClass), "bar", meta);

            translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(meta.DisplayName, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleDisplayName_ShouldNotHandleDisplayNameForTranslationButNoOverride()
        {
            SetupNonOverrideProvider();
            var meta = CreateModelMetadata();
            meta.DisplayName = "unhandled";

            provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(meta.DisplayName, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleDisplayName_ShouldNotHandleDisplayNameForOverrideButNoTranslation()
        {
            var meta = CreateModelMetadata();
            
            provider.TestHandleDisplayName(typeof(MetadataTestClass), "bar", meta);

            translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(meta.DisplayName, Is.EqualTo("[[" + GetPropertyResourceKey().Replace("foo", "bar") + "]]"));
        }

        [Test]
        public void HandleDisplayName_ShouldHandleDisplayNameForTranslationAndOverride()
        {
            var meta = CreateModelMetadata();
            meta.DisplayName = "unhandled";

            translator.TranslationExists(GetPropertyResourceKey()).Returns(true);

            provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            translator.Received().Translate(GetPropertyResourceKey());
            Assert.That(meta.DisplayName, Is.EqualTo("bar"));
        }

        [Test]
        public void HandleDisplayName_ShouldSetMissingDataFormatForNoDisplayNameAndNoHandling()
        {
            SetupNonOverrideProvider();
            var meta = CreateModelMetadata();

            provider.TestHandleDisplayName(typeof(MetadataTestClass), "foo", meta);

            Assert.That(meta.DisplayName, Is.EqualTo("[[" + GetPropertyResourceKey().Replace("_", "-") + "]]"));
        }

        [Test]
        public void HandleErrorMessage_ShouldAlwaysCallTranslationExists()
        {
            var attribute = CreateValidationAttribute();

            provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

            translator.Received().TranslationExists(GetPropertyResourceKey() + "_ValidationAttributeTestClassError");
        }

        [Test]
        public void HandleErrorMessage_ShouldNotHandleErrorMessageForNoTranslationAndNoOverride()
        {
            SetupNonOverrideProvider();

            var attribute = CreateValidationAttribute();
            attribute.ErrorMessage = "unhandled";

            provider.TestHandleErrorMessage(typeof(MetadataTestClass), "bar", attribute);

            translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleErrorMessage_ShouldNotHandleErrorMessageForTranslationButNoOverride()
        {
            SetupNonOverrideProvider();

            var attribute = CreateValidationAttribute();
            attribute.ErrorMessage = "unhandled";

            provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

            translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("unhandled"));
        }

        [Test]
        public void HandleErrorMessage_ShouldNotHandleErrorMessageForOverrideButNoTranslation()
        {
            var attribute = CreateValidationAttribute();

            provider.TestHandleErrorMessage(typeof(MetadataTestClass), "bar", attribute);

            translator.DidNotReceive().Translate(Arg.Any<string>());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("[[" + GetPropertyResourceKey().Replace("foo", "bar_ValidationAttributeTestClassError") + "]]"));
        }

        [Test]
        public void HandleErrorMessage_ShouldHandleErrorMessageForTranslationAndOverride()
        {
            var attribute = CreateValidationAttribute();
            attribute.ErrorMessage = "unhandled";

            provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

            translator.Received().Translate(GetValidationAttributeResourceKey());
            Assert.That(attribute.ErrorMessage, Is.EqualTo("bar"));
        }

        [Test]
        public void HandleErrorMessage_ShouldSetMissingDataFormatForNoErrorMessageAndNoHandling()
        {
            SetupNonOverrideProvider();
            var attribute = CreateValidationAttribute();

            provider.TestHandleErrorMessage(typeof(MetadataTestClass), "foo", attribute);

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