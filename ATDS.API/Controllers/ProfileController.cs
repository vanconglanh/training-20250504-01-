using ATDS.API.Info.ResponseInfo.Result;
using ATDS.API.Utils;
using ATDS.Business.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace ATDS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetProfile()
        {
            // Get identity from memory
            var identity = (ClaimsIdentity)User.Identity;
            // Set to return object
            var user = new UserLoginInfo
            {
                Id = int.Parse(identity.FindFirst(ClaimConstant.UserId)?.Value ?? "0"),
                Username = identity.FindFirst(ClaimConstant.Username)?.Value,
                Password = "", // not share
                Language = identity.FindFirst(ClaimConstant.Language)?.Value,
                Email = identity.FindFirst(ClaimConstant.Email)?.Value,
                PasswordHash = "", // not share
                CreatedAt = DateTime.TryParse(identity.FindFirst(ClaimConstant.CreatedAt)?.Value, out var createdAt)
                            ? createdAt
                            : DateTime.MinValue,
                UpdatedAt = DateTime.TryParse(identity.FindFirst(ClaimConstant.UpdatedAt)?.Value, out var updatedAt)
                            ? updatedAt
                            : DateTime.MinValue,
                Permissions = GetPermissionsFromClaims(identity),
            };

            var result = new DataResult<UserLoginInfo>(user);
            return Task.FromResult<IActionResult>(Ok(result));
        }
    #region "Private Function"

        private List<UserPermissonAction> GetPermissionsFromClaims(ClaimsIdentity user)
            {
                var json = user.FindFirst(ClaimConstant.PermissionActions)?.Value;

                if (!string.IsNullOrEmpty(json))
                {
                    return JsonSerializer.Deserialize<List<UserPermissonAction>>(json);
                }

                return new List<UserPermissonAction>();
            }
        }
    #endregion

}