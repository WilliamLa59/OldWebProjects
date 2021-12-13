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
    public class IndexModel : PageModel
    {
        private readonly PortfolioTemplateV2.Data.PortfolioTemplateV2Context _context;

        public IndexModel(PortfolioTemplateV2.Data.PortfolioTemplateV2Context context)
        {
            _context = context;
        }

        public IList<Credential> Credential { get;set; }

        public async Task OnGetAsync()
        {
            Credential = await _context.Credential.ToListAsync();
        }
    }
}
