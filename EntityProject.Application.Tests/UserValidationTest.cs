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
            var userValidation = new UserValidation();
            var password = "test1234@";
            // Act
            var result = userValidation.PasswordValidation(password);
            // Assert
            Assert.AreEqual("test1234@", result);
        }
    }
}
