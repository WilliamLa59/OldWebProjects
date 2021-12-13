using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateV2.Models
{

    public class Credential
    {
        public int Id { get; set; } 
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
