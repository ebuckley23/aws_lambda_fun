using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class UserRepository : IRepository<User, string>, IUserRepository
    {
        public static List<User> data = new List<User>();
        public User Create(User item)
        {
            data.Add(item);
            return item;
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return data.AsReadOnly();
        }

        public User GetById(string id)
        {
            return data.Find(x => x.UId == id);
        }
    }
}
