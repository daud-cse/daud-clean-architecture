using DotNet.ApplicationCore.DTOs;
using Microsoft.AspNetCore.Http;
using DotNet.ApplicationCore.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Infrastructure.Persistence.Contexts;
using AutoMapper;
using DotNet.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Repositories.Infrastructure;
using DotNet.Services.Repositories.Interfaces;
using DotNet.ApplicationCore.Utils.Enum;

namespace DotNet.Services.Repositories.Common
{
    //IGenericRepository<Users>,
    public class UserRepository :  IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger<Users> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DotNetContext _context;

        public UserRepository(
             IHttpContextAccessor httpContextAccessor,
             DotNetContext context,
             IMapper mapper,
             ILogger<Users> logger
             )
        {
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public AuthUser UserAuthentication(AuthUser user)
        {
            Users dbUser = _context.Users.SingleOrDefault(x => string.Equals(x.UserID, user.UserID) && string.Equals(x.Password, user.Password));
            AuthUser authUser = new AuthUser();
            if (dbUser != null)
            {
                authUser.UserAutoID = dbUser.UserAutoID;
                authUser.UserID = dbUser.UserID;
                authUser.UserTypeID = dbUser.UserTypeID;
                authUser.OrganizationID = dbUser.OrganizationID;
                authUser.DesignationID = dbUser.DesignationID;
                authUser.UserFullName = dbUser.UserFullName;
                authUser.RoleID = dbUser.RoleID;
            }
            return authUser;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            int orginzationID = await _httpContextAccessor.HttpContext.User.GetOrginzationIdFromClaimIdentity();
            var userId = await _httpContextAccessor.HttpContext.User.GetUserIdFromClaimIdentity();

            //ClaimTypeObj claimTypeObj = await _httpContextAccessor.HttpContext.User.GetAllData();

            var users = _context.Users.Where(x => x.OrganizationID == orginzationID).ToList();
            return await Task.FromResult(users);
        }
        public async Task<Users> GetByID(int id)
        {
            var result = _context.Users.SingleOrDefault(x => x.UserAutoID == id);
            return result;
        }
        //public async Task<Users> Add(Users user)
        //{
        //    var result = _context.Users.Add(user);
        //    _context.SaveChanges();
        //    return _context.Users.SingleOrDefault(x => x.UserAutoID == user.UserAutoID);
        //}
    }
}

