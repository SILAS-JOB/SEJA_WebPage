using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SEJA_WebApp.Models;


namespace SEJA_WepApp.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Profile()
        {
            var viewmodel = new AccountModelView
            {
                Name = User.Identity.Name,
                Email = User.FindFirstValue(ClaimTypes.Email),
                GivenName = User.FindFirstValue(ClaimTypes.GivenName),
                SurName = User.FindFirstValue(ClaimTypes.Surname),
                ProfilePictureUrl = User.FindFirstValue("urn:google:picture"),

                AllClaims = User.Claims.ToList()
            };
            return View(viewmodel);
        }
    }
}