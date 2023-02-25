using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyForum.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.DAL
{
    public class DataSeeder
    {

        private MyForumDbContext _context;

        public DataSeeder(MyForumDbContext context)
        {
            this._context = context;
        }
        public Task SeedAdminUser()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<User>(_context);
           
            var user = new User
            {
                UserName= "FirstAdmin",
                NormalizedUserName ="firstadmin",
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                EmailConfirmed =true,
                LockoutEnabled = false,
                SecurityStamp= Guid.NewGuid().ToString()

            };

            var hasher = new PasswordHasher<User>();
            var hashedPassword = hasher.HashPassword(user, "admin");
            user.PasswordHash = hashedPassword;
            var isAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");
            if (!isAdminRole)
            {
                  roleStore.CreateAsync(new IdentityRole 
                {
                    Name = "Admin", 
                    NormalizedName = "admin" 
                });

            }
            var hasSuperUser = _context.Users.Any(u => u.NormalizedUserName == user.UserName);
            if (!hasSuperUser)
            {
                 userStore.CreateAsync(user);
                 userStore.AddToRoleAsync(user, "Admin");
            }

             _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
