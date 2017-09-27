using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace identity.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login(string jwt, string returnUrl = "/")
        {
            var claims = CreateClaimsPrincipal(jwt);

            var properties = GetAuthenticationProperties();

            await CreateSession(claims, properties);

            return Redirect(returnUrl);
        }

        private AuthenticationProperties GetAuthenticationProperties()
        {
            var properties = new AuthenticationProperties
            {
                IsPersistent = false,
                AllowRefresh = true,
            };

            return properties;
        }

        public static ClaimsPrincipal CreateClaimsPrincipal(string identity)
        {
            var idClaims = new List<Claim>
            {

                new Claim(ClaimTypes.Name, identity),            };

            var userIdentity = new ClaimsIdentity(idClaims, "LocalHost");
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            return userPrincipal;
        }

        private async Task CreateSession(ClaimsPrincipal claims, AuthenticationProperties properties)
        {
            {
                await HttpContext.SignInAsync(
                    AuthSchemes.CookieAuthName,
                    claims,
                    properties);

            }
        }
    }
}