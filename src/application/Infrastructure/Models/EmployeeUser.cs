using System;
using Microsoft.AspNetCore.Identity;

namespace application.Infrastructure.Models
{
    public class EmployeeUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalAccountNumber { get; set; }
    }
}