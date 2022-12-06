using DotNet.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNet.ApplicationCore.Entities;
namespace DotNet.ApplicationCore.Interfaces
{

    public interface IUserRepository: IGenericRepository<Users>
    {
       // UserDto GetUser(UserModel userModel);
       //Task<List<Users>> GetUsers();
    }
}
