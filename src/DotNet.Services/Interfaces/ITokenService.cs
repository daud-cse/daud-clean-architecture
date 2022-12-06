﻿using DotNet.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.Interfaces
{
    public interface ITokenService
    {
        TokenResult BuildToken(UserDto user);
    }
}