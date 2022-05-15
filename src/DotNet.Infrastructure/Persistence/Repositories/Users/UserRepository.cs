using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Infrastructure.Persistence.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private List<UserDto> _users => new()
        {
            new("daud", "123456"),
            new("Jia Anu", "jia"),
            new("Naina Anu", "naina"),
            new("Sreena Anu", "sreena"),
        };
        public UserDto GetUser(UserModel userModel)
        {
            return _users.FirstOrDefault(x => string.Equals(x.UserName, userModel.UserName) && string.Equals(x.Password, userModel.Password));
        }
    }
}
