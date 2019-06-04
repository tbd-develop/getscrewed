using System;
using application.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace application.Infrastructure
{
    public class ApplicationContext : IdentityDbContext<EmployeeUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<EmployeeUser> EnployeeUser { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
    }
}