using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using DigiPortfoli.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class HomeManager
    {
        public async Task<HomePageModel> GetPersonalInfoList(DBConfiguration _context)
        {
            PersonalInfo info = await _context.PersonalInfo.FirstOrDefaultAsync();
            List<Skills> skillset = new List<Skills>();
            Skills skill = new Skills();
            skill.SkillName = "Html";
            skill.SkillDescription = "100%";
            skillset.Add(skill);
            Skills skil_1 = new Skills();
            skil_1.SkillName = "CSS";
            skil_1.SkillDescription = "90%";
            skillset.Add(skil_1);
            Skills skill_2 = new Skills();
            skill_2.SkillName = "JS";
            skill_2.SkillDescription = "100%";
            skillset.Add(skill_2);
            Skills skill_3 = new Skills();
            skill_3.SkillName = "ASP.NET Core";
            skill_3.SkillDescription = "100%";
            skillset.Add(skill_3);

            List<SocialMediaInfo> socialMediaInfos = await _context.SocialMediaInfo.ToListAsync();

            HomePageModel model = new HomePageModel();
            model.Name = info.Name;
            model.Profession = info.Profession;
            model.SkillsList = skillset;
            model.SocialLink = socialMediaInfos;

            return model;

        }
    }
}
