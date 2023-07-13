using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class ExperienceManager
    {
        public async Task<ExperienceInfo> GetExperienceInfo(DBConfiguration _context, int id)
        {
            return await _context.ExperienceInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<ExperienceInfo>> GetExperienceInfoList(DBConfiguration _context)
        {
            return await _context.ExperienceInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, ExperienceInfo model)
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
                    ExperienceInfo updateModel = await GetExperienceInfo(_context, model.Id);
                    updateModel.Title = model.Title;
                    updateModel.StartDate = model.StartDate;
                    updateModel.EndDate = model.EndDate;
                    updateModel.Department = model.Department;
                    updateModel.Company = model.Company;
                    updateModel.Description = model.Description;
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
        public async Task<Result> DeleteExperience(DBConfiguration _context, int id)
        {
            ExperienceInfo cat = await GetExperienceInfo(_context, id);
            _context.ExperienceInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }
    }
}
