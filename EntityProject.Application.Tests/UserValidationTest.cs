using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EntittyProject.Application.UseCase;

namespace EntityProject.Application.Tests
{
    [TestClass]
    public class UserValidationTest
    {
        [TestMethod]
        public void PasswordValidation_ShouldReturnPassword_WhenIsValid()
        {
            // Arrange
            var userValidation = new CreatUser();
            var password = "test1234@";
            // Act
            var result = userValidation.PasswordValidation(password);
            // Assert
            Assert.AreEqual("test1234@", result);
        }

        [TestMethod]
        public void PasswordValidation_ShouldReturnError_WhenDoesNot8Character()
        {
            // Arrange
            var userValidation = new CreatUser();
            var password = "test@";
            // Act
            var result = userValidation.PasswordValidation(password);
            // Assert
            Assert.AreEqual("Your password should be more than 8 characters and contains @", result);
        }

        [TestMethod]
        public void PasswordValidation_ShouldReturnError_WhenDoesNotContainAt()
        {
            // Arrange
            var userValidation = new CreatUser();
            var password = "test1234";
            // Act
            var result = userValidation.PasswordValidation(password);
            // Assert
            Assert.AreEqual("Your password should be more than 8 characters and contains @", result);
        }
    }
}
