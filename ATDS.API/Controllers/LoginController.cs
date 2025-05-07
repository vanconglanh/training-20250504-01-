using ATDS.API.Info;
using ATDS.API.Utils;
using ATDS.Business;
using ATDS.Business.Info;
using ATDS.DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nest;
using Optivem.Framework.Core.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATDS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        readonly UserSearchBusiness _userSearchBusiness;
        public LoginController(IConfiguration config)
        {
            _config = config;
            _userSearchBusiness = new UserSearchBusiness();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserItemInfo login)
        {
            IActionResult response = Unauthorized();
            var userLoginInfo = AuthenticateUser(login);

            if (userLoginInfo != null)
            {
                var tokenString = GenerateJSONWebToken(userLoginInfo);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        #region Private Function
        private string GenerateJSONWebToken(UserLoginInfo UserItemInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              GetTockenClaims(UserItemInfo),
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserLoginInfo AuthenticateUser(UserItemInfo login)
        {
            //Validate the User Credentials
            UserFilter filter = new UserFilter();
            filter.UserName = login.UserName;
            filter.Password = login.Password;

            var user = _userSearchBusiness.GetLoginInfo(filter);

            return user;
        }

        private IEnumerable<Claim> GetTockenClaims(UserLoginInfo userLoginInfo)
        {
            // Serialize permission list to JSON
            var permissionJson = JsonSerializer.Serialize(userLoginInfo.ListPermissons);
            return new List<Claim>
            {
                new Claim(ClaimConstant.UserId, userLoginInfo.Id.ToString()),
                new Claim(ClaimConstant.UserName, userLoginInfo.UserName),
                new Claim(ClaimConstant.Email, userLoginInfo.Email),
                new Claim(ClaimConstant.Language, userLoginInfo.Language),
                new Claim(ClaimConstant.RoleId, userLoginInfo.RoleId.ToString()),
                new Claim(ClaimConstant.RoleName, ""),
                new Claim(ClaimConstant.CreatedAt, userLoginInfo.CreatedAt.ToString()),
                new Claim(ClaimConstant.CreatedAt, userLoginInfo.UpdatedAt.ToString()),
                new Claim(ClaimConstant.PermissonActions, permissionJson),
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
