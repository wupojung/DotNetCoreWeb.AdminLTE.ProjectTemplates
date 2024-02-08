using DotNetCoreWeb.AdminLTE.ProjectTemplates.Core;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Services.User;

public class UserService : IUserService
{
    private readonly SqlContext _db;

    public UserService(SqlContext dbContext)
    {
        this._db = dbContext;
    }

    public async Task<List<UserViewModel>> ListAsync()
    {
        List<UserViewModel> result = new List<UserViewModel>();
        try
        {
            var fromDb = from u in _db.Users
                orderby u.Id
                select new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Name = u.Name,
                    Nickname = u.Nickname,
                    Email = u.Email,
                    RoleList = new List<UserRoleViewModel>(),
                    CreatedAt = u.CreatedAt,
                    CreatedBy = u.CreatedBy,
                    ModifiedAt = u.ModifiedAt,
                    ModifiedBy = u.ModifiedBy,
                };

            if (await fromDb.AnyAsync())
            {
                result = await fromDb.ToListAsync();
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.ToString());
            throw;
        }

        return result;
    }

    public async Task<List<UserViewModel>> ListUserByUserRoleIdAsync(int userRoleId)
    {
        List<UserViewModel> result = new List<UserViewModel>();
        try
        {
            var fromDb = from u in _db.Users
                join m in _db.UserUserRoleMappings on u.Id equals m.UserRoleId
                where m.UserRoleId == userRoleId
                orderby u.Id
                select new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Name = u.Name,
                    Nickname = u.Nickname,
                    Email = u.Email,
                    RoleList = new List<UserRoleViewModel>(),
                    CreatedAt = u.CreatedAt,
                    CreatedBy = u.CreatedBy,
                    ModifiedAt = u.ModifiedAt,
                    ModifiedBy = u.ModifiedBy,
                };

            if (await fromDb.AnyAsync())
            {
                result = await fromDb.ToListAsync();
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.ToString());
            throw;
        }

        return result;
    }

    public async Task<UserViewModel?> GetUserByIdAsync(int id)
    {
        UserViewModel? result = null;
        try
        {
            var item = from u in _db.Users
                where u.Id == id
                select new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Name = u.Name,
                    Nickname = u.Nickname,
                    Email = u.Email,
                    RoleList = new List<UserRoleViewModel>(),
                    CreatedAt = u.CreatedAt,
                    CreatedBy = u.CreatedBy,
                    ModifiedAt = u.ModifiedAt,
                    ModifiedBy = u.ModifiedBy,
                };

            if (await item.AnyAsync())
            {
                result = await item.FirstAsync();
                result.RoleList = await ListUserRoleByUserIdAsync(id);
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.ToString());
            throw;
        }

        return result;
    }

    public async Task<IList<UserRoleViewModel>> ListUserRoleByUserIdAsync(int userId)
    {
        IList<UserRoleViewModel> result = new List<UserRoleViewModel>();
        try
        {
            var fromDb = from m in _db.UserRoles
                join u in _db.UserUserRoleMappings on m.Id equals u.UserRoleId
                where u.UserId == userId
                select new UserRoleViewModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Active = m.Active,
                    CreatedAt = m.CreatedAt,
                    CreatedBy = m.CreatedBy,
                    ModifiedAt = m.ModifiedAt,
                    ModifiedBy = m.ModifiedBy,
                };

            if (await fromDb.AnyAsync())
            {
                result = await fromDb.ToListAsync();
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.ToString());
            throw;
        }

        return result;
    }
}

public interface IUserService
{
    Task<List<UserViewModel>> ListAsync();
    Task<List<UserViewModel>> ListUserByUserRoleIdAsync(int userRoleId);
    Task<UserViewModel?> GetUserByIdAsync(int id);
    Task<IList<UserRoleViewModel>> ListUserRoleByUserIdAsync(int userId);
}