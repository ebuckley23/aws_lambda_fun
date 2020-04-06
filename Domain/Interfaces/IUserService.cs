using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        User GetUser(string uId);
        IReadOnlyCollection<User> GetUsers();
        User CreateUser(User user);
    }
}
