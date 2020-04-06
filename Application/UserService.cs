using Domain.Models;
using Domain.Interfaces;
using System.Collections.Generic;
using Infrastructure;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            _userRepository.Create(user);
            return user;
        }

        public User GetUser(string uId)
        {
            return _userRepository.GetById(uId);
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
