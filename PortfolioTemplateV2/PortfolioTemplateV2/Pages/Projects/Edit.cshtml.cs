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

namespace PortfolioTemplateV2.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly PortfolioTemplateV2.Data.PortfolioTemplateV2Context _context;

        private readonly IWebHostEnvironment _iweb;

        public EditModel(PortfolioTemplateV2.Data.PortfolioTemplateV2Context context, IWebHostEnvironment iweb)
        {
            _context = context;

            _iweb = iweb;
        }

        [BindProperty]
        public Project Project { get; set; }

        [BindProperty]
        public IFormFile? Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FirstOrDefaultAsync(m => m.Id == id);
            //Console.WriteLine("Project PhotoName: " + Project.PhotoName);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
            
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Project project, int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            //Console.WriteLine("Project PhotoName: " + Project.PhotoName);

            Project = await _context.Project.FindAsync(id);

            //_context.Attach(Project).State = EntityState.Modified;

            /*Console.WriteLine("Project Id: " + Project.Id);
            Console.WriteLine("Project Name: " + Project.Name);
            Console.WriteLine("Project Description: "+Project.Description);
            Console.WriteLine("Project PhotoName: " + Project.PhotoName);*/
            if (Photo == null)
            {
                project.PhotoName = Project.PhotoName;
            }

            if (Photo != null)
            {
                project.PhotoName = Photo.Name;
                if (project.PhotoName != null)
                {
                    string filePath = Path.Combine(_iweb.WebRootPath, "images", Project.PhotoName);
                    System.IO.File.Delete(filePath);
                    await _context.SaveChangesAsync();
                }

                project.PhotoName = Photo.FileName;
                var fileUpload = Path.Combine(_iweb.WebRootPath, "images", Photo.FileName);
                using (var fs = new FileStream(fileUpload, FileMode.Create))
                {
                    await Photo.CopyToAsync(fs);

                }

            }
                
            Project.Name = project.Name;
            Project.Description = project.Description;
            Project.PhotoName = project.PhotoName;
                
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
