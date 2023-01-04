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
    public interface IUserService
    {
        ResponseMessage UserAuthentication(AuthUser userResponse);
        ResponseMessage GetAll();
        ResponseMessage GetByID(int id);
        //Task<Users> Add(Users entity);
        //Task<Users> Update(Users entity);
        //Task<bool> Delete(int id);



        //Task<List<Users>> GetUsers();

        //Users GetUserByID(Users userResponse);
    }
}
