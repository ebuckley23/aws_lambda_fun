using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Application;
using Common.Abstractions;
using Common.Implementation;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.LambdaJsonSerializer))]

namespace CreateNewUser
{
    public class Function
    {
        IResolver _resolver;
        IUserService _userService;
        public Function()
        {
            _resolver = new StructuremapResolver(x => 
            {
                x.For<IUserRepository>().Use<UserRepository>();
                x.For<IUserService>().Use<UserService>();
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
        public Task<User> FunctionHandler(NewUserRequest input, ILambdaContext context)
        {
            var user = context?.Identity;
            var userId = user?.IdentityId ?? "testId";
            return Task.FromResult(_userService.CreateUser(new User(userId, input.Name)));
        }
    }
}
