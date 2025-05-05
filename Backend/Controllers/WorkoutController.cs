using System.Security.Claims;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Routes;
using Backend.Security.Filters;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route(WorkoutRoutes.Base)]
[ApiController]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;
    private readonly IMapper _mapper;

    public WorkoutController(IWorkoutService workoutService, IMapper mapper)
    {
        _workoutService = workoutService;
        _mapper = mapper;
    }

    [Authorize]
    [AuthorizeUserId]
    [HttpGet(WorkoutRoutes.GetWorkoutsByUser)]
    public async Task<IActionResult> GetWorkoutsByUser(int userId)
    {
        var workouts = await _workoutService.GetWorkoutByUserIdAsync(userId);
        var workoutsResponse = _mapper.Map<List<WorkoutDto>>(workouts);
        return Ok(workoutsResponse);
    }
    
    [Authorize]
    [AuthorizeUserId]
    [HttpPost(WorkoutRoutes.AddWorkout)]
    public async Task<IActionResult> AddWorkout([FromBody] WorkoutDto workoutDto)
    {
        var workout = _mapper.Map<Workout>(workoutDto);
        var newWorkout = await _workoutService.AddWorkoutAsync(workout);
        var workoutResponse = _mapper.Map<WorkoutDto>(newWorkout);
        return CreatedAtAction(nameof(GetWorkoutsByUser), new { userId = workout.UserId }, workoutResponse);
    }
    
    [Authorize]
    [AuthorizeUserId]
    [HttpGet(WorkoutRoutes.GetProgress)]
    public async Task<IActionResult> GetProgress(int userId, int year, int month)
    {
        var progress = await _workoutService.GetProgressAsync(userId, year, month);
        var progressResponse = _mapper.Map<List<ProgressDto>>(progress);

        return Ok(progressResponse);
    }
}