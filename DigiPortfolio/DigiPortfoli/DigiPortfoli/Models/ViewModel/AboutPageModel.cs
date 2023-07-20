using DigiPortfoli.Models.Entities;

namespace DigiPortfoli.Models.ViewModel
{
    public class AboutPageModel
    {
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Profession { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Qualification { get; set; }
        public decimal Age { get; set; }

        public string? Description { get; set; }

    }
}
