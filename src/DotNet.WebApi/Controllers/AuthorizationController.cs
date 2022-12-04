﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Interfaces.Security;
using DotNet.ApplicationCore.Interfaces.Users;
using DotNet.ApplicationCore.Utils;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotNet.WebApi.Controllers
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
            //{
            //    "requestObject":{ "UserName":"daud","Password":"123456"}
            //}
            //UserModel userModel = new UserModel();
            //var userModel = JsonConvert.DeserializeObject<UserModel>(requestObj.requestObject.ToString());
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
            var token = tokenService.BuildToken(userDto);
            //await HttpContext.Response.WriteAsJsonAsync(new { token = token });
          //  return;
            return await Task.FromResult(Ok(new { token =new  TokenResult() }));
        }
        public class TokenResult
        {
            public string Access_token { get; set; }
            //public DateTime? Expiration { get; set; }
            public string UserEmail { get; set; }
            public int StatusCode { get; set; }
            public string Message { get; set; }
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
        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel model)
        //{
        //    var user = await _userManager.FindByNameAsync(model.Username);
        //    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        //    {
        //        var userRoles = await _userManager.GetRolesAsync(user);

        //        var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };

        //        foreach (var userRole in userRoles)
        //        {
        //            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //        }

        //        var token = CreateToken(authClaims);
        //        var refreshToken = GenerateRefreshToken();

        //        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

        //        user.RefreshToken = refreshToken;
        //        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        //        await _userManager.UpdateAsync(user);

        //        return Ok(new
        //        {
        //            Token = new JwtSecurityTokenHandler().WriteToken(token),
        //            RefreshToken = refreshToken,
        //            Expiration = token.ValidTo
        //        });
        //    }
        //    return Unauthorized();
        //}
    }
}
