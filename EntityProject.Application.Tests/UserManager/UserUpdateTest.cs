using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using static EntityProject.Application.UserManagment.IUpdateUser;
using EntityProject.Domain.Entities;



namespace EntityProject.Application.Tests.UserManager;

[TestClass]
public class UserUpdateTest
{
    private Mock<IUserDataAccess> _userDataAccessMock;
    private Mock<IPersonDataAccess> _personDataAccessMock;
    private Mock<IDb> _dbMock;
    private IUpdateUser _sut;

    [TestInitialize]
    public void Setup()
    {
        _userDataAccessMock = new Mock<IUserDataAccess>();
        _dbMock = new Mock<IDb>();
        _personDataAccessMock = new Mock<IPersonDataAccess>();
        _sut = new UpdateUser(
            _userDataAccessMock.Object,
            _dbMock.Object,
            _personDataAccessMock.Object);
    }

    [TestMethod]
    public void Update_WhenUserDoseNotExist_ShouldThrowAppException()
    {
        // Arrange
        var request = new UpdateRequest { Id = 1 };

        _userDataAccessMock.Setup(x => x.GetForUpdate(request.Id)).Returns((User)null);

        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Update(request));
        Assert.AreEqual("User not found!", exception.UserMessage);
    }

    [TestMethod]
    public void Update_WhenPersonDoseNotExist_ShouldThrowAppException()
    {
        // Arrenge
        var request = new UpdateRequest 
        { 
            Id = 1,
            FirstName = "Ali",
            LastName = "Mohamadi",
            UserName = "AliMohamadi",
            Password = "AliMohamadi123@"
        };

        var user = new User { Id = 1, PersonId = 1 };

        _userDataAccessMock.Setup(x => x.GetForUpdate(request.Id)).Returns(user);
        _personDataAccessMock.Setup(x => x.GetForUpdate(user.PersonId)).Returns((Person)null);

        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Update(request));
        Assert.AreEqual("Person not found!", exception.UserMessage);
    }

    [TestMethod]
    public void Update_WhenSaveChangesThrowException_ShowThrowAppException()
    {
        // Arrenge
        var request = new UpdateRequest
        {
            Id = 1,
            FirstName = "Ali",
            LastName = "Mohamadi",
            UserName = "AliMohamadi",
            Password = "AliMohamadi123@"
        };

        var user = new User { Id = 1, PersonId = 1 };
        var person = new Person { Id = 1 };

        _userDataAccessMock.Setup(x => x.GetForUpdate(request.Id)).Returns(user);
        _personDataAccessMock.Setup(x => x.GetForUpdate(user.PersonId)).Returns(person);

        var orginalDbException = new Exception("SQL connection failed");

        _dbMock.Setup(x => x.SaveChanges()).Throws(orginalDbException);

        // Act & Assert
        var exception = Assert.ThrowsException<AppException>(() => _sut.Update(request));

        Assert.AreEqual("An unexpected error occurred from the database!", exception.UserMessage);
        Assert.AreEqual(orginalDbException, exception.InnerException);
    }
}
