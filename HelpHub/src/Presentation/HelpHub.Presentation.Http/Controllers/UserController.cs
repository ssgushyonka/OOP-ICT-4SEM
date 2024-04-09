using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserModel>> Get(string userId)
        {
            var user = await _userService.GetUser(userId)!;
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(UserModel userModel)
        {
            await _userService.Create(userModel);
            return CreatedAtAction(nameof(Get), new { userId = userModel.UserId }, userModel);
        }

        [HttpPut("{userId}/name")]
        public async Task<ActionResult> UpdateName(string userId, [FromBody] string newName)
        {
            var user = await _userService.GetUser(userId)!;
            if (user == null)
            {
                return NotFound();
            }

            await _userService.UpdateName(userId, newName);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete(string userId)
        {
            var user = await _userService.GetUser(userId)!;
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(userId);
            return NoContent();
        }
    }
