using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiPortfoli.Models.Entities
{
    public class PersonalInfo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Profession { get; set; }
        public DateTime? Birthdate { get; set; }
        public decimal Age { get; set; }
        [MaxLength(20)]
        public string? Mobile { get; set; }
        [MaxLength(120)]
        public string? Email { get; set; }
        [MaxLength(220)]
        public string? Address { get; set; }
        [MaxLength(120)]
        public string? Qualification { get; set; }
    }
}
