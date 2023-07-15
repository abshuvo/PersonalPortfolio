using DigiPortfoli.Models.Entities;

namespace DigiPortfoli.Models.ViewModel
{
    public class HomePageModel
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public List<SocialMediaInfo> SocialLink { get; set; }
        public List<Skills> SkillsList { get; set; }
    }
}
