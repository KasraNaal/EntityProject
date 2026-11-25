using EntityProject.Application.Interface;
using EntityProject.Application.UserManagment;
using EntityProject.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;


namespace EntityProject.Application.Tests.UserManager;

[TestClass]
public class GetUserByIdTest
{
    private Mock<IUserDataAccess> _userDataAccessMock;
    private IGetUserById _sut;

    [TestInitialize]
    public void Setup()
    {
        _userDataAccessMock = new Mock<IUserDataAccess>();
        _sut = new GetUserById(_userDataAccessMock.Object);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void GetUserById_WhenIdIsInvalid_ShouldsThrowAppException(int invalidId)
    {
        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Execute(invalidId));
        Assert.AreEqual("Invalid userId!", exception.UserMessage);
        _userDataAccessMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
    }

    [TestMethod]
    public void GetUserById_WhenIdIsValid_ShouldGetUserAndReturnUser()
    {
        // Arrange
        int validId = 1;

        var user = new User { Id = 1 };
        _userDataAccessMock.Setup(x => x.GetById(validId)).Returns(user);

        // Act
        var result = _sut.Execute(validId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(user, result);
        _userDataAccessMock.Verify(x => x.GetById(validId), Times.Once);
    }
}
