using Company2.Services;
using Company2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Company2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class user : ControllerBase
    {
        public UserPermissionsService _userPermissionsService;
        public UserService _userService;
        public user(UserPermissionsService userPermissionsService, UserService userService)
        {
            _userPermissionsService = userPermissionsService;
            _userService = userService;
        }

        [HttpPost("add-user-permission")]
        public IActionResult AddUserPermission([FromBody] UserPermissionsVM userPermissions)
        {
            _userPermissionsService.AddPermission(userPermissions);
            return Ok();
        }
        [HttpGet("get-user-by-id/{id}")]
        public IActionResult GetUserById(int id)
        {
            var userId = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
            if (!id.ToString().Equals(userId))
            {
                return BadRequest("Tokendaki kullanıcıyla girilen ID aynı değil!!!");
            }
            else
            {
                var data = _userService.GetUserById(id);
                return Ok(data);
            }

        }
        [HttpPut("update-user-information-by-id/{id}")]
        public IActionResult UpdateUserInformationById(int id,[FromBody]UserInformationVM userInformation)
        {
            var userId = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
            if (!id.ToString().Equals(userId))
            {
                return BadRequest("Tokendaki kullanıcıyla girilen ID aynı değil!!!");
            }
            else
            {
                var updatedUser = _userService.UpdateUserInformationById(id, userInformation);
                            return Ok(updatedUser);
            }
            
        }
        [HttpDelete("delete-user-information-by-id/{id}")]
        public IActionResult DeleteUserInformationById(int id) 
        {
            var userId = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
            if (!id.ToString().Equals(userId))
            {
                return BadRequest("Tokendaki kullanıcıyla girilen ID aynı değil!!!");
            }
            else
            {
                _userService.DeleteUserInformationById(id);
                            return Ok();
            }
        }
    }
}
