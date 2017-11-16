using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelValidationTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IObjectModelValidator _objectValidator;

        public UnitTest1()
        {
            _objectValidator = CreateValidator();
        }


        [TestMethod]
        public void TestSingle()
        {
            // Arrange
            var expected = false;
            ModelBase model = new Model { NumberA = 0 };

            var controllerContext = new ControllerContext();

            // Act
            _objectValidator.Validate(controllerContext, null, "", model);
            var actual = controllerContext.ModelState.IsValid;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiple()
        {
            // Arrange
            var expected = false;
            var models = new ModelBase[] { new Model { NumberA = 0 } };

            var controllerContext = new ControllerContext();

            // Act
            _objectValidator.Validate(controllerContext, null, "", models);
            var actual = controllerContext.ModelState.IsValid;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultipleForEach()
        {
            // Arrange
            var expected = false;
            var models = new ModelBase[] { new Model { NumberA = 0 } };

            var controllerContext = new ControllerContext();

            // Act
            foreach (var model in models)
            {
                _objectValidator.Validate(controllerContext, null, "", model);
            }
            var actual = controllerContext.ModelState.IsValid;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static DefaultObjectValidator CreateValidator(params IMetadataDetailsProvider[] providers)
        {
            var metadataProvider = TestModelMetadataProvider.CreateDefaultProvider(providers);
            var validatorProviders = TestModelValidatorProvider.CreateDefaultProvider().ValidatorProviders;
            return new DefaultObjectValidator(metadataProvider, validatorProviders);
        }
    }
}
