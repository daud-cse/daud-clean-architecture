using DotNet.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.ApplicationCore.Interfaces.Security
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDto user);
    }
}
