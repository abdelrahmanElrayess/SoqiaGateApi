using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoqiaGateApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase

    {
        private readonly IConfiguration _configuration;
        public class AuthenticationRequestBody
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        private class CustomerInfoUser
        {
            public int UserId { get; set; }
            public string? Username { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Customer { get; set; }

            public CustomerInfoUser
                
                (

                    int userid,
                    string username,
                    string firstname,
                    string lastname,
                    string customer

                )
            {

                UserId = userid;
                Username = username;
                FirstName = firstname;
                LastName = lastname;
                Customer = customer;




            }
        }
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            // step 1 : validate user name and password
            var user = ValidateUserCredentials(
                authenticationRequestBody.Username,
                authenticationRequestBody.Password
            );

            if (user == null)
            {
                return Unauthorized();
            }

            // step 2 : create a token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // step 3 : create claims
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub",user.UserId.ToString()));
            claimsForToken.Add(new Claim("username",user.Username));
            claimsForToken.Add(new Claim("firstname",user.FirstName));
            claimsForToken.Add(new Claim("lastname",user.LastName));
            claimsForToken.Add(new Claim("customer",user.Customer));


            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
            );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);




            return Ok(tokenToReturn);
        }

        private CustomerInfoUser ValidateUserCredentials(string? username, string? password)
        {
            return new CustomerInfoUser(1, "test", "test", "test", "test");
        }
    }
}
