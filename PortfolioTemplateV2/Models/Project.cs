using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateV2.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string? PhotoPath { get; set; }
    }
}
