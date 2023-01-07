using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Utils;
using DotNet.Services.Services.Common;
using DotNet.Services.Services.Infrastructure;
using DotNet.Services.Services.Interfaces.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DotNet.ApplicationCore.Utils.Enum.GlobalEnum;

namespace DotNet.WebApi.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;
        private readonly ITokenService tokenService;
        private readonly AppSettingsJson appSettingsJson;
        public AuthenticateController(
            ITokenService tokenService, 
            IUserService userService,
            IPermissionService permissionService,
            IOptionsSnapshot<AppSettingsJson> optionsSnapshot
            )
        {
            this.tokenService = tokenService;
            _userService = userService;
            _permissionService = permissionService;
            appSettingsJson = optionsSnapshot.Value;
        }
        [HttpPost("authenticate"), AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthUser user)
        {
            ResponseMessage resMes = _userService.UserAuthentication(user);
            
            AuthUser authUser = (AuthUser)resMes.ResponseObj;
            if (authUser== null || authUser.UserAutoID == 0)
            {
                resMes.StatusCode = ReturnStatus.Failed;
                return await Task.FromResult(Ok(resMes));
            }

            authUser.TokenResult = tokenService.BuildToken(authUser);

            ResponseMessage permissionRes = _permissionService.GetAllByOrganizationUser();
            authUser.Permissions = (List<Permission>)permissionRes.ResponseObj;

            resMes.ResponseObj = authUser;
            resMes.StatusCode = ReturnStatus.Success;
            return await Task.FromResult(Ok(resMes));
        }
    }
}
