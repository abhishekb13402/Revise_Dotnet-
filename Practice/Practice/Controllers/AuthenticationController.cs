using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Practice.Model.Dto;
using Practice.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly AuthenticationRepository authenticationRepository;

        public AuthenticationController(IConfiguration configuration, AuthenticationRepository authenticationRepository)
        {
            this.configuration = configuration;
            this.authenticationRepository = authenticationRepository;
        }
        [HttpPost("Authentication")]
        public object AuthenticateUser(string useremail, string password)
        {
            bool isValidUser = authenticationRepository.AuthenticateUser(useremail, password);
            if (isValidUser)
            {
                return generateToken(useremail);
            }
            else
            {
                return new Exception("Invalid user name and password");
            }
        }
        private string generateToken(string useremail)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,useremail),
                //new Claim(ClaimTypes.Email,user.Email),

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
