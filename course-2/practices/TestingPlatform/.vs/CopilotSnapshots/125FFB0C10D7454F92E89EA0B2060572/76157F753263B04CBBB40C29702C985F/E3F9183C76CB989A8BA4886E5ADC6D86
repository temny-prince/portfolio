using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class UserRepository(AppDbContext appDbContext, IMapper mapper) : IUserRepository
{
    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var users = await appDbContext.Users
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> GetByIdAsync(int id)
    {
        var user = await appDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
            throw new Exception("Пользователь не найден.");

        return mapper.Map<UserDTO>(user);
    }

    public async Task<int> CreateAsync(UserDTO userDto, string password)
    {
        if (string.IsNullOrWhiteSpace(userDto.Login))
            throw new ArgumentException("Логин обязателен.");

        if (string.IsNullOrWhiteSpace(userDto.Email))
            throw new ArgumentException("Email обязателен.");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Пароль обязателен.");

        var exists = await appDbContext.Users
            .AnyAsync(u => u.Login == userDto.Login || u.Email == userDto.Email);

        if (exists)
            throw new ArgumentException("Пользователь с таким логином или email уже существует.");

        var user = mapper.Map<User>(userDto);

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        user.CreatedAt = DateTimeOffset.UtcNow;

        await appDbContext.Users.AddAsync(user);
        await appDbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task UpdateAsync(UserDTO userDto)
    {
        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userDto.Id);

        if (user is null)
            throw new Exception("Пользователь не найден.");

        var loginExists = await appDbContext.Users
            .AnyAsync(u => u.Id != userDto.Id && u.Login == userDto.Login);

        if (loginExists)
            throw new ArgumentException($"Пользователь с логином {userDto.Login} уже существует.");

        user.Login = userDto.Login;
        user.Email = userDto.Email;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.MiddleName = userDto.MiddleName;
        user.Role = userDto.Role;

        await appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserDTO userDto, string password)
    {
        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userDto.Id);

        if (user is null)
            throw new Exception("Пользователь не найден.");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Пароль обязателен.");

        var loginExists = await appDbContext.Users
            .AnyAsync(u => u.Id != userDto.Id && u.Login == userDto.Login);

        if (loginExists)
            throw new ArgumentException($"Пользователь с логином {userDto.Login} уже существует.");

        user.Login = userDto.Login;
        user.Email = userDto.Email;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.MiddleName = userDto.MiddleName;
        user.Role = userDto.Role;
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
            throw new Exception("Пользователь не найден.");

        appDbContext.Users.Remove(user);
        await appDbContext.SaveChangesAsync();
    }
}