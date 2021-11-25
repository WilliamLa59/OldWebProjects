using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioTemplateV2.Data;
using PortfolioTemplateV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PortfolioTemplateV2.Pages.Projects
{
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
       /* public async Task<IActionResult> OnPostAsync(IFormFile uploadfile, Project project)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string imgext = Path.GetExtension(uploadfile.FileName);
            if (imgext == ".jpg" || imgext == ".JPG" || imgext == ".png" || imgext == ".PNG")
            {
                var imgsave = Path.Combine(_iweb.ContentRootPath, "images", uploadfile.FileName);
                var stream = new FileStream(imgsave, FileMode.Create);
                await uploadfile.CopyToAsync(stream);
                stream.Close();

                _context.Project.Add(project);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }*/

        public async Task<IActionResult> OnPostAsync()
        {
            Project.PhotoPath = Photo.FileName;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var fileUpload = Path.Combine(_iweb.WebRootPath, "images", Photo.FileName);
            using (var fs = new FileStream(fileUpload, FileMode.Create))
            {
                await Photo.CopyToAsync(fs);
                
               
            }

            
            Console.WriteLine("Path: " + Project.PhotoPath);
            Console.WriteLine("Name: " + Project.Name);
            Console.WriteLine("Id: " + Project.Id);
            Console.WriteLine("Desc: " + Project.Description);

            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            

            return RedirectToPage("./Index");
        }


    }
}
