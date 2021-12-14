using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateV2.Models
{

    public class Credential
    {
        public int Id { get; set; } 
        
        public string? UserName { get; set; }
        
        public string? Salt { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        

    }
}
