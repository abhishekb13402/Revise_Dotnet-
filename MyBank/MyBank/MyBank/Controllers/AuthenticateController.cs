using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBank.Model.Dto;
using MyBank.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAuthenticateRepository authenticateRepository;

        public AuthenticateController(IConfiguration configuration, IAuthenticateRepository authenticateRepository)
        {
            this.configuration = configuration;
            this.authenticateRepository = authenticateRepository;
        }
        [HttpPost("Authentication")]
        [AllowAnonymous]
        public object AuthenticateUser(AuthDto authDto)
        {
            bool isValidUser = authenticateRepository.AuthenticateUser(authDto);
            if (isValidUser)
            {
                return GenerateToken(authDto.Email);
            }
            else
            {
                return "Invalid user name and password";
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