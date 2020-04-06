using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class UserService : IUserService
    {
        public static List<User> UserRepository = new List<User>();
        public User CreateUser(User user)
        {
            UserRepository.Add(user);
            return user;
        }

        public User GetUser(string uId)
        {
            return UserRepository.Find(x => x.UId == uId);
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            return UserRepository.AsReadOnly();
        }
    }
}
