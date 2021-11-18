using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplate.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
