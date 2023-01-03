using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Utils;
using DotNet.Services.Common;
using DotNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DotNet.WebApi.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ITokenService tokenService;
        private readonly AppSettingsJson appSettingsJson;
        public AuthenticateController(ITokenService tokenService, UserService userService, IOptionsSnapshot<AppSettingsJson> optionsSnapshot)
        {
            this.tokenService = tokenService;
            _userService = userService;
            appSettingsJson = optionsSnapshot.Value;
        }
        [HttpPost("authenticate"), AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthUser user)
        {
            ResponseMessage rm = _userService.UserAuthentication(user);
            AuthUser authUser = (AuthUser)rm.ResponseObj;
            if (authUser.UserAutoID == 0)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;     
                return await Task.FromResult(Ok(HttpContext.Response.StatusCode));
            }
            authUser.Token = tokenService.BuildToken(authUser);
            return await Task.FromResult(Ok(authUser));
        }
    }
}
