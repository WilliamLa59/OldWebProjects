using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioTemplateV2.Data;
using PortfolioTemplateV2.Models;

namespace PortfolioTemplateV2.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //verify credentials
            if (Credential.UserName == "admin" && Credential.Password == "password")
            {
                //create security context
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim("Admin", "true")
                
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            return Page();

        }
    }

}
