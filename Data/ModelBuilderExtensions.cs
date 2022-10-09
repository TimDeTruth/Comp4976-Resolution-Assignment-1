using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResolutionAssignment.Models;
using ResolutionAssignment.Data;

namespace ResolutionAssignment.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "P@$$w0rd";
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            // Seed Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var memberRole = new IdentityRole("Member");
            memberRole.NormalizedName = memberRole.Name.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
            adminRole,
            memberRole
            };

            builder.Entity<IdentityRole>().HasData(roles);


            // Seed Users
            var adminUser = new ApplicationUser
            {
                UserName = "aa@aa.aa",
                Email = "aa@aa.aa",
                EmailConfirmed = true,
                FirstName = "AdminFirst",
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            var memberUser = new ApplicationUser
            {
                UserName = "mm@mm.mm",
                Email = "mm@mm.mm",
                EmailConfirmed = true,
                FirstName = "MemberFirst",
                LastName = "MemberLast",
            };
            memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
            memberUser.NormalizedEmail = memberUser.Email.ToUpper();
            memberUser.PasswordHash = passwordHasher.HashPassword(memberUser, pwd);

            var memberUser1 = new ApplicationUser
            {
                UserName = "1@1.1",
                Email = "1@1.1",
                EmailConfirmed = true,
                FirstName = "MemberFirst1",
                LastName = "MemberLast1",
            };
            memberUser1.NormalizedUserName = memberUser1.UserName.ToUpper();
            memberUser1.NormalizedEmail = memberUser1.Email.ToUpper();
            memberUser1.PasswordHash = passwordHasher.HashPassword(memberUser, pwd);


            var memberUser2 = new ApplicationUser
            {
                UserName = "2@2.2",
                Email = "2@2.2",
                EmailConfirmed = true,
                FirstName = "MemberFirst2",
                LastName = "MemberLast2",
            };
            memberUser2.NormalizedUserName = memberUser2.UserName.ToUpper();
            memberUser2.NormalizedEmail = memberUser2.Email.ToUpper();
            memberUser2.PasswordHash = passwordHasher.HashPassword(memberUser2, pwd);

            var memberUser3 = new ApplicationUser
            {
                UserName = "3@3.3",
                Email = "3@3.3",
                EmailConfirmed = true,
                FirstName = "MemberFirst3",
                LastName = "MemberLast3",
            };
            memberUser3.NormalizedUserName = memberUser3.UserName.ToUpper();
            memberUser3.NormalizedEmail = memberUser3.Email.ToUpper();
            memberUser3.PasswordHash = passwordHasher.HashPassword(memberUser3, pwd);

            var memberUser4 = new ApplicationUser
            {
                UserName = "4@4.4",
                Email = "4@4.4",
                EmailConfirmed = true,
                FirstName = "MemberFirst4",
                LastName = "MemberLast4",
            };
            memberUser4.NormalizedUserName = memberUser4.UserName.ToUpper();
            memberUser4.NormalizedEmail = memberUser4.Email.ToUpper();
            memberUser4.PasswordHash = passwordHasher.HashPassword(memberUser4, pwd);

            var memberUser5 = new ApplicationUser
            {
                UserName = "5@5.5",
                Email = "5@5.5",
                EmailConfirmed = true,
                FirstName = "MemberFirst5",
                LastName = "MemberLast5",
            };
            memberUser5.NormalizedUserName = memberUser5.UserName.ToUpper();
            memberUser5.NormalizedEmail = memberUser5.Email.ToUpper();
            memberUser5.PasswordHash = passwordHasher.HashPassword(memberUser5, pwd);

            List<ApplicationUser> users = new List<ApplicationUser>() {
            adminUser,
            memberUser,
            memberUser1,
            memberUser2,
            memberUser3,
            memberUser4,
            memberUser5

            };//list of users


            builder.Entity<ApplicationUser>().HasData(users);//add the users to the database

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[3].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[4].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[5].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[6].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });


            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);


        }
    }

}