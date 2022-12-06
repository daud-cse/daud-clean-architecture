using AutoMapper;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.ApplicationCore.Utils.Helper;
namespace DotNet.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DotNetContext _dotnetContext;
        private readonly IMapper _mapper;
        public UserService(
              IHttpContextAccessor httpContextAccessor,
              DotNetContext dotnetContext
             , IMapper mapper
            )
        {
            this._httpContextAccessor = httpContextAccessor;
            this._dotnetContext = dotnetContext;
            this._mapper = mapper;
        }

        private List<UserDto> _users => new()
        {
            new("daud", "123456"),
            new("Jia Anu", "jia"),
            new("Naina Anu", "naina"),
            new("Sreena Anu", "sreena"),
        };
        public UserDto GetUser(UserModel userModel)
        {
            return _users.FirstOrDefault(x => string.Equals(x.UserName, userModel.UserName) && string.Equals(x.Password, userModel.Password));
        }

        public async Task<List<Users>> GetUsers()
        {
            try
            {
                int orginzationId = await _httpContextAccessor.HttpContext.User.GetOrginzationIdFromClaimIdentity();
                var userId = await _httpContextAccessor.HttpContext.User.GetUserIdFromClaimIdentity();
                var users = _dotnetContext.Users.ToList();
                return await System.Threading.Tasks.Task.FromResult(users);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
