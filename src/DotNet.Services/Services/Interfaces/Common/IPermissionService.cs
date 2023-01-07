using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IPermissionService
    {
        ResponseMessage GetAll();
        ResponseMessage GetAllByOrganizationUser();
        ResponseMessage GetByID(int id);
    }
}
