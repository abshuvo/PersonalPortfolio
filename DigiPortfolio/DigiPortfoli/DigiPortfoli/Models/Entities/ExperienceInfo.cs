using System.ComponentModel.DataAnnotations;

namespace DigiPortfoli.Models.Entities
{
    public class ExperienceInfo
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Company { get; set; }

        public string? Department { get; set; }

        public string? Description { get; set; }


    }
}
