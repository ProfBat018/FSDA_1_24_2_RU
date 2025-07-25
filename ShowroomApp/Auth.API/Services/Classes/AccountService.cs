using Auth.API.DTOs;
using Auth.API.Services.Interfaces;
using Auth.Data.Data;
using Auth.Data.Data.Models;
using AutoMapper;

namespace Auth.API.Services.Classes;

public class AccountService : IAccountService
{
    private readonly AuthDbContext _context;
    private readonly IMapper _mapper;

    public AccountService(AuthDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task RegisterAsync(RegisterRequestDTO request)
    {
        var mappingRes = _mapper.Map<RegisterRequestDTO, User>(request);

        if (mappingRes == null)
        {
            throw new ArgumentException("Invalid request");
        }

       mappingRes.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
       
       _context.Users.Add(mappingRes);

       await _context.SaveChangesAsync();
    }
}