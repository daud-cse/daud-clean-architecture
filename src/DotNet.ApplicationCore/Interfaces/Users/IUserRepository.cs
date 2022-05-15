using DotNet.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.ApplicationCore.Interfaces.Users
{

    public interface IUserRepository
    {
        UserDto GetUser(UserModel userModel);
    }
}
