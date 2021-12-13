using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplateV2.Data;
using PortfolioTemplateV2.Models;

namespace PortfolioTemplateV2.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly PortfolioTemplateV2.Data.PortfolioTemplateV2Context _context;

        public DeleteModel(PortfolioTemplateV2.Data.PortfolioTemplateV2Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Credential = await _context.Credential.FindAsync(id);

            if (Credential != null)
            {
                _context.Credential.Remove(Credential);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
