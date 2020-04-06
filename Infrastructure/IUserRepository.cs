using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IUserRepository
    {
        User Create(User item);
        IReadOnlyCollection<User> GetAll();
        User GetById(string id);
    }
}
