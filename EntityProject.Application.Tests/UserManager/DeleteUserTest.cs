using System;
using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static EntityProject.Application.UserManagment.IUpdateUser;
using EntityProject.Domain.Entities;
using EntityProject.Application.Exceptions;

namespace EntityProject.Application.Tests.UserManager;

[TestClass]
public class DeleteUserTest
{
    private Mock<IUserDataAccess> _userDataAccessMock;
    private Mock<IPersonDataAccess> _personDataAccessMock;
    private Mock<IDb> _dbMock;
    private IDeleteUser _sut;

    [TestInitialize]
    public void Setup()
    {
        _userDataAccessMock = new Mock<IUserDataAccess>();
        _personDataAccessMock = new Mock<IPersonDataAccess>();
        _dbMock = new Mock<IDb>();
        _sut = new Delete(
            _userDataAccessMock.Object,
            _dbMock.Object,
            _personDataAccessMock.Object);
    }

    [DataRow(0)]
    [DataRow(-1)]
    [TestMethod]
    public void Delete_WhenIdIsInvalid_ShouldThrowAppException(int invalidUserId)
    {
        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Delete(invalidUserId));
        Assert.AreEqual("Invalid userId!", exception.Message);
    }

    [TestMethod]
    public void Delete_WhenUserDoseNotExist_ShouldThrowAppException()
    {
        // Arrange
        int validUserId = 1;

        _userDataAccessMock.Setup(x => x.GetForUpdate(validUserId)).Returns((User)null);

        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Delete(validUserId));
        Assert.AreEqual("User not found!", exception.Message);
    }

    [TestMethod]
    public void Delete_WhenPersonDoseNotExist_ShouldThrowAppException()
    {
        // Arrange
        int validUserId = 1;

        var user = new User
        {
            Id = validUserId,
            PersonId = 1
        };

        _userDataAccessMock.Setup(x => x.GetForUpdate(validUserId)).Returns(user);
        _personDataAccessMock.Setup(x => x.GetForUpdate(user.PersonId)).Returns((Person)null);

        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Delete(validUserId));
        Assert.AreEqual("Person not found!", exception.Message);
    }

    [TestMethod]
    public void Delete_WhenSaveChangesThrowException_ShowThrowAppException()
    {
        // Arrange
        int validUserId = 1;

        var user = new User
        {
            Id = validUserId,
            PersonId = 1
        };

        var person = new Person
        {
            Id = 1
        };

        _userDataAccessMock.Setup(x => x.GetForUpdate(validUserId)).Returns(user);
        _personDataAccessMock.Setup(x => x.GetForUpdate(user.PersonId)).Returns(person);

        var orginalDbException = new Exception("Database error");
        _dbMock.Setup(x => x.SaveChanges()).Throws(orginalDbException);

        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Delete(validUserId));
        Assert.AreEqual("An unexpected error occurred from the database!", exception.Message);
        Assert.AreEqual(orginalDbException, exception.InnerException);
    }

    [TestMethod]
    public void Delete_WhenUserExists_ShouldDeleteUserAndPersonAndSaveChanges()
    {
        int validUserId = 1;

        var user = new User
        {
            Id = validUserId,
            PersonId = 1
        };

        var person = new Person
        {
            Id = 1
        };

        _userDataAccessMock.Setup(x => x.GetForUpdate(validUserId)).Returns(user);
        _personDataAccessMock.Setup(x => x.GetForUpdate(user.PersonId)).Returns(person);

        // Act
        _sut.Delete(validUserId);

        // Assert
        _userDataAccessMock.Verify(x => x.Delete(user), Times.Once);
        _personDataAccessMock.Verify(x => x.Delete(person), Times.Once);
        _dbMock.Verify(x => x.SaveChanges(), Times.Once);
    }
}
