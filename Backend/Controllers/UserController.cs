using AutoMapper;
using Backend.DTOs;
using Backend.Routes;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route(UserRoutes.Base)]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet(UserRoutes.GetAllUsers)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        var response = _mapper.Map<List<UserDto>>(users);
        return Ok(response);
    }
}