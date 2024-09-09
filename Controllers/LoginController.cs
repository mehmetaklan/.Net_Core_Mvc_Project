using Departman_Management.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Departman_Management.Controllers
{
    public class LoginController : Controller
    {
        Context ContextDB = new Context();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Login(Admin admin)
        {
            var datas = ContextDB.admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (datas != null) 
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Username)
                };
                var userIdentity= new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Department");

            }
            return View(); 
        }
    }
}
