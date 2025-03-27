using Examen_AlvaroReyes.DB.Examen;
using Examen_AlvaroReyes.DB.Examen.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Examen_AlvaroReyes.Services;

public class UserService
{
    private readonly ExamenEntities _context;

    public UserService(ExamenEntities context)
    {
        _context = context;
    }

    public async Task<TblUser> CreateUser(TblUser user)
    {
        user.UserCreatedAt = DateTime.Now;
        user.UserUpdatedAt = DateTime.Now;
        user.UserActive = true;
        user.UserDelete = false;

        _context.TblUsers.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<TblUser>> GetAllUsers()
    {
        return await _context.TblUsers
            .Where(u => !u.UserDelete)
            .ToListAsync();
    }

    public async Task<TblUser> GetUserById(int id)
    {
        var user = await _context.TblUsers
            .FirstOrDefaultAsync(u => u.UserId == id && !u.UserDelete);

        if (user == null)
            throw new Exception("Usuario no encontrado");

        return user;
    }

    public async Task<TblUser> UpdateUser(int id, TblUser user)
    {
        var existingUser = await GetUserById(id);

        if (existingUser == null)
            return null;

        existingUser.UserName = user.UserName;
        existingUser.UserEmail = user.UserEmail;
        existingUser.UserPassword = user.UserPassword;
        existingUser.UserActive = user.UserActive;
        existingUser.UserUpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<string> DeleteUser(int id)
    {
        var user = await GetUserById(id);
        if (user == null)
            return "";
        user.UserDelete = true;
        user.UserUpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return "Sucess";
    }

}

