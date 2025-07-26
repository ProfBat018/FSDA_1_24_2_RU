using System.Text.RegularExpressions;
using Auth.API.DTOs;
using Auth.Data.Data.Models;
using AutoMapper;

namespace Auth.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterRequestDTO, User>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => ValidateEmail(src.Email)))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => ValidatePassword(src.Password, src.ConfirmPassword)))
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ForMember(dest => dest.UserRoles, opt => opt.Ignore()); 
    }

    private static string ValidateEmail(string email)
    {
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, emailPattern))
            throw new ArgumentException("Invalid email format");
        return email;
    }

    private static string ValidatePassword(string password, string confirmPassword)
    {
        var passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        
        if (password != confirmPassword)
        {
            throw new ArgumentException("Invalid password");
        }
        if (!Regex.IsMatch(password, passwordPattern))
            throw new ArgumentException("Password must be at least 8 characters long, contain upper and lower case letters, and a digit");
        return password;
    }
}