using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using application.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [Route("api")]
    public class LoginController : Controller
    {
        private readonly SignInManager<EmployeeUser> _signInManager;
        private readonly UserManager<EmployeeUser> _userManager;

        public LoginController(SignInManager<EmployeeUser> signInManager, UserManager<EmployeeUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if (await _signInManager.CanSignInAsync(user))
                    {
                        await _signInManager.SignInAsync(user, new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddHours(8),
                            IssuedUtc = DateTime.UtcNow
                        });

                        return Ok();
                    }
                }
            }

            return BadRequest();
        }
    }

    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}