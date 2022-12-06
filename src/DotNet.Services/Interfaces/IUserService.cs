using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(UserModel userModel);
        Task<List<Users>> GetUsers();

    }
}
