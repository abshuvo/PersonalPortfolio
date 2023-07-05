using System.ComponentModel.DataAnnotations;

namespace DigiPortfoli.Models.Entities
{
    public class CatagoryInfo { 
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
