using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;

namespace SeuProjeto.Controllers
{
    public class AccountController : Controller
    {
        // Redireciona para o provedor de autenticação
        public IActionResult Login(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

            return Challenge(properties, provider switch
            {
                "Google" => GoogleDefaults.AuthenticationScheme,
                "Facebook" => FacebookDefaults.AuthenticationScheme,
                _ => throw new ArgumentException("Provedor inválido.")
            });
        }

        // Callback do provedor (após login)
        public async Task<IActionResult> ExternalLoginCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
                return RedirectToAction("LoginFailed");

            var claims = result.Principal.Identities.FirstOrDefault()?.Claims;

            // Aqui você pode salvar dados no banco, gerar cookie, etc.
            // Exemplo: ViewBag.Name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult LoginFailed()
        {
            return View(); // Crie uma view simples com erro de login
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
