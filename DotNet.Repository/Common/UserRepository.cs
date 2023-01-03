using AutoMapper;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Interfaces;
using DotNet.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotNet.ApplicationCore.Utils.Enum.GlobalEnum;

namespace DotNet.Repository.Common
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger<Users> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DotNetContext _dotnetContext;

        public UserRepository(
            DotNetContext dotnetContext,
             IHttpContextAccessor httpContextAccessor,
             IMapper mapper,
              Microsoft.Extensions.Logging.ILogger<Users> logger
             )
        {
            _mapper = mapper;
            _logger = logger;
            _dotnetContext = dotnetContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public AuthUser UserAuthentication(AuthUser user)
        {
            var dbUser = _dotnetContext.Users.SingleOrDefault(x => string.Equals(x.UserID, user.UserID) && string.Equals(x.Password, user.Password));
            AuthUser authUser = new AuthUser();
            if (dbUser != null)
            {
                authUser.UserAutoID = dbUser.UserAutoId;
                authUser.UserID = dbUser.UserID;
                authUser.Password = dbUser.Password;
            }
            return authUser;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            //int orginzationId = await _httpContextAccessor.HttpContext.User.GetOrginzationIdFromClaimIdentity();
            int orginzationId = 1;
            //var userId = await _httpContextAccessor.HttpContext.User.GetUserIdFromClaimIdentity();
            var users = _dotnetContext.Users.Where(x=>x.OrganizationId == orginzationId).ToList();
            return await Task.FromResult(users);
        }
        public async Task<Users> GetByID(int id)
        {

            var result = _dotnetContext.Users.SingleOrDefault(x => x.UserAutoId == id);
            return result;
        }
    }
}
