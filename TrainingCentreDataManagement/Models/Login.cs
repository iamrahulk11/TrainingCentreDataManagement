using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingCentreDataManagement.Models
{
    [Table("login")]
    public class Login
    {
        [Key]
        public int id { get; set; }
        
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
