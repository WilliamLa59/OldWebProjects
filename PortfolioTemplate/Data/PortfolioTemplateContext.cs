using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Data
{
    public class PortfolioTemplateContext : DbContext
    {
        public PortfolioTemplateContext(DbContextOptions<PortfolioTemplateContext> options)
            : base(options)
        {
        }
        
        public DbSet<PortfolioTemplate.Models.Project>? project { get; set; }
    }
}