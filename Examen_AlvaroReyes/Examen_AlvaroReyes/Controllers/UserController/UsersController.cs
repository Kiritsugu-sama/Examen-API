using Examen_AlvaroReyes.Controllers.UserController.Models;
using Examen_AlvaroReyes.DB.Examen.Entities;
using Examen_AlvaroReyes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Examen_AlvaroReyes.Controllers.UserController;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users.Select(MapToResponseDto));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserRegisterDto userDto)
    {
        try
        {
            var user = new TblUser
            {
                UserName = userDto.UserName,
                UserEmail = userDto.UserEmail,
                UserPassword = userDto.UserPassword
            };

            var createdUser = await _userService.CreateUser(user);
            return Ok(MapToResponseDto(createdUser));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userDto)
    {
        try
        {
            var user = new TblUser
            {
                UserName = userDto.UserName,
                UserEmail = userDto.UserEmail,
                UserPassword = userDto.UserPassword,
                UserActive = userDto.UserActive
            };

            var updatedUser = await _userService.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound("User not found");
            }
            return Ok(MapToResponseDto(updatedUser));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {

            var verificacion = await _userService.DeleteUser(id);
            if (verificacion == "")
            {
                return NotFound("Usario no encontrada");
            }
            return Ok(verificacion);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private UserResponseDto MapToResponseDto(TblUser user)
    {
        return new UserResponseDto
        {
            UserID = user.UserId,
            UserName = user.UserName,
            UserEmail = user.UserEmail,
            UserActive = user.UserActive,
            UserCreatedAt = user.UserCreatedAt
        };
    }
}