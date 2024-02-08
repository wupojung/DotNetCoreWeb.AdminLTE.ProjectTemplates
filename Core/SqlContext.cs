using DotNetCoreWeb.AdminLTE.ProjectTemplates.Models.Security;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Core;

public class SqlContext : DbContext
{
    private readonly static string connectionString = "Host=localhost;Database=adminlte;Username=adminlte;Password=12345678";

    public SqlContext(DbContextOptions<SqlContext> options)
        : base(options)
    {
    }

    public static SqlContext Factory()
    {
        var contextOptions = new DbContextOptionsBuilder<SqlContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new SqlContext(contextOptions);
    }

    public static DbContextOptions<SqlContext> GetBuilder()
    {
        var contextOptions = new DbContextOptionsBuilder<SqlContext>()
            .UseNpgsql(connectionString)
            .Options;
        return contextOptions;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(connectionString);


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserUserRoleMappingEntity>().HasKey(u => new
        {
            u.UserId,
            u.UserRoleId,
        });

        modelBuilder.Entity<UserRolePermissionMappingEntity>().HasKey(u => new
        {
            u.PermissionId,
            u.UserRoleId,
        });
    }

    // -- User
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRoleEntity> UserRoles { get; set; }
    public DbSet<UserUserRoleMappingEntity> UserUserRoleMappings { get; set; }

    // -- Permission
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<UserRolePermissionMappingEntity> UserRolePermissionMappings { get; set; }


    //-- Log
}