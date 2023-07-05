using System.ComponentModel.DataAnnotations;

namespace DigiPortfoli.Models.Entities
{
    public class Content
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}

