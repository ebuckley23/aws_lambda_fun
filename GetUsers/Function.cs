using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Application;
using Autofac;
using Common.Abstractions;
using Common.Implementation;
using Domain.Models;
using Domain.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.LambdaJsonSerializer))]

namespace GetUsers
{
    public class Function
    {
        IResolver _resolver;
        IUserService _userService;
        public Function()
        {
            _resolver = new AutofacResolver(x =>
            {
                x.RegisterType<UserService>().As<IUserService>();
            });
            _userService = _resolver.Resolve<IUserService>();
        }

        public Function(IResolver resolver, IUserService userService)
        {
            _resolver = resolver;
            _userService = userService;
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<IReadOnlyCollection<User>> FunctionHandler(string input, ILambdaContext context)
        {
            var user1 = new User("a", "Emmanuel Buckley");
            var user2 = new User("b", "John Simpson");
            var user3 = new User("c", "Martin Luther");
            _userService.CreateUser(user1);
            _userService.CreateUser(user2);
            _userService.CreateUser(user3);
            return Task.FromResult(_userService.GetUsers());
        }
    }
}
