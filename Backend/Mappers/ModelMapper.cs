using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Mappers;

public class ModelMapper : Profile
{
    public ModelMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserRegistrationDto>().ReverseMap();
        CreateMap<Workout, WorkoutDto>().ReverseMap();
    }
}