using DigiPortfoli.Models.ViewModel;
using DigiPortfoli.Models;
using DigiPortfoli.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class AboutManager
    {
        public async Task<AboutPageModel> GetPortfolioInfoList(DBConfiguration _context)
        {
            PortfolioInfo info= await _context.PortfolioInfo.FirstOrDefaultAsync();
            PersonalInfo personalInfoes = await _context.PersonalInfo.FirstOrDefaultAsync();
            AboutPageModel model = new AboutPageModel();
            model.Description = info.Description;
            model.Name = personalInfoes.Name;
            model.Address = personalInfoes.Address;
            model.Profession = personalInfoes.Profession;
            model.Birthdate = personalInfoes.Birthdate;
            model.Mobile = personalInfoes.Mobile;
            model.Email = personalInfoes.Email;
            model.Qualification = personalInfoes.Qualification;
            model.Age=personalInfoes.Age;

            return model;
        }

        }
}