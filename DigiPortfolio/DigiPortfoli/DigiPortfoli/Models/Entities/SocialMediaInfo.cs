using System.ComponentModel.DataAnnotations;

namespace DigiPortfoli.Models.Entities
{
    public class SocialMediaInfo
    {
        [Key]
        public int Id { get; set; }
        public int PersonalInfoId { get; set; }
        public string? SocialMediaName { get; set; }
        public string? SocialMediaURL { get; set; }


            
    }
}
