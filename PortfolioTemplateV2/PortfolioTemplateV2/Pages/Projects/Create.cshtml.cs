using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using PortfolioTemplateV2.Data;
using PortfolioTemplateV2.Models;

namespace PortfolioTemplateV2.Pages.Projects
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly PortfolioTemplateV2.Data.PortfolioTemplateV2Context _context;

        private readonly IWebHostEnvironment _iweb;

        public CreateModel(PortfolioTemplateV2.Data.PortfolioTemplateV2Context context, IWebHostEnvironment iweb)
        {
            _context = context;

            _iweb = iweb;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Project.PhotoName = Photo.FileName;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var fileUpload = Path.Combine(_iweb.WebRootPath, "images", Photo.FileName);
            using (var fs = new FileStream(fileUpload, FileMode.Create))
            {
                await Photo.CopyToAsync(fs);

            }

            /*Console.WriteLine("Project Id: " + Project.Id);
            Console.WriteLine("Project Name: " + Project.Name);
            Console.WriteLine("Project PhotoName: " + Project.PhotoName);*/

            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
