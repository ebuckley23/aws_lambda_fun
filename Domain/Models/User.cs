using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User
    {
        protected User()
        {

        }

        public User(string uId, string name)
        {
            Name = name;
            UId = uId;
            CreatedDate = DateTimeOffset.UtcNow;
        }
        public string Name { get; }
        public string UId { get; }
        public DateTimeOffset CreatedDate { get; }
    }
}
