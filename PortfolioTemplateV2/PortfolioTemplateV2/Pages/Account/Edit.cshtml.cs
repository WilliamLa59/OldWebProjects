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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Credential).State = EntityState.Modified;

            try
            {
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
    }
}
