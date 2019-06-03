using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using application.Infrastructure;
using System.Linq;
using application.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using application.Models;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly UserManager<EmployeeUser> _userManager;
        public EmployeeController(UserManager<EmployeeUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost, Route("createEmployee")]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeInput employee)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.FindByEmailAsync(employee.Email) != null)
                {
                    var employeeUser = new EmployeeUser()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        UserName = employee.Email,
                        EmailConfirmed = true,
                        PersonalAccountNumber = employee.PersonalAccountNumber
                    };

                    var result = await _userManager.CreateAsync(employeeUser, employee.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(employeeUser, "SalesPerson");
                        return Ok();
                    }
                    else
                        return BadRequest();
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }
       
    }
}

