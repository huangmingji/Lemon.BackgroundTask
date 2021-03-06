using Lemon.BackgroundTask.Domain.Account.Role;
using Lemon.BackgroundTask.Domain.Account.Users;
using Microsoft.EntityFrameworkCore;

namespace Lemon.BackgroundTask.EntityFrameworkCore
{
    public static class DbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.AccountConfigure();
        }

        private static void AccountConfigure(this ModelBuilder builder)
        {
            builder.Entity<RoleData>(b =>
            {
                b.ToTable("RoleData");
                b.HasKey(o => o.Id);
                b.HasMany(x => x.RolePermissionDatas)
                    .WithOne()
                    .HasForeignKey(x => x.RoleId);
            });
            
            builder.Entity<RolePermissionData>(b =>
            {
                b.ToTable("RolePermissionData");
                b.HasKey(x => x.Id );
            });
            
            builder.Entity<PermissionData>(b =>
            {
                b.ToTable("PermissionData");
                b.HasKey(o => o.Id);
            });
            
            builder.Entity<UserData>(b =>
            {
                b.ToTable("UserData");
                b.HasKey(o => o.Id);
                b.HasMany(x => x.UserRoles)
                    .WithOne()
                    .HasForeignKey(x => x.UserId);
                b.HasIndex(o => o.Account).IsUnique();
                b.HasIndex(x => x.Email).IsUnique();
                b.HasIndex(x => x.Mobile).IsUnique();
            });

            builder.Entity<UserRole>(b =>
            {
                b.ToTable("UserRole");
                b.HasKey(x=> x.Id);
                b.HasOne(x => x.RoleData)
                    .WithOne()
                    .HasForeignKey<UserRole>(x => x.RoleId);
                b.HasIndex(o => o.UserId);
                b.HasIndex(o => new { o.RoleId, o.UserId }).IsUnique();
            });
        }
    }
}