using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Daud.ApplicationCore.DTOs;
using Daud.ApplicationCore.Interfaces.Security;
using Daud.ApplicationCore.Interfaces.Users;
using Daud.ApplicationCore.Utils;
using System.Threading.Tasks;

namespace Daud.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private readonly AppSettingsJson appSettingsJson;
        //private readonly HttpContext http;

        public AuthorizationController( ITokenService tokenService,IUserRepository userRepository, IOptionsSnapshot<AppSettingsJson> optionsSnapshot)
        {
            this.tokenService= tokenService;
            this.userRepository = userRepository;
           // this.http = http;
            this.appSettingsJson = optionsSnapshot.Value;
        }

        [HttpPost("token") ,AllowAnonymous]
        public async Task<IActionResult> Token(UserModel userModel)
        {

            //if (request.Grant_type == "password")
            //{
            //    var response = await BuildToken(request);
            //    return await Task.FromResult(Ok(response));
            //}
            //else if (request.Grant_type == "withoutPassword")
            //{
            //    var response = await BuildTokenForAnotherCompany(Convert.ToInt16(request.CompanyId), request.Username);
            //    return await Task.FromResult(Ok(response));
            //}
            //else if (request.Grant_type == "refresh_token")
            //{
            //    var response = await BuildRefreshToken(request.Refreshtoken);
            //    return response;
            //}
            // var userModel = await HttpContext.Request.ReadFromJsonAsync<UserModel>();
            var userDto = userRepository.GetUser(userModel);
            if (userDto == null)
            {
                HttpContext.Response.StatusCode = 401;
                return await Task.FromResult(Ok(HttpContext.Response.StatusCode));
            }
            appSettingsJson.Jwt_Key = "ThisWouldBeReplacedBySecretKey";
            appSettingsJson.Jwt_Issuer = "www.bytelanguage.net";
            var token = tokenService.BuildToken(appSettingsJson.Jwt_Key, appSettingsJson.Jwt_Issuer, userDto);
            //await HttpContext.Response.WriteAsJsonAsync(new { token = token });
          //  return;
            return await Task.FromResult(Ok(token));
        }

        ////GET : /logout
        //[HttpGet("~/logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    try
        //    {
        //        var principal = HttpContext.User;
        //        if (principal == null) throw new Exception("User's Compnay Cannot found");
        //        var claims = principal.Claims.ToList();
        //        var email = claims.FirstOrDefault(c => c.Type == "Email")?.Value;
        //        return await Task.FromResult(Ok("Logout Successful"));
        //    }
        //    catch (Exception ex)
        //    {
        //        await _errorService.SaveError(ClassName, "ReExchange", ex.ToString(), _unitOfWork);
        //        return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
        //    }
        //}

    }
}
