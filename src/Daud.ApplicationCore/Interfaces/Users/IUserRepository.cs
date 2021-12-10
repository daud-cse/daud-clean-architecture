using Daud.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daud.ApplicationCore.Interfaces.Users
{

    public interface IUserRepository
    {
        UserDto GetUser(UserModel userModel);
    }
}
