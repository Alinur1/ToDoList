using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUser _iuser;

        public UserController(IUser iuser)
        {
            _iuser = iuser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var getAllUser = await _iuser.GetAllUsersAsync();
            return Ok(getAllUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var getUserById = await _iuser.GetUserByIdAsync(id);
            if (getUserById == null)
            {
                return NotFound();
            }
            return Ok(getUserById);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createUser = await _iuser.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.user_id }, createUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if(id != user.user_id)
            {
                return BadRequest("User ID mismatch");
            }

            try
            {
                var existingUser = await _iuser.UpdateUserAsync(user);
                return Ok(existingUser);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _iuser.DeleteUserAsync(id);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
