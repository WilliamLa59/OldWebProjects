using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplateV2.Data;
using PortfolioTemplateV2.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace PortfolioTemplateV2.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly PortfolioTemplateV2.Data.PortfolioTemplateV2Context _context;

        public EditModel(PortfolioTemplateV2.Data.PortfolioTemplateV2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Credential Credential { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Credential = await _context.Credential.FirstOrDefaultAsync(m => m.Id == id);

            if (Credential == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
            string Salt = generateSalt();

            try
            {
                credential.UserName = Credential.UserName;
                Credential.Salt = Salt;
                Credential.Password = hashThis(credential.Password, Salt);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredentialExists(Credential.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CredentialExists(int id)
        {
            return _context.Credential.Any(e => e.Id == id);
        }


       
        public string generateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string hashThis(string inputPass, string inputSalt)
        {
            byte[] salt = Encoding.ASCII.GetBytes(inputSalt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: inputPass,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
