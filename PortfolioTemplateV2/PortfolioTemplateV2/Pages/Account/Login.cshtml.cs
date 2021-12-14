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
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PortfolioTemplateV2.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly PortfolioTemplateV2.Data.PortfolioTemplateV2Context _context;

        public LoginModel(PortfolioTemplateV2.Data.PortfolioTemplateV2Context context)
        {
            _context = context;

        }

        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(Credential credential)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Credential = await _context.Credential.FirstOrDefaultAsync(m => m.Id == 1);

            credential.Salt = Credential.Salt;

            Console.WriteLine("C Salt: " + Credential.Salt);
            Console.WriteLine("C Pass: " + Credential.Password);
            Console.WriteLine("C User: " + Credential.UserName);
            Console.WriteLine("Salt: " + credential.Salt);
            Console.WriteLine("Pass: " + credential.Password);
            Console.WriteLine("User: " + credential.UserName);


           

            /*
            Console.WriteLine("Salt: " + credential.Salt);
            Console.WriteLine("Pass: " + credential.Password);
            Console.WriteLine("User: " + credential.UserName);
           */

        
            //verify credentials
            if (credential.UserName == Credential.UserName && hashVerify(credential.Password, credential.Salt) == true)  
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

        public bool hashVerify (string inputPass, string inputSalt)
        {
            byte[] salt = Encoding.ASCII.GetBytes(inputSalt);

            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: inputPass,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            Console.WriteLine($"Hashed: {hashed}");

            if (hashed.Equals(Credential.Password))
            {
                return true;
            }
            else
                return false;
        }
    }

}
