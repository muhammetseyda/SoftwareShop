using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using SoftwareShop.IdentityServer.Dtos;
using SoftwareShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace SoftwareShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto dto)
        {
            var values = new ApplicationUser()
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
            };
            var result = await _userManager.CreateAsync(values,dto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanici basariyla oluturuldu.");

            }
            else
            {
                return Ok("Bir hata olustu.");
            }
        }
    }
}
