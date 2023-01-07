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
    //IGenericRepository<Permission>,
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger<Permission> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DotNetContext _context;

        public PermissionRepository(
             IHttpContextAccessor httpContextAccessor,
             DotNetContext context,
             IMapper mapper,
             ILogger<Permission> logger
             )
        {
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<IEnumerable<Permission>> GetAllByOrganizationUser()
        {
            //int orginzationID = await _httpContextAccessor.HttpContext.User.GetOrginzationIdFromClaimIdentity();
            //var userId = await _httpContextAccessor.HttpContext.User.GetUserIdFromClaimIdentity();

            var Permission = _context.Permissions.ToList();
            return await Task.FromResult(Permission);
        }


        public async Task<IEnumerable<Permission>> GetAll()
        {
            int orginzationID = await _httpContextAccessor.HttpContext.User.GetOrginzationIdFromClaimIdentity();

            var Permission = _context.Permissions.Where(x => x.OrganizationID == orginzationID).ToList();
            return await Task.FromResult(Permission);
        }
        public async Task<Permission> GetByID(int id)
        {
            var result = _context.Permissions.SingleOrDefault(x => x.PermissionID == id);
            return result;
        }
        public async Task<Permission> Add(Permission permission)
        {
            var result = _context.Permissions.Add(permission);
            _context.SaveChanges();
            return _context.Permissions.SingleOrDefault(x => x.PermissionID == permission.PermissionID);
        }
    }
}

