using ATDS.API.Info;
using ATDS.API.Utils;
using ATDS.Business.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATDS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserInfo login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        #region Private Function
        private string GenerateJSONWebToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              GetTockenClaims(userInfo),
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserInfo AuthenticateUser(UserInfo login)
        {
            UserInfo user = null;

            //Validate the User Credentials
            //Demo Purpose, I have Passed HardCoded User Information
            if (login.UserName == "vcl" && login.Password =="vcl")
            {
                user = new UserInfo { UserName = "VCL", Email = "test.atds@gmail.com", Language = "1", };
            }
            return user;
        }

        private IEnumerable<Claim> GetTockenClaims(UserInfo userInfo)
        {
            return new List<Claim>
            {
                new Claim(ClaimConstant.UserName, userInfo.UserName),
                new Claim(ClaimConstant.Email, userInfo.Email),
                new Claim(ClaimConstant.Language, userInfo.Language)
                //More custom claims
            };
        }
        #endregion
        //// GET: api/<LoginController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<LoginController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<LoginController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<LoginController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<LoginController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
