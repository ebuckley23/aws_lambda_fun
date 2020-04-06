using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Abstractions
{
    public interface IConfiguration
    {
        string DBConnString { get; }
        string DynamoConnString { get; }
    }
}
