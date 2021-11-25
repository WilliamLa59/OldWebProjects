using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplateV2.Data;
using PortfolioTemplateV2.Models;

namespace PortfolioTemplateV2.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly PortfolioTemplateV2.Data.PortfolioTemplateV2Context _context;

        private readonly IWebHostEnvironment _iweb;

        public DeleteModel(PortfolioTemplateV2.Data.PortfolioTemplateV2Context context, IWebHostEnvironment iweb)
        {
            _context = context;

            _iweb = iweb;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
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

            Project = await _context.Project.FindAsync(id);

          
            string filePath = Path.Combine(_iweb.WebRootPath, "images", Project.PhotoPath);
            

            if (Project != null)
            {
                _context.Project.Remove(Project);
                System.IO.File.Delete(filePath);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
