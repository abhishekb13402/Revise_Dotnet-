using JWTAuthentication.Model.Dto;
using JWTAuthentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAuthentication authentication;

        public AuthenticationController(IConfiguration configuration, IAuthentication authentication)
        {
            this.configuration = configuration;
            this.authentication = authentication;
        }
        [HttpPost("Authentication")]
        [AllowAnonymous]
        public object AuthenticateUser(AuthenticationDto authenticationDto)
        {
            bool isValidUser = authentication.AuthenticateUser(authenticationDto);
            if (isValidUser)
            {
                return GenerateToken(authenticationDto.Email);
            }
            else
            {
                return new Exception("Invalid user name and password");
            }
        }
        private string GenerateToken(string useremail)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,useremail),
            };
            var token = new JwtSecurityToken(this.configuration["Jwt:Issuer"],
                this.configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
