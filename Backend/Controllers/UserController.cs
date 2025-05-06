using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Routes;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route(UserRoutes.Base)]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, ITokenService tokenService, IMapper mapper)
    {
        _userService = userService;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    
    [HttpGet(UserRoutes.GetAllUsers)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        var response = _mapper.Map<List<UserDto>>(users);
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost(UserRoutes.Login)]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _userService.LoginUserAsync(loginDto.Email, loginDto.Password);
        if (user == null) return Unauthorized("Invalid credentials");

        var token = _tokenService.GenerateToken(user.Email, user.Id);
        return Ok(new TokenDto{ Token = token });
    }
    
    [AllowAnonymous]
    [HttpPost(UserRoutes.RegisterUser)]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
    {
        var user = _mapper.Map<User>(userRegistrationDto);
        var newUser = await _userService.AddUserAsync(user);
        var response = _mapper.Map<UserDto>(newUser);
        return Ok(response);
    }
}