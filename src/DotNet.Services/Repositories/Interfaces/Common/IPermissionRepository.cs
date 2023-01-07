using DotNet.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Repositories.Infrastructure;

namespace DotNet.Services.Repositories.Interfaces.Common
{

    //: IGenericRepository<Permissions>
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllByOrganizationUser();
        //Task<IEnumerable<Permissions>> GetAll();
        //Task<Permissions> GetByID(int id);
    }
}
