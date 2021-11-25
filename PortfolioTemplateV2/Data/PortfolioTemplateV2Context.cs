using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplateV2.Models;

namespace PortfolioTemplateV2.Data
{
    public class PortfolioTemplateV2Context : DbContext
    {
        public PortfolioTemplateV2Context (DbContextOptions<PortfolioTemplateV2Context> options)
            : base(options)
        {
        }

        public DbSet<PortfolioTemplateV2.Models.Project> Project { get; set; }
    }
}
