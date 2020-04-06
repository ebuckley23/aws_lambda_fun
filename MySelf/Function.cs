using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Application;
using Common.Abstractions;
using Common.Implementation;
using Domain.Models;
using Domain.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.LambdaJsonSerializer))]

namespace MySelf
{
    public class Function
    {
        IResolver _resolver;
        IUserService _userService;
        public Function()
        {
            _resolver = new StructuremapResolver(x =>
            {
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
        public Task<User> FunctionHandler(string input, ILambdaContext context)
        {
            var user = context?.Identity;
            var uId = user?.IdentityId ?? "testuid"; // mimic an id received from amazon cognito
            var fakeUser = new User(uId, "Fake User");
            _userService.CreateUser(fakeUser);
            return Task.FromResult(_userService.GetUser(uId));
        }
    }
}
