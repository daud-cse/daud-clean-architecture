﻿using DotNet.ApplicationCore.DTOs;

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
using DotNet.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Infrastructure.Persistence.Repositories.User
{
    //GenericRepository<Users>,
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
              Microsoft.Extensions.Logging.ILogger<Users> logger
             )
        {
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public AuthUser UserAuthentication(AuthUser user)
        {
            var dbUser = _context.Users.SingleOrDefault(x => string.Equals(x.UserID, user.UserID) && string.Equals(x.Password, user.Password));
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
            var users = _context.Users.Where(x => x.OrganizationId == orginzationId).ToList();
            return await Task.FromResult(users);
        }
        public async Task<Users> GetByID(int id)
        {
            var result = _context.Users.SingleOrDefault(x => x.UserAutoId == id);
            return result;
        }
    }
}

