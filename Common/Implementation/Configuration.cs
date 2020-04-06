using Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Implementation
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            DBConnString = Environment.GetEnvironmentVariable("DB_CONN");
            DynamoConnString = Environment.GetEnvironmentVariable("DYNAMO_CONN");
        }
        public string DBConnString { get; }

        public string DynamoConnString { get; }
    }
}
