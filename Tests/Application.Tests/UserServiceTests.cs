using Domain.Interfaces;
using Domain.Models;
using Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests
{
    public class UserServiceTests
    {
        Mock<IUserRepository> _repository;
        List<User> data; // because of how xunit is ran, this should be a new instance every time; A more proper test would be to make data a fixture but its not that serious
        IUserService _userService;
        public UserServiceTests()
        {
            _repository = new Mock<IUserRepository>();
            data = new List<User>();
        }
        [Fact]
        public void Can_Create_User()
        {
            _repository.Setup(x => x.Create(It.IsAny<User>()))
                .Returns((User u) =>
                {
                    data.Add(u);
                    return u;
                });
            _userService = new UserService(_repository.Object);
            Assert.NotNull(_userService.CreateUser(new User("a", "Emmanuel Buckley")));
        }

        [Fact]
        public void Can_Get_User_By_Id()
        {
            _repository.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string uId) =>
                {
                    var user1 = new User(uId, "Emmanuel Buckley");
                    var user2 = new User("abac", "123");
                    data.AddRange(new[] { user1, user2 });
                    return data.Find(x => x.UId == uId);
                });
            _userService = new UserService(_repository.Object);
            Assert.NotNull(_userService.GetUser("ebuckley"));
        }

        [Fact]
        public void Can_Get_All_Users()
        {
            _repository.Setup(x => x.GetAll())
                .Returns(() =>
                {
                    var user1 = new User("123", "Emmanuel Buckley");
                    var user2 = new User("abac", "123");
                    data.AddRange(new[] { user1, user2 });
                    return data;
                });
            _userService = new UserService(_repository.Object);
            Assert.NotEmpty(_userService.GetUsers());
        }
    }
}
