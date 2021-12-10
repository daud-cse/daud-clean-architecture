using Daud.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daud.ApplicationCore.Interfaces.Security
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDto user);
    }
}
