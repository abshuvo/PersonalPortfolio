using System.ComponentModel.DataAnnotations;

namespace DigiPortfoli.Models.Entities
{
    public class ServiceInfo
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? description { get; set; }

        public string? Icon { get; set; }
      
    }
}
