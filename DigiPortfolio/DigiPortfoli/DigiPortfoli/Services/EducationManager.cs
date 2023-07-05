using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class EducationManager
    {

        public async Task<EducationInfo> GetEducationInfo(DBConfiguration _context, int id)
        {
            return await _context.EducationInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<EducationInfo>> GetEducationInfoList(DBConfiguration _context)
        {
            return await _context.EducationInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, EducationInfo model)
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
                    EducationInfo updateModel = await GetEducationInfo(_context, model.Id);
                    updateModel.Title = model.Title;
                    updateModel.StartDate = model.StartDate;
                    updateModel.EndDate = model.EndDate;
                    updateModel.Department = model.Department;
                    updateModel.Institution = model.Institution;
                    updateModel.Description = model.Description;
                    updateModel.Grade = model.Grade;
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
        public async Task<Result> DeleteEducation(DBConfiguration _context, int id)
        {
            EducationInfo cat = await GetEducationInfo(_context, id);
            _context.EducationInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }
    }
}
