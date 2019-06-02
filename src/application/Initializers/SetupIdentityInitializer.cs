using System;
using System.Threading.Tasks;
using application.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace application.Initializers
{
    public class SetupIdentityInitializer
    {
        public static string ManagerRole = "Manager";
        public static string SalespersonRole = "SalesPerson";
        public static string ManagerEmail = "manager@irscrews.com";
        public static string InitialPassword = "sTr3Am_P@s$w0 rD";

        public static void Initialize(UserManager<EmployeeUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<EmployeeUser> manager)
        {
            Task.Run(async () =>
            {
                if (manager.FindByEmailAsync(ManagerEmail) != null)
                {
                    var employeeUser = new EmployeeUser()
                    {
                        FirstName = "Fred",
                        LastName = "Manager",
                        Email = ManagerEmail,
                        UserName = ManagerEmail,
                        EmailConfirmed = true
                    };

                    var result = await manager.CreateAsync(employeeUser, InitialPassword);

                    if (result.Succeeded)
                    {
                        await manager.AddToRoleAsync(employeeUser, ManagerRole);
                    }
                }
            }).GetAwaiter().GetResult();
        }

        public static void SeedRoles(RoleManager<IdentityRole<Guid>> manager)
        {
            Task.Run(async () =>
            {
                if (!await manager.RoleExistsAsync(ManagerRole))
                {
                    await manager.CreateAsync(new IdentityRole<Guid> { Name = ManagerRole });
                }

                if (!await manager.RoleExistsAsync(SalespersonRole))
                {
                    await manager.CreateAsync(new IdentityRole<Guid> { Name = SalespersonRole });
                }
            }).GetAwaiter().GetResult();
        }
    }
}