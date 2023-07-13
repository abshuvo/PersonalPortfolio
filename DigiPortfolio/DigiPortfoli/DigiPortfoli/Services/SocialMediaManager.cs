using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class SocialMediaManager
    {

        public async Task<SocialMediaInfo> GetSocialMediaInfo(DBConfiguration _context, int id)
        {
            return await _context.SocialMediaInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<SocialMediaInfo>> GetSocialMediaInfoList(DBConfiguration _context)
        {
            return await _context.SocialMediaInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, SocialMediaInfo model)
        {
            Result result = new Result();

            try
            {
                if (model.Id == 0)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    result.Msg = "Data inserted successfully!";
                    result.Status = "success";
                }
                else
                {
                    SocialMediaInfo updateModel = await GetSocialMediaInfo(_context, model.Id);
                    updateModel.PersonalInfoId = model.PersonalInfoId;
                    updateModel.SocialMediaName = model.SocialMediaName;
                    updateModel.SocialMediaURL = model.SocialMediaURL;
                    _context.Update(updateModel);
                    _context.SaveChanges();
                    result.Msg = "Data updated successfully!";
                    result.Status = "success";
                }
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.Status = "error";
            }
            return result;

        }
        public async Task<Result> DeleteSocialMedia(DBConfiguration _context, int id)
        {
            SocialMediaInfo cat = await GetSocialMediaInfo(_context, id);
            _context.SocialMediaInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }
    }
}
